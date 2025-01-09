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
    public class CountryController : ControllerBase
    {
        private readonly Exercise02Context _db;

        public CountryController(Exercise02Context db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Country> Get()
        {
            return _db.Countries.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Country> Get(int id)
        {
            var country = _db.Countries.FirstOrDefault(e => e.Id == id);
            if (country == null)
            {
                return NotFound();
            }
            return country;
        }

        [HttpPost]
        public ActionResult<Country> Post([FromBody] Country country)
        {
            _db.Countries.Add(country);
            _db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = country.Id }, country);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Country country)
        {
            if (id != country.Id)
            {
                return BadRequest();
            }

            _db.Entry(country).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.Countries.Any(e => e.Id == id))
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
        public IActionResult Delete(int id)
        {
            var country = _db.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }

            _db.Countries.Remove(country);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
