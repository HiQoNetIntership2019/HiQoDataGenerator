﻿using System.Collections.Generic;
using System.Linq;
using HiQoDataGenerator.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HiQoDataGenerator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConstraintsController : ControllerBase
    {
        private readonly IConstraintsService _constraintsService;

        public ConstraintsController(IConstraintsService constraintsService) => _constraintsService = constraintsService;

        [HttpGet]
        public IEnumerable<string> Get()
        {
            var constraints = _constraintsService.GetAll();
            return new string[] { constraints.Count().ToString() };
        }

        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}