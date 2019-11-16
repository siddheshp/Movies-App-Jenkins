using MVC_EF_Identity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_EF_Identity.Validators
{
    public class PastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var instance = validationContext.ObjectInstance;

            if (instance is Movie)
            {
                var movie = instance as Movie;
                if (movie.ReleaseDate >= DateTime.Now)
                {
                    return new ValidationResult("Date should be the past",
                        new[] { nameof(movie.ReleaseDate) });
                }
            }
            if (instance is Actor)
            {
                var actor = instance as Actor;
                if (actor.DateOfBirth >= DateTime.Now)
                {
                    return new ValidationResult("Date should be the past",
                        new[] { nameof(actor.DateOfBirth) });
                }
            }
            return ValidationResult.Success;
        }
    }
}
