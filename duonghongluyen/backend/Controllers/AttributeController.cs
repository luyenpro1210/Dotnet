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
    public class AttributeController : ControllerBase
    {
        private readonly Exercise02Context _db;

        public AttributeController(Exercise02Context db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<duonghongluyen.Exercise02.Models.Attribute> Get()
        {
            return _db.Attributes.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<duonghongluyen.Exercise02.Models.Attribute> Get(Guid id)
        {
            var attribute = _db.Attributes.FirstOrDefault(e => e.Id == id);
            if (attribute == null)
            {
                return NotFound();
            }
            return attribute;
        }

        [HttpPost]
        public ActionResult<duonghongluyen.Exercise02.Models.Attribute> Post([FromBody] duonghongluyen.Exercise02.Models.Attribute attribute)
        {
            _db.Attributes.Add(attribute);
            _db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = attribute.Id }, attribute);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] duonghongluyen.Exercise02.Models.Attribute attribute)
        {
            if (id != attribute.Id)
            {
                return BadRequest();
            }

            _db.Entry(attribute).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.Attributes.Any(e => e.Id == id))
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
            var attribute = _db.Attributes.Find(id);
            if (attribute == null)
            {
                return NotFound();
            }

            _db.Attributes.Remove(attribute);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
