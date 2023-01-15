using CourseWork.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseWork.Models.ViewModels.Pages
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel() { }
        public EmployeeViewModel(EmployeeDTO row)
        {
            EmployeeID = row.EmployeeID;
            PersonID = row.PersonID;
            PositionID = row.PositionID;
            PhoneNumber = row.PhoneNumber;
        }
        public int EmployeeID { get; set; }
        public int PersonID { get; set; }
        public int PositionID { get; set; }
        public string PhoneNumber { get; set; }
    }
}