﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tibox.Models;
using Tibox.UnitOfWork;

namespace Tibox.WebApi.Controllers
{

    [RoutePrefix("customer")]
    [Authorize]
    public class CustomerController : BaseController
    {
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            if (id <= 0) return BadRequest();           
            return Ok(_unit.Customers.GetEntityById(id));
        }
        
        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var id = _unit.Customers.Insert(customer);
            return Ok(new { id = id});
        }
        
        [Route("")]
        [HttpPut]
        public IHttpActionResult Put(Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var id = _unit.Customers.Update(customer);
            return Ok(new { status = true });
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = _unit.Customers.Delete(new Customer { Id = id });
            return Ok(new { delete = true });
        }
        
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetList()
        {
            return Ok(_unit.Customers.GetAll());
        }

    }
}
