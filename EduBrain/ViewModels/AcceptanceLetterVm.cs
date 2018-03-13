using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduBrain.ViewModels
{
    public class AcceptanceLetterVm
    {
        public string FatherFirstName { get; set; }
        public string MotherName { get; set; }
        public string LastName { get; set; }
        public string  ChildFirstName { get; set; }
        public string Grade { get; set; }
        [Display(Name = "Grade Entering")]
        public int SelectedGradeId { get; set; }
        public IEnumerable<SelectListItem> Grades { get; set; }




    }
}