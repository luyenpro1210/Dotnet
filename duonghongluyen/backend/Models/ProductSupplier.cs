using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace duonghongluyen.Exercise02.Models
{
    [Table("product_supplier")] // Tên bảng trung gian
    public class ProductSupplier
    {
        [Column("product_id")]
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Column("supplier_id")]
        [ForeignKey("Supplier")]
        public Guid SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
