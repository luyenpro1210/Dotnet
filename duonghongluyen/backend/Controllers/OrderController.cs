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
    public class OrderController : ControllerBase
    {
        private readonly Exercise02Context _db;

        public OrderController(Exercise02Context db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _db.Orders.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Order> Get(string id)
        {
            var order = _db.Orders.FirstOrDefault(e => e.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        [HttpPost]
        public ActionResult<Order> Post([FromBody] Order order)
        {
            _db.Orders.Add(order);
            _db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            _db.Entry(order).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.Orders.Any(e => e.Id == id))
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
        public IActionResult Delete(string id)
        {
            var order = _db.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            _db.Orders.Remove(order);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
