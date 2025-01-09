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
    public class ShippingZoneCountryController : ControllerBase
    {
        private readonly Exercise02Context _db;

        public ShippingZoneCountryController(Exercise02Context db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<ShippingZoneCountry> Get()
        {
            return _db.ShippingZoneCountries.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<ShippingZoneCountry> Get(Guid id)
        {
            var shippingZoneCountry = _db.ShippingZoneCountries.FirstOrDefault(e => e.Id == id);
            if (shippingZoneCountry == null)
            {
                return NotFound();
            }
            return shippingZoneCountry;
        }

        [HttpPost]
        public ActionResult<ShippingZoneCountry> Post([FromBody] ShippingZoneCountry shippingZoneCountry)
        {
            _db.ShippingZoneCountries.Add(shippingZoneCountry);
            _db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = shippingZoneCountry.Id }, shippingZoneCountry);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ShippingZoneCountry shippingZoneCountry)
        {
            if (id != shippingZoneCountry.Id)
            {
                return BadRequest();
            }

            _db.Entry(shippingZoneCountry).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.ShippingZoneCountries.Any(e => e.Id == id))
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
            var shippingZoneCountry = _db.ShippingZoneCountries.Find(id);
            if (shippingZoneCountry == null)
            {
                return NotFound();
            }

            _db.ShippingZoneCountries.Remove(shippingZoneCountry);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
