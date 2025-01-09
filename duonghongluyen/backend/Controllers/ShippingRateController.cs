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
    public class ShippingRateController : ControllerBase
    {
        private readonly Exercise02Context _db;

        public ShippingRateController(Exercise02Context db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<ShippingRate> Get()
        {
            return _db.ShippingRates.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<ShippingRate> Get(Guid id)
        {
            var shippingRate = _db.ShippingRates.FirstOrDefault(e => e.Id == id);
            if (shippingRate == null)
            {
                return NotFound();
            }
            return shippingRate;
        }

        [HttpPost]
        public ActionResult<ShippingRate> Post([FromBody] ShippingRate shippingRate)
        {
            _db.ShippingRates.Add(shippingRate);
            _db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = shippingRate.Id }, shippingRate);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ShippingRate shippingRate)
        {
            if (id != shippingRate.Id)
            {
                return BadRequest();
            }

            _db.Entry(shippingRate).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.ShippingRates.Any(e => e.Id == id))
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
            var shippingRate = _db.ShippingRates.Find(id);
            if (shippingRate == null)
            {
                return NotFound();
            }

            _db.ShippingRates.Remove(shippingRate);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
