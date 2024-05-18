using WorkersManagment.Core.Models;

namespace WorkersManagment.Api.Models
{
    public class WorkerAddModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Identity { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public DateTime EntryDate { get; set; }
        public List<PositionWorkerPostModel> PositionWorkers { get; set; }
    }
}
