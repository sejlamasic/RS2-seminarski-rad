﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RS2_FrizerskiSalon.Services;

namespace RS2_FrizerskiSalon.Controllers
{
    [Authorize]
    public class BaseCRUDController<T, TSearch, TInsert, TUpdate> : BaseReadController<T, TSearch> where T : class where TSearch : class where TInsert : class where TUpdate : class
    {
        protected readonly ICRUDService<T, TSearch, TInsert, TUpdate> _crudService;
        public BaseCRUDController(ICRUDService<T, TSearch, TInsert, TUpdate> service)
            : base(service)
        {
            _crudService = service;
        }

        [HttpPost]
        public T Insert([FromBody] TInsert request)
        {
            return _crudService.Insert(request);
        }

        [HttpPut("{id}")]
        public T Update(int id, [FromBody] TUpdate request)
        {
            return _crudService.Update(id, request);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _crudService.Delete(id);
        }

    }
}
