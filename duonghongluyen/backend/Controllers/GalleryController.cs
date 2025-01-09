using duonghongluyen.Exercise02.Context;
using duonghongluyen.Exercise02.DTOs;
using duonghongluyen.Exercise02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace duonghongluyen.Exercise02.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GalleryController : ControllerBase
    {
        private readonly Exercise02Context _db;

        public GalleryController(Exercise02Context db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<GalleryDTO> Get()
        {
            var galleries = _db.Galleries.Select(g => new GalleryDTO
            {
                Id = g.Id,
                ProductId = g.ProductId,
                Image = g.Image, // Trả về byte array mà không cần chuyển đổi
                IsThumbnail = g.IsThumbnail
            }).ToList();

            return galleries;
        }

        [HttpGet("{id}")]
        public ActionResult<GalleryDTO> Get(Guid id)
        {
            var gallery = _db.Galleries.FirstOrDefault(e => e.Id == id);
            if (gallery == null)
            {
                return NotFound();
            }

            var galleryDTO = new GalleryDTO
            {
                Id = gallery.Id,
                ProductId = gallery.ProductId,
                Image = gallery.Image, // Trả về byte array mà không cần chuyển đổi
                IsThumbnail = gallery.IsThumbnail
            };

            return galleryDTO;
        }

        [HttpGet("by-product/{productId}")]
        public IEnumerable<GalleryDTO> GetByProductId(Guid productId)
        {
            var galleries = _db.Galleries
                .Where(g => g.ProductId == productId)
                .Select(g => new GalleryDTO
                {
                    ProductId = g.ProductId,
                    Image = g.Image, // Trả về byte array mà không cần chuyển đổi
                    IsThumbnail = g.IsThumbnail
                })
                .ToList();

            return galleries;
        }
        [HttpPost("multiple")]
        public IActionResult PostMultipleImages([FromForm] GalleryDTO galleryDTO, List<IFormFile> imageFiles)
        {
            if (imageFiles == null || imageFiles.Count == 0)
            {
                return BadRequest("Please upload at least one image file.");
            }

            foreach (var imageFile in imageFiles)
            {
                if (imageFile.Length == 0)
                {
                    return BadRequest("Uploaded image file is empty.");
                }

                if (imageFile.ContentType != "image/png" && imageFile.ContentType != "image/jpeg")
                {
                    return BadRequest("Please upload PNG or JPG image files only.");
                }

                using (var memoryStream = new MemoryStream())
                {
                    imageFile.CopyTo(memoryStream);
                    var imageData = memoryStream.ToArray();

                    var gallery = new Gallery
                    {
                        ProductId = galleryDTO.ProductId,
                        Image = imageData,
                        IsThumbnail = galleryDTO.IsThumbnail
                    };

                    _db.Galleries.Add(gallery);
                }
            }

            _db.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public ActionResult<GalleryDTO> Post([FromForm] GalleryDTO galleryDTO, IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                return BadRequest("Please upload an image file.");
            }

            if (imageFile.ContentType != "image/png" && imageFile.ContentType != "image/jpeg")
            {
                return BadRequest("Please upload a PNG or JPG image file.");
            }

            using (var memoryStream = new MemoryStream())
            {
                imageFile.CopyTo(memoryStream);
                var imageData = memoryStream.ToArray();

                var gallery = new Gallery
                {
                    ProductId = galleryDTO.ProductId,
                    Image = imageData,
                    IsThumbnail = galleryDTO.IsThumbnail
                };

                _db.Galleries.Add(gallery);
                _db.SaveChanges();

                return CreatedAtAction(nameof(Get), new { id = gallery.Id }, galleryDTO);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromForm] GalleryDTO galleryDTO, IFormFile imageFile)
        {
            var gallery = _db.Galleries.Find(id);
            if (gallery == null)
            {
                return NotFound();
            }

            if (imageFile != null && imageFile.Length > 0)
            {
                if (imageFile.ContentType != "image/png" && imageFile.ContentType != "image/jpeg")
                {
                    return BadRequest("Please upload a PNG or JPG image file.");
                }

                using (var memoryStream = new MemoryStream())
                {
                    imageFile.CopyTo(memoryStream);
                    var imageData = memoryStream.ToArray();
                    gallery.Image = imageData;
                }
            }

            gallery.ProductId = galleryDTO.ProductId;
            gallery.IsThumbnail = galleryDTO.IsThumbnail;

            _db.Entry(gallery).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.Galleries.Any(e => e.Id == id))
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
            var gallery = _db.Galleries.Find(id);
            if (gallery == null)
            {
                return NotFound();
            }

            _db.Galleries.Remove(gallery);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
