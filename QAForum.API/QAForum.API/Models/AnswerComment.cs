using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QAForum.API.Models
{
    public class AnswerComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Answer")]
        public int AnswerId { get; set; }

        public string Value { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual Answer Answer { get; set; }
    }
}