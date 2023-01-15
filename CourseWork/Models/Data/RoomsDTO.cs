using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CourseWork.Models.Data
{
    [Table("Room")]
    public class RoomsDTO
    {
        [Key]
        public int RoomID { get; set; }
        public int TypeOfRoomID { get; set; }
        public double PricePerDay { get; set; }
        //public int RoomFull { get; set; }

        [ForeignKey("TypeOfRoomID")]
        public virtual TypeOfRoomDTO TypeOfRoom { get; set; }
    }
}