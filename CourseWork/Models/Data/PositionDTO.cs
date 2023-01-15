using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CourseWork.Models.Data
{
    [Table("Position")]
    public class PositionDTO
    {
        [Key]
        public int PositionID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
    }
}