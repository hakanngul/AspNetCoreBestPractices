using System.ComponentModel.DataAnnotations;

namespace UdemyNLayerProject.Core.Models
{
    public class Person
    {
        
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        
        public Person(int ıd, string firstName, string lastName, string email, string phoneNumber, string address)
        {
            Id = ıd;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public Person()
        {
            
        }
    }
}