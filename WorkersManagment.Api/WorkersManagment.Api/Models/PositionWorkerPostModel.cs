namespace WorkersManagment.Api.Models
{
    public class PositionWorkerPostModel
    {
        public int PositionId { get; set; }
        public DateTime EntryDate { get; set; }
        public bool IsManagement { get; set; }
        public bool StatusActive {  get; set; }


    }
}
