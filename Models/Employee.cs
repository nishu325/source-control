using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }

        /*This is used for to get user password */

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[789]\d{9}$")]
        public string Phone { get; set; }

        [Required]
        [FileExtensions(Extensions = "png,jpeg,jpg", ErrorMessage = "Image should be in .jpg or .jpeg or .png format")]
        public string ImagePath { get; set; }

        [Required]
        [Range(18, 100)]
        public int Age { get; set; }

        [Required]
        [Assignment.CustomAttribute.MinExperience(2)]
        public float Experience { get; set; }
    }
}