using StudIS.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudIS.Web.Mvc.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string NationalIdentificationNumber { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string StudentIdentificationNumber { get; set; }

        public StudentViewModel()
        {

        }
        public StudentViewModel(Student student)
        {
            Id = student.Id;
            Name = student.Name;
            Surname = student.Surname;
            NationalIdentificationNumber = student.NationalIdentificationNumber;
            Email = student.Email;
            FullName = student.FullName;
            StudentIdentificationNumber = student.StudentIdentificationNumber;
        }
    }
}