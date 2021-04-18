using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.Property(p=>p.Id).IsRequired();
            builder.Property(p=>p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p=>p.Description).IsRequired().HasMaxLength(180);
            builder.Property(p=>p.Price).HasColumnType("Decimal(18,2)");
            builder.Property(p=>p.PictureUrl).IsRequired();
            builder.HasOne(p=>p.ProductBrand).WithMany()
            .HasForeignKey(f=>f.ProductBrandId);
            builder.HasOne(p=>p.ProductType).WithMany()
            .HasForeignKey(f=>f.ProductTypeId);
            
        }
    }
}