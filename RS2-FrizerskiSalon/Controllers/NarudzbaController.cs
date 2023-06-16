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
    public class NarudzbaController : BaseCRUDController<FrizerskiSalon.Modal.Narudzba, NarudzbaSearchObject, NarudzbaInsertRequest, NarudzbaInsertRequest>
    {
        public NarudzbaController(INarudzbaService service)
            :base(service)
        {
        }

        [HttpGet("AktivnaNarudzba/{id}")]
        public int AktivnaNarudzba(int id)
        {
            return (_service as INarudzbaService).AktivnaNarudzba(id);
        }

        [HttpGet("SetPaid/{id}")]
        public bool SetPaid(int id)
        {
            return (_service as INarudzbaService).SetPaid(id);
        }
    }
}
