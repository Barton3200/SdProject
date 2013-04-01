using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


    public class RoomsValidator : ValidationAttribute, IClientValidatable 
    {
        private readonly string _maxRooms;

        public RoomsValidator(string roomTotal)
        {
            _maxRooms = roomTotal;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var maxRooms = validationContext.ObjectType.GetProperty(_maxRooms);
            var maxRoomCount = (int)maxRooms.GetValue(validationContext.ObjectInstance, null);
            var currentRoomCount = (int)value;

            if (currentRoomCount >= maxRoomCount)
            {
                return new ValidationResult("The number of rooms must be less than the total number of rooms.");
            }
            return null;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata m, ControllerContext c)
        {
            var r = new ModelClientValidationRule()
            {
                ValidationType = "maxroomvalidation",
                ErrorMessage = "The number of rooms must be less than the total number of rooms."
            };

            r.ValidationParameters["maxroomvalue"] = _maxRooms;
            yield return r;

        }
    }

