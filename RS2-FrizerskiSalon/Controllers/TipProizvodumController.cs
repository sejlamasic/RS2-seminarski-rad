using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS2_FrizerskiSalon.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_FrizerskiSalon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipProizvodumController : BaseReadController<FrizerskiSalon.Modal.TipProizvodum, object>
    {
        public TipProizvodumController(IReadService<FrizerskiSalon.Modal.TipProizvodum, object> service)
            :base(service)
        {
        }
    }
}
