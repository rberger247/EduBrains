﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EduSmart_dbEntities : DbContext
    {
        public EduSmart_dbEntities()
            : base("name=EduSmart_dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Reciept> Reciepts { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<ApplicantFamily> ApplicantFamilies { get; set; }
        public virtual DbSet<ApplicantFamilyMember> ApplicantFamilyMembers { get; set; }
        public virtual DbSet<ApplicantParent> ApplicantParents { get; set; }
        public virtual DbSet<ApplicantPerson> ApplicantPersons { get; set; }
        public virtual DbSet<ApplicantStudent> ApplicantStudents { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<FamilyMember> FamilyMembers { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<ScheduledClass> ScheduledClasses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
    
        public virtual ObjectResult<sp_ApplicantFamily_SelectFamilyMembers_Result> sp_ApplicantFamily_SelectFamilyMembers(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ApplicantFamily_SelectFamilyMembers_Result>("sp_ApplicantFamily_SelectFamilyMembers", emailParameter);
        }
    
        public virtual int sp_ApplicantPerson_AddPerson(ObjectParameter applicantFatherId, ObjectParameter applicantchildId, ObjectParameter applicantFamilyId, string emailAddress, string fatherFirstName, string gradeEntering, string fatherLastName, string childFirstName, Nullable<System.DateTime> dateOfBirth, Nullable<byte> gender)
        {
            var emailAddressParameter = emailAddress != null ?
                new ObjectParameter("EmailAddress", emailAddress) :
                new ObjectParameter("EmailAddress", typeof(string));
    
            var fatherFirstNameParameter = fatherFirstName != null ?
                new ObjectParameter("FatherFirstName", fatherFirstName) :
                new ObjectParameter("FatherFirstName", typeof(string));
    
            var gradeEnteringParameter = gradeEntering != null ?
                new ObjectParameter("gradeEntering", gradeEntering) :
                new ObjectParameter("gradeEntering", typeof(string));
    
            var fatherLastNameParameter = fatherLastName != null ?
                new ObjectParameter("FatherLastName", fatherLastName) :
                new ObjectParameter("FatherLastName", typeof(string));
    
            var childFirstNameParameter = childFirstName != null ?
                new ObjectParameter("ChildFirstName", childFirstName) :
                new ObjectParameter("ChildFirstName", typeof(string));
    
            var dateOfBirthParameter = dateOfBirth.HasValue ?
                new ObjectParameter("DateOfBirth", dateOfBirth) :
                new ObjectParameter("DateOfBirth", typeof(System.DateTime));
    
            var genderParameter = gender.HasValue ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(byte));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ApplicantPerson_AddPerson", applicantFatherId, applicantchildId, applicantFamilyId, emailAddressParameter, fatherFirstNameParameter, gradeEnteringParameter, fatherLastNameParameter, childFirstNameParameter, dateOfBirthParameter, genderParameter);
        }
    
        public virtual int sp_ApplicantStudent_AddStudent(ObjectParameter applicantStudentId, Nullable<int> applicantPersonId, string firstName, Nullable<byte> gender)
        {
            var applicantPersonIdParameter = applicantPersonId.HasValue ?
                new ObjectParameter("ApplicantPersonId", applicantPersonId) :
                new ObjectParameter("ApplicantPersonId", typeof(int));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var genderParameter = gender.HasValue ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(byte));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ApplicantStudent_AddStudent", applicantStudentId, applicantPersonIdParameter, firstNameParameter, genderParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_SelectStudentInfo(Nullable<int> studentId)
        {
            var studentIdParameter = studentId.HasValue ?
                new ObjectParameter("StudentId", studentId) :
                new ObjectParameter("StudentId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_SelectStudentInfo", studentIdParameter);
        }
    }
}
