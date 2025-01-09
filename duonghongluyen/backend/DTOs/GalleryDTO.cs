using System;

namespace duonghongluyen.Exercise02.DTOs
{
    public class GalleryDTO
    {
        public Guid? Id { get; set; }
        public Guid? ProductId { get; set; }

        public byte[]? Image { get; set; }

        public bool? IsThumbnail { get; set; }
    }
}
