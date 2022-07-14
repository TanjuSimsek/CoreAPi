using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(

                new Product
                {

                    Id = 1,
                    CategoryId = 1,
                    Name = "Kalem1",
                    Price = 100,
                    Stock = 20,
                    CreatedDate = DateTime.Now
                },
                new Product
                {

                    Id = 4,
                    CategoryId = 1,
                    Name = "Kalem2",
                    Price = 100,
                    Stock = 20,
                    CreatedDate = DateTime.Now
                },
                new Product
                {

                    Id = 2,
                    Name = "Kitap1",
                    CategoryId = 2,
                    Price = 156,
                    Stock = 21,
                    CreatedDate = DateTime.Now
                },
                new Product
                {

                    Id = 3,
                    CategoryId = 3,
                    Name = "Mouse",
                    Price = 1000,
                    Stock = 250,
                    CreatedDate = DateTime.Now
                }, new Product
                {

                    Id = 5,
                    CategoryId = 3,
                    Name = "Keyboard",
                    Price = 1100,
                    Stock = 250,
                    CreatedDate = DateTime.Now
                }
                );
        }
    }
}
