using CourseWork.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseWork.Models.ViewModels.Account
{
    public class UserViewModel
    {
        public UserViewModel() 
        { 
        }
        public UserViewModel(UserDTO row)
        {
            UserID = row.UserID;
            FirstName = row.FirstName;
            LastName = row.LastName;
            EmailAdress = row.EmailAdress;
            Username = row.Username;
            Password = row.Password;
        }

        public int UserID { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]

        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]

        public string EmailAdress { get; set; }
        [Required]
        [DisplayName("User Name")]

        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [DisplayName("Confirm Password")]

        public string ConfirmPassword { get; set; }
    }
}