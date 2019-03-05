using System;
using System.Collections.Generic;

namespace QAForum.API.Models.Response
{
    public class QuestionResponse
    {
        public QuestionResponse(Question question, List<QuestionComment> comments)
        {
            this.Id = question.Id;
            this.Value = question.Value;
            this.Description = question.Description;
            this.UserId = question.UserId;
            this.CreatedDate = question.CreatedDate;
            this.UpVote = question.UpVote;
            this.DownVote = question.DownVote;
            this.Comments = comments;
        }

        public int Id { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpVote { get; set; }
        public int DownVote { get; set; }

        public List<QuestionComment> Comments { get; set; }
    }
}