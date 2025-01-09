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
    public class RoleController : ControllerBase
    {
        private readonly Exercise02Context _db;

        public RoleController(Exercise02Context db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Role> Get()
        {
            return _db.Roles.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Role> Get(int id)
        {
            var role = _db.Roles.FirstOrDefault(e => e.Id == id);
            if (role == null)
            {
                return NotFound();
            }
            return role;
        }

        [HttpPost]
        public ActionResult<Role> Post([FromBody] Role role)
        {
            _db.Roles.Add(role);
            _db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = role.Id }, role);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Role role)
        {
            if (id != role.Id)
            {
                return BadRequest();
            }

            _db.Entry(role).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.Roles.Any(e => e.Id == id))
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
            var role = _db.Roles.Find(id);
            if (role == null)
            {
                return NotFound();
            }

            _db.Roles.Remove(role);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
