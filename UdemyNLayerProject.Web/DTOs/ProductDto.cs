using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UdemyNLayerProject.Web.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir")]
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public List<string> Categories { get; set; }
    }
}