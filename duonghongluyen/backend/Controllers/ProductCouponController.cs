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
    public class ProductCouponController : ControllerBase
    {
        private readonly Exercise02Context _db;

        public ProductCouponController(Exercise02Context db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<ProductCoupon> Get()
        {
            return _db.ProductCoupons.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<ProductCoupon> Get(Guid id)
        {
            var productCoupon = _db.ProductCoupons.FirstOrDefault(e => e.ProductId == id);
            if (productCoupon == null)
            {
                return NotFound();
            }
            return productCoupon;
        }

        [HttpPost]
        public ActionResult<ProductCoupon> Post([FromBody] ProductCoupon productCoupon)
        {
            _db.ProductCoupons.Add(productCoupon);
            _db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = productCoupon.ProductId }, productCoupon);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ProductCoupon productCoupon)
        {
            if (id != productCoupon.ProductId)
            {
                return BadRequest();
            }

            _db.Entry(productCoupon).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.ProductCoupons.Any(e => e.ProductId == id))
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
            var productCoupon = _db.ProductCoupons.Find(id);
            if (productCoupon == null)
            {
                return NotFound();
            }

            _db.ProductCoupons.Remove(productCoupon);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
