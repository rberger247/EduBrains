using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduBrain.ViewModels
{
    public class StudentVm
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<int> FamilyId { get; set; }
        public Nullable<System.DateTime> EnrollmentDate { get; set; }

    }
}