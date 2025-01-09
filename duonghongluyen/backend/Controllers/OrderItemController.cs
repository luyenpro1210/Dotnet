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
    public class OrderItemController : ControllerBase
    {
        private readonly Exercise02Context _db;

        public OrderItemController(Exercise02Context db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<OrderItem> Get()
        {
            return _db.OrderItems.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<OrderItem> Get(Guid id)
        {
            var orderItem = _db.OrderItems.FirstOrDefault(e => e.Id == id);
            if (orderItem == null)
            {
                return NotFound();
            }
            return orderItem;
        }

        [HttpPost]
        public ActionResult<OrderItem> Post([FromBody] OrderItem orderItem)
        {
            _db.OrderItems.Add(orderItem);
            _db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = orderItem.Id }, orderItem);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] OrderItem orderItem)
        {
            if (id != orderItem.Id)
            {
                return BadRequest();
            }

            _db.Entry(orderItem).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.OrderItems.Any(e => e.Id == id))
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
            var orderItem = _db.OrderItems.Find(id);
            if (orderItem == null)
            {
                return NotFound();
            }

            _db.OrderItems.Remove(orderItem);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
