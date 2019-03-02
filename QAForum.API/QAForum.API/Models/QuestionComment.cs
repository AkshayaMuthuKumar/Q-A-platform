using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QAForum.API.Models
{
    public class QuestionComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }

        public string UserId { get; set; }

        public string Value { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual Question Question { get; set; }
    }
}