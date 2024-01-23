using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RS2_FrizerskiSalon.Services;
using FrizerskiSalon.Modal.Requests;
using FrizerskiSalon.Modal.SearchObjects;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace RS2_FrizerskiSalon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ProizvodController : BaseCRUDController<FrizerskiSalon.Modal.Proizvod, ProizvodSearchObject, ProizvodInsertRequest, ProizvodInsertRequest>
    {
        public ProizvodController(IProizvodService service)
            :base(service)
        {
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [AllowAnonymous]
        [HttpGet("Recommend/{id}")]
        public List<FrizerskiSalon.Modal.Proizvod> Recommend(int id)
        {
            return (_service as IProizvodService).Recommend(id);
        }
       
    }
}
