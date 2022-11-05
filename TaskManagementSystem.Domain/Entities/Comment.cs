using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Domain.Entities
{
    public class Comment
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("task_id")]
        [ForeignKey("TaskId_FK")]
        public int TaskId { get; set; }

        [Required]
        [Column("comment_text")]
        public string CommentText { get; set; }

        [Required]
        [Column("comment_type")]
        public string CommentType { get; set; }

        [Column("remainder_date")]
        public DateTime RemainderDate { get; set; }

    }
}
