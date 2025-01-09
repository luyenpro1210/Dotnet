using duonghongluyen.Exercise02.Context;
using duonghongluyen.Exercise02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace duonghongluyen.Exercise02.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerAddressController : ControllerBase
    {
        private readonly Exercise02Context _db;

        public CustomerAddressController(Exercise02Context db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<CustomerAddress> Get()
        {
            return _db.CustomerAddresses.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerAddress> Get(Guid id)
        {
            var address = _db.CustomerAddresses.FirstOrDefault(e => e.Id == id);
            if (address == null)
            {
                return NotFound();
            }
            return address;
        }

        [HttpPost]
        public ActionResult<CustomerAddress> Post([FromBody] CustomerAddress address)
        {
            _db.CustomerAddresses.Add(address);
            _db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = address.Id }, address);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] CustomerAddress address)
        {
            if (id != address.Id)
            {
                return BadRequest();
            }

            _db.Entry(address).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.CustomerAddresses.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var address = _db.CustomerAddresses.Find(id);
            if (address == null)
            {
                return NotFound();
            }

            _db.CustomerAddresses.Remove(address);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
