using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS2_FrizerskiSalon.Database;
using RS2_FrizerskiSalon.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_FrizerskiSalon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class SpolController : BaseReadController<FrizerskiSalon.Modal.Spol, object>
    {
        public SpolController(IReadService<FrizerskiSalon.Modal.Spol, object> service)
            :base(service)
        {
        }
    }
}
