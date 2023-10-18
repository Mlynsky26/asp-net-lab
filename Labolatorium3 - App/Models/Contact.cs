using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Labolatorium3___App.Models
{
    public class Contact
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage ="Musisz podać imie")]
        [StringLength(maximumLength: 50, ErrorMessage = "Zbyt długie imię (maksymalnie 50 znaków)")]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        public DateTime? Birth { get; set; }
    }
}
