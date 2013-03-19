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

            [Required]
            [Display(Name = "City")]
            public string city { get; set; }

            [Required]
            [Display(Name = "Zip Code")]
            public int zipCode { get; set; }

            [Required]
            [Display(Name = "House Style (Ranch, Victorian, etc.)")]
            public string style { get; set; }

            [Required]
            [Display(Name = "Square Footage (ft²)")]
            public double floorSpace { get; set; }

            [Required]
            [Display(Name = "Number of Rooms")]
            public int roomCount { get; set; }

            [Required]
            [Display(Name = "Number of Floors")]
            public int storyCount { get; set; }

            [Required]
            [Display(Name = "Number of Bedrooms")]
            public int bedrooms { get; set; }

            [Required]
            [Display(Name = "Number of Bathrooms")]
            public int bathrooms { get; set; }

            [Required]
            [Display(Name = "Heating Type")]
            public string heatingType { get; set; }

            [Required]
            [DataType(DataType.MultilineText)]
            [Display(Name = "Description/Extras")]
            public string extras { get; set; }
        }
      
    }
}