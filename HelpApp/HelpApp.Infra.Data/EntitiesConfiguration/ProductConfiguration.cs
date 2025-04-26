using HelpApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpApp.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();

            builder.Property(p => p.Price).HasPrecision(10, 2);
            builder.Property(p => p.Image).HasMaxLength(250).IsRequired();
            builder.Property(p => p.Stock).IsRequired();
            builder.HasOne(e => e.Category).WithMany(e => e.Products)
                .HasForeignKey(e => e.CategoryId);

            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "caderno",
                    Description = "Caderno de Figurinha",
                    Price = 15.90m,
                    Stock = 100,
                    Image = "caderno.jpg",
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "culular",
                    Description = "Apply",
                    Price = 150.90m,
                    Stock = 100,
                    Image = "celular.jpg",
                    CategoryId = 2
                },

                    new Product
                    {
                        Id = 3,
                        Name = "Caneta",
                        Description = "Caneta Colorida",
                        Price = 10.90m,
                        Stock = 100,
                        Image = "caneta.jpg",
                        CategoryId = 3
                    }

            );
        }
    }
}
