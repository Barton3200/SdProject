using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;



    public class MaxRoomsAttribute : ValidationAttribute, IClientValidatable
    {
        public int maximumRooms { get; set; }
        public int rooms { get; set; }
        public int bedrooms { get; set; }

        public override bool IsValid(object value, ValidationContext validation)
        {
            return true;
        }

    }

