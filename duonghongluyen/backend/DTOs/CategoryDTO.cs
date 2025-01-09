using System;
using System.ComponentModel.DataAnnotations;

namespace duonghongluyen.Exercise02.DTOs
{
    public class CategoryUpsertDTO
    {

        public Guid? ParentId { get; set; }

        [Required(ErrorMessage = "CategoryName is required")]
        [MaxLength(255, ErrorMessage = "CategoryName length can't be more than 255 characters")]
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public string Icon { get; set; }


        public int? Placeholder { get; set; }

        public bool Active { get; set; } = true;

    }
    public class CategoryGetDTO
    {
        public Guid Id { get; set; }

        public Guid? ParentId { get; set; }

        public string? parentName { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public string Icon { get; set; }

        public byte[] Image { get; set; }

        public int? Placeholder { get; set; }

        public bool Active { get; set; }

    }
}
