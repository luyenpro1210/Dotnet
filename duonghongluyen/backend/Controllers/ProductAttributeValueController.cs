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
    public class ProductAttributeValueController : ControllerBase
    {
        private readonly Exercise02Context _db;

        public ProductAttributeValueController(Exercise02Context db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<ProductAttributeValue> Get()
        {
            return _db.ProductAttributeValues.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<ProductAttributeValue> Get(Guid id)
        {
            var productAttributeValue = _db.ProductAttributeValues.FirstOrDefault(e => e.Id == id);
            if (productAttributeValue == null)
            {
                return NotFound();
            }
            return productAttributeValue;
        }

        [HttpPost]
        public ActionResult<ProductAttributeValue> Post([FromBody] ProductAttributeValue productAttributeValue)
        {
            _db.ProductAttributeValues.Add(productAttributeValue);
            _db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = productAttributeValue.Id }, productAttributeValue);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ProductAttributeValue productAttributeValue)
        {
            if (id != productAttributeValue.Id)
            {
                return BadRequest();
            }

            _db.Entry(productAttributeValue).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.ProductAttributeValues.Any(e => e.Id == id))
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
            var productAttributeValue = _db.ProductAttributeValues.Find(id);
            if (productAttributeValue == null)
            {
                return NotFound();
            }

            _db.ProductAttributeValues.Remove(productAttributeValue);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
