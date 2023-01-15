using CourseWork.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseWork.Models.ViewModels.Pages
{
    public class PersonViewModel
    {
        public PersonViewModel() { }
        public PersonViewModel(PersonsDTO row)
        {
            PersonID = row.PersonID;
            Surname = row.Surname;
            Name = row.Name;
            Patronymic = row.Patronymic;
            Birthday = row.Birthday;
        }
        public int PersonID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
    }
}