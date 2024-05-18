using WorkersManagment.Core.Models;

namespace WorkersManagment.Api.Models
{
    public class WorkerPostModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Identity { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public DateTime EntryDate { get; set; }
        //public bool StatusActive { get; set; } = true;
        public List<PositionWorkerPostModel> PositionWorkers { get; set; }
    }
}
