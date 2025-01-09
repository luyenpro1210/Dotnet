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
    public class VariantController : ControllerBase
    {
        private readonly Exercise02Context _db;

        public VariantController(Exercise02Context db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Variant> Get()
        {
            return _db.Variants.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Variant> Get(Guid id)
        {
            var variant = _db.Variants.FirstOrDefault(e => e.Id == id);
            if (variant == null)
            {
                return NotFound();
            }
            return variant;
        }

        [HttpPost]
        public ActionResult<Variant> Post([FromBody] Variant variant)
        {
            _db.Variants.Add(variant);
            _db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = variant.Id }, variant);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Variant variant)
        {
            if (id != variant.Id)
            {
                return BadRequest();
            }

            _db.Entry(variant).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.Variants.Any(e => e.Id == id))
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
            var variant = _db.Variants.Find(id);
            if (variant == null)
            {
                return NotFound();
            }

            _db.Variants.Remove(variant);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
