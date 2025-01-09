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
    public class ProductCategoryController : ControllerBase
    {
        private readonly Exercise02Context _db;

        public ProductCategoryController(Exercise02Context db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<ProductCategory> Get()
        {
            return _db.ProductCategories.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<ProductCategory> Get(Guid id)
        {
            var productCategory = _db.ProductCategories.FirstOrDefault(e => e.ProductId == id);
            if (productCategory == null)
            {
                return NotFound();
            }
            return productCategory;
        }

        [HttpPost]
        public ActionResult<ProductCategory> Post([FromBody] ProductCategory productCategory)
        {
            _db.ProductCategories.Add(productCategory);
            _db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = productCategory.ProductId }, productCategory);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ProductCategory productCategory)
        {
            if (id != productCategory.ProductId)
            {
                return BadRequest();
            }

            _db.Entry(productCategory).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.ProductCategories.Any(e => e.ProductId == id))
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
            var productCategory = _db.ProductCategories.Find(id);
            if (productCategory == null)
            {
                return NotFound();
            }

            _db.ProductCategories.Remove(productCategory);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
