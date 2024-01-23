﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using RS2_FrizerskiSalon.Database;
using FrizerskiSalon.Modal.Requests;
using FrizerskiSalon.Modal.SearchObjects;

namespace RS2_FrizerskiSalon.Services
{
    public class ProizvodService : BaseCRUDService<FrizerskiSalon.Modal.Proizvod, Proizvod, ProizvodSearchObject, ProizvodInsertRequest, ProizvodInsertRequest>, IProizvodService
    {
        public ProizvodService(FrizerskiStudioRsiiContext context, IMapper mapper)
            :base(context, mapper)
        {
        }

        public int BrojProdanih(int id)
        {
            var brProdanih = _context.StavkeNarudzbes.Where(x => x.ProizvodId == id).Count();
            return brProdanih;
        }


        public override IList<FrizerskiSalon.Modal.Proizvod> Get(ProizvodSearchObject search = null)
        {
            var entity = _context.Set<Proizvod>().AsQueryable();
            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                entity = entity.Where(x => x.Naziv.Contains(search.Naziv));
            }
            if (search?.TipProizvodaId.HasValue == true)
            {
                entity = entity.Where(x => x.TipProizvodaId == search.TipProizvodaId);
            }
            //if (search?.IncludeTipProizvoda == true)
            //{
            //    entity = entity.Include(x => x.TipProizvoda);
            //}
            if (search?.Cijena.HasValue == true)
            {
                entity = entity.Where(x => x.Cijena <= search.Cijena);
            }
            //if (search?.IncludeList.Any() == true)
            //{
            //    foreach (var item in search.IncludeList)
            //    {
            //        entity = entity.Include(item);
            //    }
            //}
            var result = entity.Include(x => x.TipProizvoda).OrderBy(x => x.Cijena).ToList();

            return _mapper.Map<IList<FrizerskiSalon.Modal.Proizvod>>(result);
        }

        public override FrizerskiSalon.Modal.Proizvod GetById(int id)
        {
            var entity = _context.Proizvods.Include(x => x.TipProizvoda)
                .Where(x => x.ProizvodId == id)
                .FirstOrDefaultAsync();
            return _mapper.Map<FrizerskiSalon.Modal.Proizvod>(entity.Result);
        }

        public override bool Delete(int id)
        {
            if (id != 0)
            {
                var stavkeNarudzbe = _context.StavkeNarudzbes.Where(x => x.ProizvodId == id).ToList();
                foreach(var x in stavkeNarudzbe)
                {
                    _context.Remove(x);
                }
                _context.SaveChanges();
                var proizvod = _context.Proizvods.Find(id);
                _context.Remove(proizvod);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public override FrizerskiSalon.Modal.Proizvod Insert(ProizvodInsertRequest request)
        {
            var entity = _mapper.Map<Proizvod>(request);
            _context.Proizvods.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<FrizerskiSalon.Modal.Proizvod>(entity);
        }





        static object isLocked = new object();
        static MLContext mlContext;
        static ITransformer model;
        public List<FrizerskiSalon.Modal.Proizvod> Recommend(int id)
        {
            lock (isLocked)
            {
                if (mlContext == null)
                {
                    mlContext = new MLContext();
                    try
                    {
                        var tmpData = _context.Narudzbas.ToList();

                        var data = new List<ProductEntry>();
                        List<StavkeNarudzbe> stavkeNarudzbe;

                        foreach (var x in tmpData)
                        {
                            stavkeNarudzbe = _context.StavkeNarudzbes.Where(e => e.NarudzbaId == x.NarudzbaId).ToList();
                            if (stavkeNarudzbe.Count > 1)
                            {
                                var distinctItemId = stavkeNarudzbe.Select(y => y.ProizvodId).ToList();

                                distinctItemId.ForEach(y =>
                                {
                                    var relatedItems = stavkeNarudzbe.Where(z => z.ProizvodId != y);

                                    foreach (var z in relatedItems)
                                    {
                                        data.Add(new ProductEntry()
                                        {
                                            ProductID = (uint)y,
                                            CoPurchaseProductID = (uint)z.ProizvodId,
                                        });
                                    }
                                });
                            }
                        }

                        var traindata = mlContext.Data.LoadFromEnumerable(data);

                        MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
                        options.MatrixColumnIndexColumnName = nameof(ProductEntry.ProductID);
                        options.MatrixRowIndexColumnName = nameof(ProductEntry.CoPurchaseProductID);
                        options.LabelColumnName = "Label";
                        options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass;
                        options.Alpha = 0.01;
                        options.Lambda = 0.025;

                        options.NumberOfIterations = 100;
                        options.C = 0.00001;

                        var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);

                        model = est.Fit(traindata);

                    }
                    catch (Exception ex)
                    {
                        // Log or handle the exception
                        Console.WriteLine($"Error loading model: {ex.Message}");
                        // You might want to return a default result or throw an exception here
                        return new List<FrizerskiSalon.Modal.Proizvod>();
                    }
                }
            }

            List<Database.Proizvod> allItems = new List<Database.Proizvod>();
            var tmp = _context.Proizvods.Where(x => x.ProizvodId != id);
            allItems.AddRange(tmp);

            var predictionResult = new List<Tuple<Database.Proizvod, float>>();

            foreach (var item in allItems)
            {
                var predictionEngine = mlContext.Model.CreatePredictionEngine<ProductEntry, CopurchasePrediction>(model);
                var prediction = predictionEngine.Predict(new ProductEntry()
                {
                    ProductID = (uint)id,
                    CoPurchaseProductID = (uint)item.ProizvodId
                });

                predictionResult.Add(new Tuple<Database.Proizvod, float>(item, prediction.Score));
            }

            var finalResult = predictionResult.OrderByDescending(x => x.Item2)
                .Select(x => x.Item1).Take(3).ToList();

            return _mapper.Map<List<FrizerskiSalon.Modal.Proizvod>>(finalResult);
        }
    }

    public class CopurchasePrediction
    {
        public float Score { get; set; }
    }

    public class ProductEntry
    {
        [KeyType(count: 10)]
        public uint ProductID { get; set; }

        [KeyType(count: 10)]
        public uint CoPurchaseProductID { get; set; }

        public float Label { get; set; }
    }
}