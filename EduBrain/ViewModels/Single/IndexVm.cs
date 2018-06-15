using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EduBrain.ViewModels.Single
{
    public class IndexVm
    {
        public DateTime RegisterDate { get; set; }
        public int Price { get; set; }

        [Required]
        public string FirstName { get; set; }
     
        public string MiddleName { get; set; }
       
        public string LastName { get; set; }
       
        public string Email { get; set; }
    }
}