using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WellaApi.Models
{
    public class UserGrade
    {  
        [Key]
        public int ID {get; set;}
        public string grade {set; get;}

        //navigation properties
        public List<UserData> User {get; set;}
    }


} 

