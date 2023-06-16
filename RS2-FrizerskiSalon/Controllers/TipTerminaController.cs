using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS2_FrizerskiSalon.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrizerskiSalon.Modal.Requests;

namespace RS2_FrizerskiSalon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipTerminaController : BaseReadController<FrizerskiSalon.Modal.TipTermina, object>
    {
        public TipTerminaController(IReadService<FrizerskiSalon.Modal.TipTermina, object> service)
            :base(service)
        {
        }
    }
}
