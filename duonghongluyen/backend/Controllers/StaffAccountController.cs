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
    public class StaffAccountController : ControllerBase
    {
        private readonly Exercise02Context _db;

        public StaffAccountController(Exercise02Context db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<StaffAccount> Get()
        {
            return _db.StaffAccounts.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<StaffAccount> Get(Guid id)
        {
            var staffAccount = _db.StaffAccounts.FirstOrDefault(e => e.Id == id);
            if (staffAccount == null)
            {
                return NotFound();
            }
            return staffAccount;
        }

        [HttpPost]
        public ActionResult<StaffAccount> Post([FromBody] StaffAccount staffAccount)
        {
            _db.StaffAccounts.Add(staffAccount);
            _db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = staffAccount.Id }, staffAccount);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] StaffAccount staffAccount)
        {
            if (id != staffAccount.Id)
            {
                return BadRequest();
            }

            _db.Entry(staffAccount).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.StaffAccounts.Any(e => e.Id == id))
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
            var staffAccount = _db.StaffAccounts.Find(id);
            if (staffAccount == null)
            {
                return NotFound();
            }

            _db.StaffAccounts.Remove(staffAccount);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
