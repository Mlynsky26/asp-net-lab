using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Labolatorium3___App.Models
{
    public enum EngineType
    {
        [Display(Name = "Benzyna")]
        Benzine,
        [Display(Name = "Diesel")]
        Diesel,
        [Display(Name = "Gaz")]
        Gas
    }

    public class Car
    {
        [HiddenInput]
        public int Id { get; set; }
        
        [Display(Name = "Marka")]
        [Required(ErrorMessage = "Musisz podać markę")]
        [StringLength(maximumLength: 50, ErrorMessage = "Zbyt długa nazwa marki (maksymalnie 50 znaków)")]
        public string Maker { get; set; }

        [Display(Name = "Model")]
        [Required(ErrorMessage = "Musisz podać model")]
        [StringLength(maximumLength: 50, ErrorMessage = "Zbyt długa nazwa modelu (maksymalnie 50 znaków)")]
        public string Name { get; set; }

        [Display(Name = "Pojemność silnika [cm^3]")]
        [Required(ErrorMessage = "Musisz podać pojemność silnika")]
        [Range(0, int.MaxValue, ErrorMessage = "Pojemność silnika musi być większa od zera")]
        public int Volume { get; set; }

        [Display(Name = "Moc silnika [km]")]
        [Required(ErrorMessage = "Musisz podać moc silnika")]
        [Range(0, int.MaxValue, ErrorMessage = "Moc silnika musi być większa od zera")]
        public int Power { get; set; }

        [Display(Name = "Typ silnika")]
        public EngineType EngineType { get; set; }

        [Display(Name = "Numer rejestracyjny")]
        [Required(ErrorMessage = "Musisz podać numer rejestracyjny")]
        [StringLength(maximumLength: 10, ErrorMessage = "Zbyt długi numer rejestracyjny (maksymalnie 10 znaków)")]
        public string Registration { get; set; }

        [Display(Name = "Właściciel")]
        public string? Owner { get; set; }
    }
}
