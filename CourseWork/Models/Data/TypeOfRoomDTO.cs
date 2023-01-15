using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CourseWork.Models.Data
{
    [Table("TypeOfRoom")]
    public class TypeOfRoomDTO
    {
        [Key]
        public int TypeOfRoomID { get; set; }
        public int NumberOfRooms { get; set; }
        public int Capacity { get; set; }
        public string Name { get; set; }
    }
}