using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RS2_FrizerskiSalon.Configuration;
using RS2_FrizerskiSalon.Database;
using RS2_FrizerskiSalon.Filters;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FrizerskiSalon.Modal.Requests;
using FrizerskiSalon.Modal.Responses;
using FrizerskiSalon.Modal.SearchObjects;

namespace RS2_FrizerskiSalon.Services
{
    public class KlijentService : BaseCRUDService<FrizerskiSalon.Modal.Klijent, Klijent, KlijentSearchObject, KlijentInsertRequest, KlijentInsertRequest>, IKlijentService
    {
        private readonly IOptions<AppSettings> _options;

        public KlijentService(FrizerskiStudioRsiiContext context, IMapper mapper, IOptions<AppSettings> options)
            : base(context, mapper)
        {
            _options = options;
        }

        public override IList<FrizerskiSalon.Modal.Klijent> Get(KlijentSearchObject search = null)
        {
            var entity = _context.Set<Klijent>().AsQueryable();
            if (!string.IsNullOrWhiteSpace(search?.Ime))
            {
                entity = entity.Where(x => x.Ime == search.Ime);
            }

            if (!string.IsNullOrWhiteSpace(search?.Prezime))
            {
                entity = entity.Where(x => x.Prezime == search.Prezime);
            }
            if (search?.SpolId.HasValue == true)
            {
                entity = entity.Where(x => x.SpolId == search.SpolId);
            }
            entity = entity.Include(x => x.Spol);
            var result = entity.ToList();
            return _mapper.Map<IList<FrizerskiSalon.Modal.Klijent>>(result);
        }

        public override FrizerskiSalon.Modal.Klijent Insert(KlijentInsertRequest request)
        {
            var entity = _mapper.Map<Klijent>(request);
            if (_context.Klijents.Where(x => x.KorisnickoIme == request.KorisnickoIme).Any())
            {
                throw new UserException("Korisničko ime je zauzeto");
            }
            if (request.Lozinka != request.PotvrdiLozinku)
            {
                throw new UserException("Lozinke se ne podudaraju");
            }
            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Lozinka);
            _context.Klijents.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<FrizerskiSalon.Modal.Klijent>(entity);
        }

        public static string GenerateSalt()
        {
            byte[] salt = new byte[16];
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];
            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public UserAuthenticationResult Authenticate(UserLoginModel userLogin)
        {
            var user = _context.Klijents.FirstOrDefault(x => x.KorisnickoIme == userLogin.Username);
            if (user == null)
            {
                throw new UserException("Greška");
            }
            if (user.LozinkaHash != GenerateHash(user.LozinkaSalt, userLogin.Password))
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.KlijentId.ToString()),
                    new Claim(ClaimTypes.Name, user.KorisnickoIme),
                }),
                Issuer = _options.Value.Issuer,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new UserAuthenticationResult
            {
                Id = user.KlijentId,
                Token = tokenHandler.WriteToken(token),
                Username = user.KorisnickoIme
            };
        }

        public override FrizerskiSalon.Modal.Klijent Update(int id, KlijentInsertRequest request)
        {
            var entity = _context.Klijents.Find(id);
            _mapper.Map(request, entity);
            if (!string.IsNullOrWhiteSpace(request.Lozinka) && !string.IsNullOrWhiteSpace(request.PotvrdiLozinku))
            {
                entity.LozinkaSalt = GenerateSalt();
                entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Lozinka);
            }
            else
            {
                throw new UserException("Promjene nisu sačuvane");
            }
            _context.SaveChanges();
            if (!string.IsNullOrWhiteSpace(request.Lozinka))
            {
                if (request.Lozinka != request.PotvrdiLozinku)
                {
                    throw new UserException("Lozinke se ne podudaraju");
                }
            }
            _context.SaveChanges();
            return _mapper.Map<FrizerskiSalon.Modal.Klijent>(entity);
        }

        public override bool Delete(int id)
        {
            if (id != 0)
            {
                var narudzbe = _context.Narudzbas.Where(x => x.KlijentId == id).ToList();
                foreach(var x in narudzbe)
                {
                    var stavkeNarudzbe = _context.StavkeNarudzbes.Where(y => y.NarudzbaId == x.NarudzbaId).ToList();
                    foreach(var y in stavkeNarudzbe)
                    {
                        _context.Remove(y);
                    }
                    _context.SaveChanges();
                    _context.Remove(x);
                }
                _context.SaveChanges();
                var termini = _context.Termins.Where(x => x.KlijentId == id).ToList();
                foreach(var x in termini)
                {
                    _context.Remove(x);
                }
                _context.SaveChanges();
                var klijent = _context.Klijents.Find(id);
                _context.Remove(klijent);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
