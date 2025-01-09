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
    public class ProductAttributeController : ControllerBase
    {
        private readonly Exercise02Context _db;

        public ProductAttributeController(Exercise02Context db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<ProductAttribute> Get()
        {
            return _db.ProductAttributes.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<ProductAttribute> Get(Guid id)
        {
            var productAttribute = _db.ProductAttributes.FirstOrDefault(e => e.ProductId == id);
            if (productAttribute == null)
            {
                return NotFound();
            }
            return productAttribute;
        }

        [HttpPost]
        public ActionResult<ProductAttribute> Post([FromBody] ProductAttribute productAttribute)
        {
            _db.ProductAttributes.Add(productAttribute);
            _db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = productAttribute.ProductId }, productAttribute);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ProductAttribute productAttribute)
        {
            if (id != productAttribute.ProductId)
            {
                return BadRequest();
            }

            _db.Entry(productAttribute).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.ProductAttributes.Any(e => e.ProductId == id))
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
            var productAttribute = _db.ProductAttributes.Find(id);
            if (productAttribute == null)
            {
                return NotFound();
            }

            _db.ProductAttributes.Remove(productAttribute);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
