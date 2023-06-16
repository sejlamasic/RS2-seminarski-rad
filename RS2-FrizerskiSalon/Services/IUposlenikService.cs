using FrizerskiSalon.Modal.Requests;
using FrizerskiSalon.Modal.SearchObjects;

namespace RS2_FrizerskiSalon.Services
{
    public interface IUposlenikService : ICRUDService<FrizerskiSalon.Modal.Uposlenik, UposlenikSearchObject, UposlenikInsertRequest, UposlenikInsertRequest>
    {
        FrizerskiSalon.Modal.Responses.UserAuthenticationResult Authenticate(UserLoginModel userLoginModel);

    }
}
