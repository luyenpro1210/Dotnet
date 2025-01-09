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
    public class SlideshowController : ControllerBase
    {
        private readonly Exercise02Context _db;

        public SlideshowController(Exercise02Context db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Slideshow> Get()
        {
            return _db.Slideshows.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Slideshow> Get(Guid id)
        {
            var slideshow = _db.Slideshows.FirstOrDefault(e => e.Id == id);
            if (slideshow == null)
            {
                return NotFound();
            }
            return slideshow;
        }

        [HttpPost]
        public ActionResult<Slideshow> Post([FromBody] Slideshow slideshow)
        {
            _db.Slideshows.Add(slideshow);
            _db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = slideshow.Id }, slideshow);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Slideshow slideshow)
        {
            if (id != slideshow.Id)
            {
                return BadRequest();
            }

            _db.Entry(slideshow).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.Slideshows.Any(e => e.Id == id))
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
            var slideshow = _db.Slideshows.Find(id);
            if (slideshow == null)
            {
                return NotFound();
            }

            _db.Slideshows.Remove(slideshow);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
