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
    public class ProductSupplierController : ControllerBase
    {
        private readonly Exercise02Context _db;

        public ProductSupplierController(Exercise02Context db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<ProductSupplier> Get()
        {
            return _db.ProductSuppliers.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<ProductSupplier> Get(Guid id)
        {
            var productSupplier = _db.ProductSuppliers.FirstOrDefault(e => e.ProductId == id);
            if (productSupplier == null)
            {
                return NotFound();
            }
            return productSupplier;
        }

        [HttpPost]
        public ActionResult<ProductSupplier> Post([FromBody] ProductSupplier productSupplier)
        {
            _db.ProductSuppliers.Add(productSupplier);
            _db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = productSupplier.ProductId }, productSupplier);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ProductSupplier productSupplier)
        {
            if (id != productSupplier.ProductId)
            {
                return BadRequest();
            }

            _db.Entry(productSupplier).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.ProductSuppliers.Any(e => e.ProductId == id))
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
            var productSupplier = _db.ProductSuppliers.Find(id);
            if (productSupplier == null)
            {
                return NotFound();
            }

            _db.ProductSuppliers.Remove(productSupplier);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
