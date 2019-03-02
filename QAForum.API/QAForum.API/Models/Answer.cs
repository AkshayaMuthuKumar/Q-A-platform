using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QAForum.API.Models
{
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedDate { get; set; }
        public int UpVote { get; set; }
        public int DownVote { get; set; }
        public virtual Question  Question { get; set; }
    }
}