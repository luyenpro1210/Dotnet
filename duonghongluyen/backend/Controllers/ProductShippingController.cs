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
    public class ProductShippingController : ControllerBase
    {
        private readonly Exercise02Context _db;

        public ProductShippingController(Exercise02Context db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<ProductShipping> Get()
        {
            return _db.ProductShippings.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<ProductShipping> Get(Guid id)
        {
            var productShipping = _db.ProductShippings.FirstOrDefault(e => e.Id == id);
            if (productShipping == null)
            {
                return NotFound();
            }
            return productShipping;
        }

        [HttpPost]
        public ActionResult<ProductShipping> Post([FromBody] ProductShipping productShipping)
        {
            _db.ProductShippings.Add(productShipping);
            _db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = productShipping.Id }, productShipping);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ProductShipping productShipping)
        {
            if (id != productShipping.Id)
            {
                return BadRequest();
            }

            _db.Entry(productShipping).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.ProductShippings.Any(e => e.Id == id))
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
            var productShipping = _db.ProductShippings.Find(id);
            if (productShipping == null)
            {
                return NotFound();
            }

            _db.ProductShippings.Remove(productShipping);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
