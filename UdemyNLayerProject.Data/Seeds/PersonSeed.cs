using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Data.Seeds
{
    public class PersonSeed: IEntityTypeConfiguration<Person> {
        private int[] Ids { get; }

        public PersonSeed(int[] ids)
        {
            Ids = ids;
        }

        public void Configure(EntityTypeBuilder<Person> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}