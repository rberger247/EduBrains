using EduBrain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduBrain.ViewModels
{
    public class LockerVm
    {

        public int LockerId { get; set; }
        public string LockerNumber { get; set; }
        public Nullable<int> StudentId { get; set; }
        public System.DateTime DateAssigned { get; set; }
        public string Location { get; set; }
        public string CombinationNumber { get; set; }

        public  StudentVm student { get; set; }


    }
}