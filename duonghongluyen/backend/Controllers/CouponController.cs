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
    public class CouponController : ControllerBase
    {
        private readonly Exercise02Context _db;

        public CouponController(Exercise02Context db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Coupon> Get()
        {
            return _db.Coupons.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Coupon> Get(Guid id)
        {
            var coupon = _db.Coupons.FirstOrDefault(e => e.Id == id);
            if (coupon == null)
            {
                return NotFound();
            }
            return coupon;
        }

        [HttpPost]
        public ActionResult<Coupon> Post([FromBody] Coupon coupon)
        {
            _db.Coupons.Add(coupon);
            _db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = coupon.Id }, coupon);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Coupon coupon)
        {
            if (id != coupon.Id)
            {
                return BadRequest();
            }

            _db.Entry(coupon).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.Coupons.Any(e => e.Id == id))
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
            var coupon = _db.Coupons.Find(id);
            if (coupon == null)
            {
                return NotFound();
            }

            _db.Coupons.Remove(coupon);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
