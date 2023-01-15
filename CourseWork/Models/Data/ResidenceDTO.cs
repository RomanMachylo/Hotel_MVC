using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CourseWork.Models.Data
{
    [Table("Residence")]
    public class ResidenceDTO
    {
        [Key]
        public int ResidenceID { get; set; }
        public int UserID { get; set; }
        public int RoomID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ForeignKey("UserID")]
        public virtual UserDTO Users { get; set; }
        [ForeignKey("RoomID")]
        public virtual RoomsDTO Rooms { get; set; }
    }
}