using Microsoft.AspNetCore.Mvc;
using RS2_FrizerskiSalon.Services;
using FrizerskiSalon.Modal.Requests;
using FrizerskiSalon.Modal.SearchObjects;

namespace RS2_FrizerskiSalon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerminController : BaseCRUDController<FrizerskiSalon.Modal.Termin, TerminSearchObject, TerminInsertRequest, TerminUpdateRequest>
    {
        public TerminController(ITerminService service)
            :base(service)
        {
        }
    }
}
