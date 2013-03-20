using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SdProject.Models
{
    public class HouseDisplayModel
    {
        public class EnterInfo
        {
            [Display(Name = "Street Address")]
            public string streetAddress { get; set; }

            [Required(ErrorMessage= "Name of city required.")]
            [Display(Name = "City*")]
            public string city { get; set; }

            [Required(ErrorMessage = "Zip code required.")]
            [Display(Name = "Zip Code*")]
            public int zipCode { get; set; }

            [Required(ErrorMessage = "Type of house required.")]
            [Display(Name = "House Style (Ranch, Victorian, etc.)")]//should this be required?
            public string style { get; set; }

            [Required(ErrorMessage = "Square footage required.")]//Will they know this number?
            [Display(Name = "Square Footage (ft²)")]
            public double floorSpace { get; set; }

            [Required(ErrorMessage = "Number of rooms required.")]
            [Display(Name = "Number of Rooms*")]
            public int roomCount { get; set; }

            [Required(ErrorMessage = "Number of floors required.")]
            [Display(Name = "Number of Floors*")]
            public int storyCount { get; set; }

            [Required(ErrorMessage = "Number of bedrooms required.")]
            [Display(Name = "Number of Bedrooms*")]
            public int bedrooms { get; set; }

            [Required(ErrorMessage = "Number of bathrooms required.")]
            [Display(Name = "Number of Bathrooms*")]
            public int bathrooms { get; set; }

            [Required(ErrorMessage = "Heat source type required.")] //should this be required?
            [Display(Name = "Heating Type*")]
            public string heatingType { get; set; }

            [Required(ErrorMessage = "Extra description required.")] //should this be required? What if they don't want to?
            [DataType(DataType.MultilineText)]
            [Display(Name = "Description/Extras")]
            public string extras { get; set; }
        }
      
    }
}