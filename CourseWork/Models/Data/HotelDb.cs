using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CourseWork.Models.Data
{
    public class HotelDb : DbContext
    {
        public HotelDb()
            : base("DatabaseConnection")
        {
        }
        public DbSet<RoomsDTO> Room { get; set; }
        public DbSet<PersonsDTO> Person { get; set; }
        public DbSet<TypeOfRoomDTO> TypeOfRoom { get; set; }
        public DbSet<UserDTO> User { get; set; }
        public DbSet<ResidenceDTO> Residence { get; set; }
        public DbSet<PositionDTO> Position { get; set; }
        public DbSet<EmployeeDTO> Employee { get; set; }
        public DbSet<RoleDTO> Role { get; set; }
        public DbSet<UserRoleDTO> UserRole { get; set; }
    }
}