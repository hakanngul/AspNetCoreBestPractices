using System.ComponentModel.DataAnnotations;

namespace UdemyNLayerProject.API.DTOs
{
    public class PersonDto
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "{0} alanı gereklidir")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} alanı 1'den büyük bir değer olmalıdır.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} alanı 1'den büyük bir değer olmalıdır.")]
        public string LastName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "{0} alanı 1'den büyük bir değer olmalıdır.")]
        [Required(ErrorMessage = "{0} alanı gereklidir")]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }
    }
}