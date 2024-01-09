using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milionaires.Database.Entities
{
    public class Score
    {
        public int Id { get; set; }
        public int Result { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
