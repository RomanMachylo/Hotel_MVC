using CourseWork.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseWork.Models.ViewModels.Pages
{
    public class TypeOfRoomViewModel
    {
        public TypeOfRoomViewModel() { }
        public TypeOfRoomViewModel(TypeOfRoomDTO row)
        {
            TypeOfRoomID = row.TypeOfRoomID;
            NumberOfRooms = row.NumberOfRooms;
            Capacity = row.Capacity;
            Name = row.Name;
        }
        public int TypeOfRoomID { get; set; }
        public int NumberOfRooms { get; set; }
        public int Capacity { get; set; }
        public string Name { get; set; }
    }
}