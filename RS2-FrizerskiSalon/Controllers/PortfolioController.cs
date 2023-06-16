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
    public class PortfolioController : BaseCRUDController<FrizerskiSalon.Modal.Portfolio, PortfolioSearchObject, PortfolioInsertRequest, PortfolioInsertRequest>
    {
        public PortfolioController(IPortfolioService service)
            :base(service)
        {
        }
    }
}
