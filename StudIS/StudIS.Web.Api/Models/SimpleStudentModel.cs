using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudIS.Models.Users;

namespace StudIS.Web.Api.Models
{
    public class SimpleStudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string NationalIdentificationNumber { get; set; }
        public string Email { get; set; }
        public string FullName;
        public string StudentIdentificationNumber { get; set; }

        public SimpleStudentModel(Student student)
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