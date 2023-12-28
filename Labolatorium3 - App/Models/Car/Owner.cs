using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Labolatorium3___App.Models
{
    public class Owner
    {
        [HiddenInput]
        public int Id { get; set; }

        [Display(Name = "Imię")]
        [Required(ErrorMessage = "Musisz podać imie")]
        [StringLength(maximumLength: 50, ErrorMessage = "Zbyt długie imię (maksymalnie 50 znaków)")]
        public string Name { get; set; }

        [Display(Name = "Nazwisko")]
        [Required(ErrorMessage = "Musisz podać nazwisko")]
        [StringLength(maximumLength: 50, ErrorMessage = "Zbyt długie nazwisko (maksymalnie 50 znaków)")]
        public string Surname { get; set; }

        [Display(Name = "Numer telefonu")]
        [Phone(ErrorMessage = "Numer telefonu powinien zawierać cyfry")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public AddressModel Address { get; set; }
    }
}
