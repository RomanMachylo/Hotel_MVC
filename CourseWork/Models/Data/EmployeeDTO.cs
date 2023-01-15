using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CourseWork.Models.Data
{
    [Table("Employee")]
    public class EmployeeDTO
    {
        [Key]
        public int EmployeeID { get; set; }
        public int PersonID { get; set; }
        public int PositionID { get; set; }
        public string PhoneNumber { get; set; }

        [ForeignKey("PersonID")]
        public virtual PersonsDTO Persons { get; set; }
        [ForeignKey("PositionID")]
        public virtual PositionDTO Positions  { get; set; }
    }
}