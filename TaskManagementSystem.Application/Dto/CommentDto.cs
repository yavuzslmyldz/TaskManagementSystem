namespace TaskManagementSystem.Application.Dto
{
    public class CommentDto
    {
        public int TaskId { get; set; }
        public string CommentText { get; set; }
        public string CommentType { get; set; }
        public DateTime RemainderDate { get; set; }
    }
}
