using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _092.HairDressingSalon.Database.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
