using duonghongluyen.Exercise02.Context;
using duonghongluyen.Exercise02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Exercise02.DTOs;
using duonghongluyen.Exercise02.DTOs;

namespace duonghongluyen.Exercise02.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
    {
        private readonly Exercise02Context _db;

        public TagController(Exercise02Context db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Tag> Get()
        {
            return _db.Tags.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Tag> Get(Guid id)
        {
            var tag = _db.Tags.FirstOrDefault(e => e.Id == id);
            if (tag == null)
            {
                return NotFound();
            }
            return tag;
        }
        [HttpGet("name/{tagName}")]
        public ActionResult<Tag> Get(string tagName)
        {
            var tag = _db.Tags.FirstOrDefault(e => e.TagName == tagName);
            if (tag == null)
            {
                return NotFound();
            }
            return tag;
        }
        [HttpPost]
        public ActionResult<Tag> Post([FromBody] TagDto tagDto)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tag = new Tag
            {
                TagName = tagDto.TagName,

                Icon = tagDto.Icon
            };

            _db.Tags.Add(tag);
            _db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = tag.Id }, tagDto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Tag tag)
        {
            if (id != tag.Id)
            {
                return BadRequest();
            }

            _db.Entry(tag).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.Tags.Any(e => e.Id == id))
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
            var tag = _db.Tags.Find(id);
            if (tag == null)
            {
                return NotFound();
            }

            _db.Tags.Remove(tag);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
