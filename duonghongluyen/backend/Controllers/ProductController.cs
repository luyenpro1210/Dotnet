using duonghongluyen.Exercise02.Context;
using duonghongluyen.Exercise02.DTOs;
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
    public class ProductController : ControllerBase
    {
        private readonly Exercise02Context _db;

        public ProductController(Exercise02Context db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<ProductDTO> Get()
        {
            var products = _db.Products
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category) // Kết hợp với thông tin từ bảng Category
                .OrderByDescending(p => p.CreatedAt)
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    SalePrice = p.SalePrice,
                    BuyingPrice = p.BuyingPrice,
                    ProductCategoryIds = p.ProductCategories.Select(pc => pc.CategoryId).ToList(),
                    ProductCategoryNames = p.ProductCategories.Select(pc => pc.Category.CategoryName).ToList() // Lấy ra tên các danh mục sản phẩm
                }).ToList();

            return products;
        }
        [HttpGet("Tag/{tagName}")]
        public IEnumerable<ProductDTO> Get(string tagName)
        {
            var products = _db.Products
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .Include(P => P.ProductTags)
                .ThenInclude(pt => pt.Tag)
                .Where(p => p.ProductTags.Any(pt => pt.Tag.TagName == tagName))
                .OrderByDescending(p => p.CreatedAt)
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    SalePrice = p.SalePrice,
                    BuyingPrice = p.BuyingPrice,
                    ProductCategoryIds = p.ProductCategories.Select(pc => pc.CategoryId).ToList(),
                    ProductCategoryNames = p.ProductCategories.Select(pc => pc.Category.CategoryName).ToList() // Lấy ra tên các danh mục sản phẩm
                }).ToList();

            return products;
        }
        [HttpGet("{id}")]
        public ActionResult<ProductDTO> Get(Guid id)
        {
            var product = _db.Products
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category) // Kết hợp với thông tin từ bảng Category
                .FirstOrDefault(e => e.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            var productDTO = new ProductDTO
            {
                Id = product.Id,
                ProductName = product.ProductName,
                SalePrice = product.SalePrice,
                BuyingPrice = product.BuyingPrice,
                ProductCategoryIds = product.ProductCategories.Select(pc => pc.CategoryId).ToList(),
                ProductCategoryNames = product.ProductCategories.Select(pc => pc.Category.CategoryName).ToList() // Lấy ra tên các danh mục sản phẩm
            };

            return productDTO;
        }


        [HttpPost]
        public ActionResult<ProductDTO> Post([FromBody] ProductDTO productDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = new Product
            {
                ProductName = productDTO.ProductName,
                SalePrice = productDTO.SalePrice,
                BuyingPrice = productDTO.BuyingPrice,
                CreatedAt = DateTime.Now,
            };

            _db.Products.Add(product);
            _db.SaveChanges();

            foreach (var categoryId in productDTO.ProductCategoryIds)
            {
                var category = _db.Categories.Find(categoryId);
                if (category != null)
                {
                    var productCategory = new ProductCategory
                    {
                        CategoryId = categoryId,
                        ProductId = product.Id // Sử dụng product.Id được tạo trước đó
                    };

                    _db.ProductCategories.Add(productCategory);
                }
                else
                {
                    return BadRequest($"Category with id {categoryId} does not exist.");
                }
            }

            _db.SaveChanges(); // Lưu các product categories vào cơ sở dữ liệu

            return CreatedAtAction(nameof(Get), new { id = product.Id }, productDTO);
        }



        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = _db.Products
                .Include(p => p.ProductCategories)
                .FirstOrDefault(e => e.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            product.ProductName = productDTO.ProductName;
            product.SalePrice = productDTO.SalePrice;
            product.BuyingPrice = productDTO.BuyingPrice;

            // Xóa tất cả các danh mục sản phẩm hiện có của sản phẩm
            product.ProductCategories.Clear();

            // Thêm các danh mục sản phẩm mới từ DTO vào sản phẩm
            foreach (var categoryId in productDTO.ProductCategoryIds)
            {
                var category = _db.Categories.Find(categoryId);
                if (category != null)
                {
                    var productCategory = new ProductCategory
                    {
                        CategoryId = categoryId,
                        ProductId = product.Id
                    };
                    product.ProductCategories.Add(productCategory);
                }
                else
                {
                    return BadRequest($"Category with id {categoryId} does not exist.");
                }
            }

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.Products.Any(e => e.Id == id))
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
            var product = _db.Products
                  .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .Include(P => P.ProductTags)
                .ThenInclude(pt => pt.Tag)
                .Include(p => p.Galleries)
                .FirstOrDefault(e => e.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            // Xóa tất cả các danh mục sản phẩm liên quan đến sản phẩm
            _db.ProductCategories.RemoveRange(product.ProductCategories);
            _db.Galleries.RemoveRange(product.Galleries);
            _db.ProductTags.RemoveRange(product.ProductTags);
            // Xóa sản phẩm
            _db.Products.Remove(product);
            _db.SaveChanges();

            return NoContent();
        }

    }
}
