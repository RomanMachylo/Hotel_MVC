using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CourseWork.Models.Data
{
    [Table("Roles")]
    public class RoleDTO
    {
        [Key]
        public int RoleID { get; set; }
        public string Name { get; set; }

    }
}