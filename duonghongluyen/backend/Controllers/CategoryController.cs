using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.EntityFrameworkCore;

using duonghongluyen.Exercise02.Models;
using duonghongluyen.Exercise02.DTOs;
using duonghongluyen.Exercise02.Context;

namespace duonghongluyen.Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public CategoriesController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public ActionResult<IEnumerable<CategoryGetDTO>> GetCategories()
        {
            var categories = _context.Categories.Select(c => new CategoryGetDTO
            {

                Id = c.Id,
                ParentId = c.ParentId,
                parentName = _context.Categories.FirstOrDefault(ct => ct.Id == c.ParentId).CategoryName,
                CategoryName = c.CategoryName,
                CategoryDescription = c.CategoryDescription,
                Icon = c.Icon,
                Image = c.Image,
                Placeholder = c.Placeholder,
                Active = c.Active,
            }).ToList();

            return categories;
        }

        // GET: api/Categories/Active
        [HttpGet("Active")]
        public ActionResult<IEnumerable<CategoryGetDTO>> GetActiveCategories()
        {
            var activeCategories = _context.Categories
                .Where(c => c.Active)
                 .Where(c => c.ParentId == null)
                .OrderBy(c => c.Placeholder)
                .Select(c => new CategoryGetDTO
                {
                    Id = c.Id,
                    ParentId = c.ParentId,
                    CategoryName = c.CategoryName,
                    CategoryDescription = c.CategoryDescription,
                    Icon = c.Icon,
                    Image = c.Image,
                    Placeholder = c.Placeholder,
                    Active = c.Active,
                })
                .ToList();

            return activeCategories;
        }
        // GET: api/Categories/{parentId}/Children
        [HttpGet("{parentId}/Children")]
        public ActionResult<IEnumerable<CategoryGetDTO>> GetChildrenCategories(Guid parentId)
        {
            var childrenCategories = _context.Categories
                .Where(c => c.Active)
                .Where(c => c.ParentId == parentId)
                .OrderBy(c => c.Placeholder) // Sắp xếp theo Placeholder
                .Select(c => new CategoryGetDTO
                {
                    Id = c.Id,
                    ParentId = c.ParentId,
                    CategoryName = c.CategoryName,
                    CategoryDescription = c.CategoryDescription,
                    Icon = c.Icon,
                    Image = c.Image,
                    Placeholder = c.Placeholder,
                    Active = c.Active,
                })
                .ToList();

            return childrenCategories;
        }
        // GET: api/Categories/5
        [HttpGet("{id}")]
        public ActionResult<CategoryGetDTO> GetCategory(Guid id)
        {
            var category = _context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            var categoryDTO = new CategoryGetDTO
            {
                Id = category.Id,
                ParentId = category.ParentId,
                CategoryName = category.CategoryName,
                CategoryDescription = category.CategoryDescription,
                Icon = category.Icon,
                Image = category.Image,
                Placeholder = category.Placeholder,
                Active = category.Active,
            };

            return categoryDTO;
        }

        // POST: api/Categories
        [HttpPost]
        public ActionResult<Category> PostCategory([FromForm] CategoryUpsertDTO categoryDTO, IFormFile svgFile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Kiểm tra xem có file SVG được gửi lên không
            if (svgFile == null || svgFile.Length == 0)
            {
                return BadRequest("Please upload an SVG file.");
            }

            // Đảm bảo file được gửi lên là file SVG
            if (svgFile.ContentType != "image/svg+xml")
            {
                return BadRequest("Please upload an SVG file.");
            }

            // Đọc dữ liệu của file SVG và lưu vào biến imageData
            using (var memoryStream = new MemoryStream())
            {
                svgFile.CopyTo(memoryStream);
                var imageData = memoryStream.ToArray();

                // Tạo đối tượng Category từ dữ liệu DTO
                var category = new Category
                {
                    ParentId = categoryDTO.ParentId,
                    CategoryName = categoryDTO.CategoryName,
                    CategoryDescription = categoryDTO.CategoryDescription,
                    Icon = categoryDTO.Icon,
                    Placeholder = categoryDTO.Placeholder,
                    Active = categoryDTO.Active,
                };

                // Lưu hình ảnh SVG vào trường Image của category
                category.Image = imageData;

                // Thêm category vào database và lưu thay đổi
                _context.Categories.Add(category);
                _context.SaveChanges();

                // Trả về kết quả thành công với category vừa được tạo
                return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
            }
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public IActionResult PutCategory(Guid id, [FromForm] CategoryUpsertDTO categoryDTO, IFormFile svgFile)
        {
            // Kiểm tra xem category có tồn tại không
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            // Kiểm tra và cập nhật thông tin của category từ DTO
            category.ParentId = categoryDTO.ParentId;
            category.CategoryName = categoryDTO.CategoryName;
            category.CategoryDescription = categoryDTO.CategoryDescription;
            category.Icon = categoryDTO.Icon;
            category.Placeholder = categoryDTO.Placeholder;
            category.Active = categoryDTO.Active;
            category.UpdatedAt = DateTimeOffset.Now; // Cập nhật thời gian sửa đổi

            // Nếu có file SVG được gửi lên, cập nhật hình ảnh
            if (svgFile != null && svgFile.Length > 0)
            {
                // Kiểm tra xem file là file SVG
                if (svgFile.ContentType != "image/svg+xml")
                {
                    return BadRequest("Please upload an SVG file.");
                }

                // Đọc dữ liệu của file và lưu vào biến imageData
                using (var memoryStream = new MemoryStream())
                {
                    svgFile.CopyTo(memoryStream);
                    var imageData = memoryStream.ToArray();

                    // Lưu hình ảnh vào trường Image của category
                    category.Image = imageData;
                }
            }

            // Cập nhật category vào database
            _context.Entry(category).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return NoContent();
        }


        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public ActionResult<Category> DeleteCategory(Guid id)
        {
            var category = _context.Categories.Include(p => p.ProductCategories).FirstOrDefault(e => e.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _context.ProductCategories.RemoveRange(category.ProductCategories);
            _context.Categories.RemoveRange(category);
            _context.SaveChanges();

            return category;
        }
    }
}
