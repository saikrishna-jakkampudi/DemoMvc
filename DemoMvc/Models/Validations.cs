using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace DemoMvc.Models
{
    public class Validations
    {
        string firstName;
        string lastName;
        double salary;
        string panCard;
        string password;
        string confirmPassword;
        string phone;
        string email;
        DateTime doj;

        [Required(ErrorMessage ="FirstName is Must")]
        [StringLength(maximumLength:25,ErrorMessage ="Max Length is 25 only")]
        public string FirstName { get => firstName; set => firstName = value; }
        [Required(ErrorMessage = "LastName is Must")]
        [StringLength(maximumLength: 25, ErrorMessage = "Max Length is 25 only")]
        public string LastName { get => lastName; set => lastName = value; }
        [Required(ErrorMessage ="Salary is Must")]
        [Range(10000,200000,ErrorMessage ="Salary Must be between 10000 to 200000")]
        public double Salary { get => salary; set => salary = value; }

        [Required(ErrorMessage ="Is a Must")]
        [RegularExpression("^[A-Z]{5}[0-9]{4}[A-Z]{1}$",ErrorMessage ="Not a Valid PanCard Number")]
        public string PanCard { get => panCard; set => panCard = value; }

        [Required(ErrorMessage = "Is a Must")]
        public string Password { get => password; set => password = value; }

        [Compare("Password",ErrorMessage = "Password MisMatch")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get => confirmPassword; set => confirmPassword = value; }
        [Phone(ErrorMessage ="Not a valid number")]
        [RegularExpression("^[0-9]{1,10}$", ErrorMessage = "Enter 10 Digits")]
        public string Phone { get => phone; set => phone = value; }

        [Required(ErrorMessage = "Is a Must")]

        [RegularExpression("^([a-zA-Z0-9_.]+)@([a-zA-Z0-9_.]+).([a-zA-Z]{2,5})$", ErrorMessage = "Not a Valid Email-Id")]
        public string Email { get => email; set => email = value; }
        [CustomDoj]
        public DateTime Doj { get => doj; set => doj = value; }
    }
}