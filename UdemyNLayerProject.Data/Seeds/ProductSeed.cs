using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Data.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;

        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Pilot Kalem",
                    Price = 12.50m,
                    Stock = 400,
                    CategoryId = _ids[0],
                    Description = "Kalemler Description",
                    InnerBarcode = "12312"
                },
                new Product
                {
                    Id = 2,
                    Name = "Kurşun Kalem",
                    Price = 4.30m,
                    Stock = 150,
                    CategoryId = _ids[0],
                    Description = "Kalemler Description 2 kurşun kalem",
                    InnerBarcode = "12312"
                },
                new Product
                {
                    Id = 3,
                    Name = "Tükenmez Kalem",
                    Price = 34.30m,
                    Stock = 550,
                    CategoryId = _ids[0],
                    Description = "Kalemler Description 3 Tükenmez kalem",
                    InnerBarcode = "12312"
                },
                new Product
                {
                    Id = 4,
                    Name = "Küçük boy defter",
                    Price = 22.50m,
                    Stock = 410,
                    CategoryId = _ids[1],
                    Description = "Küçük defter Description 1",
                    InnerBarcode = "12312"
                },
                new Product
                {
                    Id = 5,
                    Name = "Orta boy defter",
                    Price = 22.50m,
                    Stock = 420,
                    CategoryId = _ids[1],
                    Description = "Orta defter Description 2",
                    InnerBarcode = "12312"
                },
                new Product
                {
                    Id = 6,
                    Name = "Büyük boy defter",
                    Price = 22.50m,
                    Stock = 120,
                    CategoryId = _ids[1],
                    Description = "Büyük defter Description 2",
                    InnerBarcode = "12312"
                }
            );
        }
    }
}