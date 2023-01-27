using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProduct.Domain.Entities;

namespace MyProduct.Persistence.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("PRODUCTOS", "CIA");

            builder.Property(p => p.ProductID)
                .HasColumnName("PRODUCTOSID");

            builder.Property(p => p.Name)
                .HasColumnName("NAME");

            builder.Property(p => p.Precio)
                .HasColumnName("PRECIO");
        }
    }
}
