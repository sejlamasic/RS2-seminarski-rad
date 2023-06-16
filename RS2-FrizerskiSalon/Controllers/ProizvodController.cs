using Microsoft.AspNetCore.Authorization;
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
    public class ProizvodController : BaseCRUDController<FrizerskiSalon.Modal.Proizvod, ProizvodSearchObject, ProizvodInsertRequest, ProizvodInsertRequest>
    {
        public ProizvodController(IProizvodService service)
            :base(service)
        {
        }

        [HttpGet("Recommend/{id}")]
        public List<FrizerskiSalon.Modal.Proizvod> Recommend(int id)
        {
            return (_service as IProizvodService).Recommend(id);
        }
    }
}
