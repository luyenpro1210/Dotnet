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
    public class NotificationController : ControllerBase
    {
        private readonly Exercise02Context _db;

        public NotificationController(Exercise02Context db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Notification> Get()
        {
            return _db.Notifications.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Notification> Get(Guid id)
        {
            var notification = _db.Notifications.FirstOrDefault(e => e.Id == id);
            if (notification == null)
            {
                return NotFound();
            }
            return notification;
        }

        [HttpPost]
        public ActionResult<Notification> Post([FromBody] Notification notification)
        {
            _db.Notifications.Add(notification);
            _db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = notification.Id }, notification);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Notification notification)
        {
            if (id != notification.Id)
            {
                return BadRequest();
            }

            _db.Entry(notification).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.Notifications.Any(e => e.Id == id))
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
            var notification = _db.Notifications.Find(id);
            if (notification == null)
            {
                return NotFound();
            }

            _db.Notifications.Remove(notification);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
