using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS2_FrizerskiSalon.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrizerskiSalon.Modal.Requests;
using FrizerskiSalon.Modal.SearchObjects;

namespace RS2_FrizerskiSalon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.AllowAnonymous]
    public class StavkeNarudzbeController : BaseCRUDController<FrizerskiSalon.Modal.StavkeNarudzbe, StavkeNarudzbeSearchObject, StavkeNarudzbeInsertRequest, StavkeNarudzbeUpdateRequest>
    {
        public StavkeNarudzbeController(IStavkeNarudzbeService service)
            :base(service)
        {
        }
    }
}
