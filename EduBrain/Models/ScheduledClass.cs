//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EduBrain.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ScheduledClass
    {
        public int ScheduledClassId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public Nullable<int> TeacherId { get; set; }
        public string Location { get; set; }
        public string Subject { get; set; }
        public string Title { get; set; }
        public string GradeNumber { get; set; }
    }
}
