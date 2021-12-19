using System.Collections.Generic;

namespace UdemyNLayerProject.Core.Models
{
    internal class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}