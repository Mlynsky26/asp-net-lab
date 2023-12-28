using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Labolatorium3___App.Models
{
    public class AddressModel
    {
        [Display(Name = "Miasto")]
        [Required(ErrorMessage = "Musisz podać miasto")]
        [StringLength(maximumLength: 50, ErrorMessage = "Zbyt długie miasto(maksymalnie 50 znaków)")]
        public string City { get; set; }

        [Display(Name = "Ulica")]
        [Required(ErrorMessage = "Musisz podać ulicę")]
        [StringLength(maximumLength: 50, ErrorMessage = "Zbyt długa ulica (maksymalnie 50 znaków)")]
        public string Street { get; set; }

        [Display(Name = "Kod pocztowy")]
        [Required(ErrorMessage = "Musisz podać kod pocztowy")]
        [RegularExpression("^[0-9]{2}-[0-9]{3}$", ErrorMessage = "Niepoprawny kod pocztowy")]
        public string PostalCode { get; set; }
    }
}
