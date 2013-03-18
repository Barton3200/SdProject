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
            public string StreetAddress { get; set; }

            [Display(Name = "City")]
            public string City { get; set; }

            [Display(Name = "Zip Code")]
            public int ZipCode { get; set; }

            [Required]
            [Display(Name = "House Style")]
            public string Style { get; set; }

            [Required]
            [Display(Name = "Square Footage")]
            public int SquareFeet { get; set; }

            [Required]
            [Display(Name = "Number of Bedrooms")]
            public int Bedrooms { get; set; }

            [Required]
            [Display(Name = "Number of Bathrooms")]
            public int Bathrooms { get; set; }

            [Required]
            [DataType(DataType.MultilineText)]
            [Display(Name = "Description/Extras")]
            public string Extras { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
        }
    }
}