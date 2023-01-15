using CourseWork.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseWork.Models.ViewModels.Pages
{
    public class ResidenceViewModel
    {
        public ResidenceViewModel() { }
        public ResidenceViewModel(ResidenceDTO row)
        {
            ResidenceID = row.ResidenceID;
            UserID = row.UserID;
            RoomID = row.RoomID;
            StartDate = row.StartDate;
            EndDate = row.EndDate;
        }

        public int ResidenceID { get; set; }
        public int UserID { get; set; }
        public int RoomID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}