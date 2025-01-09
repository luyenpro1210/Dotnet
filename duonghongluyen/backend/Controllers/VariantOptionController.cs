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
    public class VariantOptionController : ControllerBase
    {
        private readonly Exercise02Context _db;

        public VariantOptionController(Exercise02Context db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<VariantOption> Get()
        {
            return _db.VariantOptions.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<VariantOption> Get(Guid id)
        {
            var variantOption = _db.VariantOptions.FirstOrDefault(e => e.Id == id);
            if (variantOption == null)
            {
                return NotFound();
            }
            return variantOption;
        }

        [HttpPost]
        public ActionResult<VariantOption> Post([FromBody] VariantOption variantOption)
        {
            _db.VariantOptions.Add(variantOption);
            _db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = variantOption.Id }, variantOption);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] VariantOption variantOption)
        {
            if (id != variantOption.Id)
            {
                return BadRequest();
            }

            _db.Entry(variantOption).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.VariantOptions.Any(e => e.Id == id))
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
            var variantOption = _db.VariantOptions.Find(id);
            if (variantOption == null)
            {
                return NotFound();
            }

            _db.VariantOptions.Remove(variantOption);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
