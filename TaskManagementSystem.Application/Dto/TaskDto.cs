namespace TaskManagementSystem.Application.Dto
{
    public class TaskDto
    {
        public int Id { get; set; }
        public DateTime RequiredByDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Assigned { get; set; }
        public DateTime NextActionDate { get; set; }
    }
}
