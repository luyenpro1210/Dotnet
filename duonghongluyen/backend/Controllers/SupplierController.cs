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
    public class SupplierController : ControllerBase
    {
        private readonly Exercise02Context _db;

        public SupplierController(Exercise02Context db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Supplier> Get()
        {
            return _db.Suppliers.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Supplier> Get(Guid id)
        {
            var supplier = _db.Suppliers.FirstOrDefault(e => e.Id == id);
            if (supplier == null)
            {
                return NotFound();
            }
            return supplier;
        }

        [HttpPost]
        public ActionResult<Supplier> Post([FromBody] Supplier supplier)
        {
            _db.Suppliers.Add(supplier);
            _db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = supplier.Id }, supplier);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Supplier supplier)
        {
            if (id != supplier.Id)
            {
                return BadRequest();
            }

            _db.Entry(supplier).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.Suppliers.Any(e => e.Id == id))
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
            var supplier = _db.Suppliers.Find(id);
            if (supplier == null)
            {
                return NotFound();
            }

            _db.Suppliers.Remove(supplier);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
