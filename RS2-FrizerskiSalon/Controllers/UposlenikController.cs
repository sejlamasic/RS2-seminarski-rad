using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RS2_FrizerskiSalon.Services;
using System;
using System.Collections.Generic;
using FrizerskiSalon.Modal.Requests;
using FrizerskiSalon.Modal.SearchObjects;

namespace RS2_FrizerskiSalon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UposlenikController : ControllerBase
    {
        private readonly IUposlenikService _service;
        public UposlenikController(IUposlenikService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] UposlenikSearchObject request)
        {
            var headers = HttpContext.Request.Headers.ToList();
            try
            {
                return Ok(_service.Get(request));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] UserLoginModel userLogin)
        {
            var user = _service.Authenticate(userLogin);
            if (user == null)
            {
                return Unauthorized(new { message = "Pogrešno korisničko ime ili lozinka" });
            }
            return Ok(user);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_service.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Insert(UposlenikInsertRequest request)
        {
            try
            {
                return Ok(_service.Insert(request));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UposlenikInsertRequest request)
        {
            try
            {
                return Ok(_service.Update(id, request));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_service.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }
    }
}
