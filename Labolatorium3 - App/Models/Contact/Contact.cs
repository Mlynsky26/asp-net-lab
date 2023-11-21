using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Labolatorium3___App.Models
{
    public enum Priority
    {
        [Display(Name = "Niski")]
        Low,
        [Display(Name = "Normalny")]
        Medium,
        [Display(Name = "Pilny")]
        Urgent
    }


    public class Contact
    {
        [HiddenInput]
        public int Id { get; set; }

        [Display(Name = "Imię")]
        [Required(ErrorMessage = "Musisz podać imie")]
        [StringLength(maximumLength: 50, ErrorMessage = "Zbyt długie imię (maksymalnie 50 znaków)")]
        public string Name { get; set; }

        [Display(Name = "Adres email")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Numer telefonu")]
        [Phone(ErrorMessage = "Numer telefonu powinien zawierać cyfry")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name = "Data urodzin")]
        [DataType(DataType.Date)]
        public DateTime? Birth { get; set; }

        [Display(Name = "Priorytet")]
        public Priority Priority { get; set; }

        [HiddenInput]
        public DateTime Created { get; set; }

        public int? OrganizationId { get; set; }

        [ValidateNever]
        public List<SelectListItem> OrganizationList { get; set; }

    }
}
