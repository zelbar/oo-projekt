using StudIS.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudIS.Web.Mvc.Models {
    public class LecturerViewModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string NationalIdentificationNumber { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }

        public LecturerViewModel() {

        }
        public LecturerViewModel(Lecturer lecturer) {
            Id = lecturer.Id;
            Name = lecturer.Name;
            Surname = lecturer.Surname;
            NationalIdentificationNumber = lecturer.NationalIdentificationNumber;
            Email = lecturer.Email;
            FullName = lecturer.FullName;
        }
    }
}