using CourseWork.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseWork.Models.ViewModels.Pages
{
    public class RoomViewModel
    {
        public RoomViewModel() { }
        public RoomViewModel(RoomsDTO row)
        {
            RoomID = row.RoomID;
            TypeOfRoomID = row.TypeOfRoomID;
            PricePerDay = row.PricePerDay;
        }
        public int RoomID { get; set; }
        //[ForeignKey("TypeOfRoom")]
        public int TypeOfRoomID { get; set; }
        public double PricePerDay { get; set; }
    }
}