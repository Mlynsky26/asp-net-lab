using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Labolatorium3___App.Models
{
    public class Car
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Musisz podać markę")]
        [StringLength(maximumLength: 50, ErrorMessage = "Zbyt długa nazwa marki (maksymalnie 50 znaków)")]
        public string Maker { get; set; }


        [Required(ErrorMessage = "Musisz podać model")]
        [StringLength(maximumLength: 50, ErrorMessage = "Zbyt długa nazwa modelu (maksymalnie 50 znaków)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Musisz podać pojemność silnika")]
        [Range(0, int.MaxValue, ErrorMessage = "Pojemność silnika musi być większa od zera")]
        public int Volume { get; set; }


        [Required(ErrorMessage = "Musisz podać moc silnika")]
        [Range(0, int.MaxValue, ErrorMessage = "Moc silnika musi być większa od zera")]
        public int Power { get; set; }

        [Required(ErrorMessage = "Musisz podać typ")]
        [StringLength(maximumLength: 50, ErrorMessage = "Zbyt długa nazwa typu (maksymalnie 50 znaków)")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Musisz podać typ")]
        [StringLength(maximumLength: 10, ErrorMessage = "Zbyt długi numer rejestracyjny (maksymalnie 10 znaków)")]
        public string Registration { get; set; }

        public string? Owner { get; set; }
    }
}
