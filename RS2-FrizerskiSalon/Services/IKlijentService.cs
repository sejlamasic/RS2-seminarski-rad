using System.Collections.Generic;
using System.Threading.Tasks;
using FrizerskiSalon.Modal.Requests;
using FrizerskiSalon.Modal.SearchObjects;

namespace RS2_FrizerskiSalon.Services
{
    public interface IKlijentService : ICRUDService<FrizerskiSalon.Modal.Klijent, KlijentSearchObject, KlijentInsertRequest, KlijentInsertRequest>
    {
        FrizerskiSalon.Modal.Responses.UserAuthenticationResult Authenticate(UserLoginModel userLoginModel);
    }
}
