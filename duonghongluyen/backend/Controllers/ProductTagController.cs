using duonghongluyen.Exercise02.Context;
using duonghongluyen.Exercise02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Exercise02.DTOs;

namespace duonghongluyen.Exercise02.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductTagController : ControllerBase
    {
        private readonly Exercise02Context _db;

        public ProductTagController(Exercise02Context db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<ProductTag> Get()
        {
            return _db.ProductTags.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<ProductTag> Get(Guid id)
        {
            var productTag = _db.ProductTags.FirstOrDefault(e => e.TagId == id);
            if (productTag == null)
            {
                return NotFound();
            }
            return productTag;
        }

        [HttpPost]
        public ActionResult<ProductTag> Post([FromBody] ProductTagDto productTagDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = new ProductTag
            {
                TagId = productTagDto.TagId,
                ProductId = productTagDto.ProductId,
            };

            _db.ProductTags.Add(item);
            _db.SaveChanges();

            return CreatedAtAction(nameof(Get), productTagDto);
        }

        [HttpPut("{tagId}/{productId}")]
        public IActionResult Put(Guid tagId, Guid productId, [FromBody] ProductTagDto productTagDto)
        {
            var producttag = _db.ProductTags.FirstOrDefault(pt => pt.TagId == tagId && pt.ProductId == productId);

            // Nếu không tìm thấy ProductTag, trả về NotFound
            if (productTagDto == null)
            {
                return NotFound();
            }

            // Cập nhật thông tin của ProductTag từ dữ liệu nhận được từ body request
            producttag.TagId = productTagDto.TagId;
            producttag.ProductId = productId;

            // Lưu các thay đổi vào cơ sở dữ liệu
            _db.SaveChanges();

            // Trả về kết quả thành công
            return CreatedAtAction(nameof(Get), productTagDto);
        }

        [HttpDelete("{tagId}/{productId}")]
        public IActionResult Delete(Guid tagId, Guid productId)
        {
            var productTag = _db.ProductTags.FirstOrDefault(pt => pt.TagId == tagId && pt.ProductId == productId);
            if (productTag == null)
            {
                return NotFound();
            }

            _db.ProductTags.Remove(productTag);
            _db.SaveChanges();

            return NoContent();
        }
        [HttpGet("tag/{tagName}")]
        public IEnumerable<ProductTagGetAll> GetByTagName(string tagName)
        {
            // Truy vấn cơ sở dữ liệu để lấy tất cả các ProductTag có liên quan đến tagName
            var productTags = _db.ProductTags
                .Where(pt => pt.Tag.TagName == tagName) // Giả sử Tag có một thuộc tính Name
                .Include(pt => pt.Product)
                .Include(pt => pt.Tag)
                .Select(pt => new ProductTagGetAll
                {
                    Product = pt.Product,
                    Tag = pt.Tag
                })
                .ToList();

            return productTags;
        }

    }
}
