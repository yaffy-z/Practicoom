using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersManagment.Core.Models
{
    public class PositionWorker
    {
        public int WorkerId { get; set; }
        public Worker Employee { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public DateTime EntryDate { get; set; }
        public bool IsManagement { get; set; }
        public bool StatusActive { get; set; }=true;
    }
}
