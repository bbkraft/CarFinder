using CarCollectionWeb.Data;
using CarCollectionWeb.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic.FileIO;
using System.ComponentModel.DataAnnotations;

namespace CarCollectionWeb.Models.ViewModel
{
    public class CarViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Car Brand")]
        [Display(Name = "Car Brand")]
        public string? CarBrand { get; set; }

        [Required(ErrorMessage = "Please enter Model")]
        [Display(Name = "Car Model")]
        public string? CarModel { get; set; }

        [Range(1, 10000, ErrorMessage = "Please enter Year")]
        public int Year { get; set; }

        [Range(10, 10000, ErrorMessage = "Please enter Engine Сapacity")]
        public int EngineСapacity { get; set; }
       
        [Required(ErrorMessage = "Please enter Fuel Type")]
        public FuelTypeEnum FuelType { get; set; }

        [Required(ErrorMessage = "Please enter Car Category")]
        public int CarCategoryId { get; set; }
       
        public CarCategoryViewModel CarCategoryViewModel { get; set; }

        public IEnumerable<CarCategoryViewModel> CarCategoriesName { get; set; }

    }
}
