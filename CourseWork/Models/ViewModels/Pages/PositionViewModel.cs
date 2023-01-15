using CourseWork.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseWork.Models.ViewModels.Pages
{
    public class PositionViewModel
    {
        public PositionViewModel() { }
        public PositionViewModel(PositionDTO row)
        {
            PositionID = row.PositionID;
            Name = row.Name;
            Salary = row.Salary;
        }
        public int PositionID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
    }
}