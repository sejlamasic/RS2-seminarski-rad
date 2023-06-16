using Microsoft.AspNetCore.Authorization;
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
    [AllowAnonymous]
    public class ZanimanjeController : BaseReadController<FrizerskiSalon.Modal.Zanimanje, object>
    {
        public ZanimanjeController(IReadService<FrizerskiSalon.Modal.Zanimanje, object> service)
            :base(service)
        {
        }
    }
}
