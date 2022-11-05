using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TaskManagementSystem.Domain.Entities
{
    [Table("Task")]
    public class Duty
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("required_by_date")]
        public DateTime RequiredByDate { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Required]
        [Column("status")]
        public string Status { get; set; }

        [Required]
        [Column("type")]
        public string Type { get; set; }

        [Column("assigned_to")]
        public string Assigned { get; set; }


        [Column("next_action_date")]
        [AllowNull]
        public DateTime? NextActionDate { get; set; }

    }
}
