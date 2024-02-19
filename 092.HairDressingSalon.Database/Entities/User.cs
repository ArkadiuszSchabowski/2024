using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace _092.HairDressingSalon.Database.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public bool Sex { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; } = 1;
        public Role Role { get; set; }
    }
}
