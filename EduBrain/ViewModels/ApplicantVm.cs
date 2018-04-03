using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduBrain.ViewModels
{
    public class ApplicantVm
    {
        [Required]
        [Display(Name = "Father's First Name")]
        public string FatherFirstName { get; set; }

        [Display(Name = "Father's Title")]
    
        public string   FatherTitle { get; set; }

        [Display(Name = "Email")]
        [Required]
        public string EmailAdress { get; set; }

        public string MotherName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Child's First Name")]
        [Required]
        public string  ChildFirstName { get; set; }


        [Display(Name = "Child Gender")]

        public byte? ChildGender { get; set; }
        public string Grade { get; set; }
        [Display(Name = "Grade Entering")]
        public int SelectedGradeId { get; set; }
        public IEnumerable<SelectListItem> Grades { get; set; }




    }
}