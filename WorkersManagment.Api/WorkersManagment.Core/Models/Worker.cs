using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WorkersManagment.Core.Models
{
    public enum Gender
    {
        Male,
        Female
    }
    public class Worker
    {
        public int WorkerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Identity { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public DateTime EntryDate { get; set; }
        public bool StatusActive { get; set; }=true;
        public List<PositionWorker> PositionWorkers { get; set; }   
    }
}
