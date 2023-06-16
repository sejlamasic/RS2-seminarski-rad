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
    public class StavkePortfoliumController : BaseCRUDController<FrizerskiSalon.Modal.StavkePortfolium, StavkePortfoliumSearchObject, StavkePortfoliumInsertRequest, StavkePortfoliumInsertRequest>
    {
        public StavkePortfoliumController(IStavkePortfoliumService service)
            :base(service)
        {
        }
    }
}
