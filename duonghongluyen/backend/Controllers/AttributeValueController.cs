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
    public class AttributeValueController : ControllerBase
    {
        private readonly Exercise02Context _db;

        public AttributeValueController(Exercise02Context db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<AttributeValue> Get()
        {
            return _db.AttributeValues.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<AttributeValue> Get(Guid id)
        {
            var attributeValue = _db.AttributeValues.FirstOrDefault(e => e.Id == id);
            if (attributeValue == null)
            {
                return NotFound();
            }
            return attributeValue;
        }

        [HttpPost]
        public ActionResult<AttributeValue> Post([FromBody] AttributeValue attributeValue)
        {
            _db.AttributeValues.Add(attributeValue);
            _db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = attributeValue.Id }, attributeValue);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] AttributeValue attributeValue)
        {
            if (id != attributeValue.Id)
            {
                return BadRequest();
            }

            _db.Entry(attributeValue).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.AttributeValues.Any(e => e.Id == id))
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
            var attributeValue = _db.AttributeValues.Find(id);
            if (attributeValue == null)
            {
                return NotFound();
            }

            _db.AttributeValues.Remove(attributeValue);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
