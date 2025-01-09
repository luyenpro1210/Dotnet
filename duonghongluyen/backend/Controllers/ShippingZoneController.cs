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
    public class ShippingZoneController : ControllerBase
    {
        private readonly Exercise02Context _db;

        public ShippingZoneController(Exercise02Context db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<ShippingZone> Get()
        {
            return _db.ShippingZones.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<ShippingZone> Get(int id)
        {
            var shippingZone = _db.ShippingZones.FirstOrDefault(e => e.Id == id);
            if (shippingZone == null)
            {
                return NotFound();
            }
            return shippingZone;
        }

        [HttpPost]
        public ActionResult<ShippingZone> Post([FromBody] ShippingZone shippingZone)
        {
            _db.ShippingZones.Add(shippingZone);
            _db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = shippingZone.Id }, shippingZone);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ShippingZone shippingZone)
        {
            if (id != shippingZone.Id)
            {
                return BadRequest();
            }

            _db.Entry(shippingZone).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.ShippingZones.Any(e => e.Id == id))
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
        public IActionResult Delete(int id)
        {
            var shippingZone = _db.ShippingZones.Find(id);
            if (shippingZone == null)
            {
                return NotFound();
            }

            _db.ShippingZones.Remove(shippingZone);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
