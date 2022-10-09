﻿using Microsoft.AspNetCore.Mvc;
using CoffeeShop.Models;
using CoffeeShop.Repositories;

namespace CoffeeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private readonly ICoffeeRepository _coffeeRepository;
        public CoffeeController(ICoffeeRepository coffeeRepository)
        {
            _coffeeRepository = coffeeRepository;
        }

        // GET: api/<CoffeeController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_coffeeRepository.GetAll());
        }

        // GET api/<CoffeeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_coffeeRepository.GetById(id));
        }

        // POST api/<CoffeeController>
        [HttpPost]
        public IActionResult Post(Coffee coffee)
        {
            _coffeeRepository.Add(coffee);
            return CreatedAtAction("Get", new { id = coffee.Id }, coffee);
        }

        // PUT api/<CoffeeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Coffee coffee)
        {
            if (id != coffee.Id)
            {
                return BadRequest();
            }
            _coffeeRepository.Update(coffee);
            return NoContent();
        }

        // DELETE api/<CoffeeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _coffeeRepository.Delete(id);
            return NoContent();
        }
    }
}