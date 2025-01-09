using System;
using System.Linq;
using duonghongluyen.Exercise02.Models;
using Microsoft.EntityFrameworkCore;

namespace duonghongluyen.Exercise02.Context
{
    public class Exercise02Context : DbContext
    {
        public Exercise02Context()
        {
        }

        public Exercise02Context(DbContextOptions<Exercise02Context> options) : base(options)
        {
        }

        // DbSet cho các thực thể
        public DbSet<Product> Products { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Sell> Sells { get; set; }
        public DbSet<CardItem> CardItems { get; set; }
        public DbSet<ProductShipping> ProductShippings { get; set; }

        public DbSet<ProductCoupon> ProductCoupons { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<StaffAccount> StaffAccounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Slideshow> Slideshows { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<Card> Cards { get; set; }


        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Tag> Tags { get; set; } // Thêm DbSet cho thực thể Tag
        public DbSet<ProductTag> ProductTags { get; set; } // Thêm DbSet cho thực thể ProductTag
        public DbSet<ProductAttribute> ProductAttributes { get; set; } // Thêm DbSet cho thực thể ProductAttribute
        public DbSet<AttributeValue> AttributeValues { get; set; } // Thêm DbSet cho thực thể AttributeValue
        public DbSet<duonghongluyen.Exercise02.Models.Attribute> Attributes { get; set; } // Thêm DbSet cho thực thể Attribute
        public DbSet<Variant> Variants { get; set; }
        // public DbSet<duonghongluyen.Exercise02.Models.VariantAttributeValue> VariantAttributeValues { get; set; }

        ///ccccccccccccccccccccccccccccccc
        public DbSet<VariantOption> VariantOptions { get; set; }
        public DbSet<ShippingZone> ShippingZones { get; set; }
        public DbSet<ShippingRate> ShippingRates { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ProductSupplier> ProductSuppliers { get; set; }
        public DbSet<ShippingZoneCountry> ShippingZoneCountrys { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }
        public DbSet<ShippingZoneCountry> ShippingZoneCountries { get; set; }





        // Phương thức cấu hình quan hệ giữa các thực thể
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProductAttributeValue>()
    .HasOne(pav => pav.ProductAttribute)
    .WithMany()
    .HasForeignKey(pav => pav.ProductAttributeId)
    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProductAttributeValue>()
                .HasOne(pav => pav.AttributeValue)
                .WithMany()
                .HasForeignKey(pav => pav.AttributeValueId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ProductSupplier>()
               .HasKey(ps => new { ps.ProductId, ps.SupplierId });





            modelBuilder.Entity<OrderItem>()
              .HasOne(g => g.Product)
              .WithMany(p => p.OrderItems)
              .HasForeignKey(g => g.ProductId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductCoupon>()
                           .HasKey(pc => new { pc.CouponId, pc.ProductId });

            modelBuilder.Entity<ProductCoupon>()
               .HasOne(g => g.Coupon)
               .WithMany(p => p.ProductCoupons)
               .HasForeignKey(g => g.CouponId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductCoupon>()
               .HasOne(g => g.Product)
               .WithMany(p => p.ProductCoupons)
               .HasForeignKey(g => g.ProductId)
               .OnDelete(DeleteBehavior.Restrict);

            //   modelBuilder.Entity<ProductShipping>()
            // .HasKey(pc => new { pc.ShippingId, pc.ProductId });

            // modelBuilder.Entity<ProductShipping>()
            //     .HasOne(g => g.Product)
            //     .WithMany(p => p.ProductShippings)
            //     .HasForeignKey(g => g.ProductId)
            //     .OnDelete(DeleteBehavior.Restrict);

            //      modelBuilder.Entity<ProductShipping>()
            //     .HasOne(g => g.Shipping)
            //     .WithMany(p => p.ProductShippings)
            //     .HasForeignKey(g => g.ShippingId)
            //     .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<CardItem>()
               .HasOne(g => g.Product)
               .WithMany(p => p.CardItems)
               .HasForeignKey(g => g.ProductId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Gallery>()
                .HasOne(g => g.Product)
                .WithMany(p => p.Galleries)
                .HasForeignKey(g => g.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // modelBuilder.Entity<Sell>()
            // .HasOne(g => g.Product)
            // .WithMany(p => p.Sells)
            // .HasForeignKey(g => g.ProductId)
            // .OnDelete(DeleteBehavior.Restrict);

            // Cấu hình quan hệ n-n giữa Product và Category
            modelBuilder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c.ProductCategories)
                .HasForeignKey(pc => pc.CategoryId);

            // Cấu hình quan hệ n-n giữa Product và Tag
            modelBuilder.Entity<ProductTag>()
                .HasKey(pt => new { pt.ProductId, pt.TagId });

            modelBuilder.Entity<ProductTag>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.ProductTags)
                .HasForeignKey(pt => pt.ProductId);

            modelBuilder.Entity<ProductTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.ProductTags)
                .HasForeignKey(pt => pt.TagId);

            // Cấu hình quan hệ giữa Product và Attribute
            modelBuilder.Entity<ProductAttribute>()
                .HasOne(pa => pa.Product)
                .WithMany(p => p.ProductAttributes)
                .HasForeignKey(pa => pa.ProductId);

            modelBuilder.Entity<ProductAttribute>()
                .HasOne(pa => pa.Attribute)
                .WithMany(a => a.ProductAttributes)
                .HasForeignKey(pa => pa.AttributeId);

            // Cấu hình quan hệ 1-n giữa Attribute và AttributeValue
            modelBuilder.Entity<AttributeValue>()
                .HasOne(av => av.Attribute)
                .WithMany(a => a.AttributeValues)
                .HasForeignKey(av => av.AttributeId);

            // thieeeeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu

            modelBuilder.Entity<Variant>()
                .HasOne(v => v.Product)
                .WithMany(p => p.Variants)
                .HasForeignKey(v => v.ProductId);

            // Cấu hình quan hệ giữa VariantAttributeValue và VariantValue



            //         modelBuilder.Entity<VariantAttributeValue>()
            // .HasKey(pt => new { pt.VariantId2, pt.AttributeValueId });

            //         modelBuilder.Entity<VariantAttributeValue>()
            //  .HasOne(vav => vav.Variant)
            //  .WithMany(v => v.VariantAttributeValues)
            //  .HasForeignKey(vav => vav.VariantId2)  // This should be VariantId, not VariantId2
            //  .OnDelete(DeleteBehavior.NoAction);

            //         modelBuilder.Entity<VariantAttributeValue>()
            //             .HasOne(vav => vav.AttributeValue)
            //             .WithMany(t => t.VariantAttributeValues)
            //             .HasForeignKey(vav => vav.AttributeValueId)
            //             .OnDelete(DeleteBehavior.NoAction);








        }
    }
}
