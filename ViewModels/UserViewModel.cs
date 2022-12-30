using System;
using System.ComponentModel.DataAnnotations;
using WellaApi.Models;


namespace WellaApi.ViewModels
{
    public class UserViewModel
    {  
        [Key]
        public int ID {get; set;}
        [Display(Name="First Name")]
        public string FName {get; set;}
        [Display(Name="Last Name")]
        public string LName {get; set;}
        [Display(Name="UserName")]
        public string UName {get; set;}
        [Display(Name="Phonenumber")]
        public int PNumber {get; set;}
        [Display(Name="Email")]
        public string EAddress {get; set;}
        [Display(Name="Role")]
        public string PRole {get; set;}

        //Navigation properties
        // public UserGrade PUserGrade {get; set;}


    }
    
}