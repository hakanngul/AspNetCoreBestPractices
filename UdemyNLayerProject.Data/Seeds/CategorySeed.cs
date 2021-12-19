using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Data.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        private readonly int[] _ids;

        public CategorySeed(int[] ids)
        {
            _ids = ids;
        }


        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category {Id = 1, Name = "Kalemler",},
                new Category {Id = 2, Name = "Defterler",}
            );
        }
    }
}