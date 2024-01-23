
using FrizerskiSalon.Modal.Requests;
using FrizerskiSalon.Modal.SearchObjects;

namespace RS2_FrizerskiSalon.Services
{
    public interface IProizvodService : ICRUDService<FrizerskiSalon.Modal.Proizvod, ProizvodSearchObject, ProizvodInsertRequest, ProizvodInsertRequest>
    {
        public List<FrizerskiSalon.Modal.Proizvod> Recommend(int id);
        public int BrojProdanih(int id);

    }
}
