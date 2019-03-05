using System;
using System.Collections.Generic;

namespace QAForum.API.Models.Response
{
    public class AnswerResponse
    {
        public AnswerResponse(Answer answer, List<AnswerComment> comments)
        {
            this.Id = answer.Id;
            this.Value = answer.Value;
            this.Description = answer.Description;
            this.UserId = answer.UserId;
            this.CreatedDate = answer.CreatedDate;
            this.UpVote = answer.UpVote;
            this.DownVote = answer.DownVote;
            this.Comments = comments;
            this.QuestionId = answer.QuestionId;
        }

        public int Id { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public int QuestionId { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpVote { get; set; }
        public int DownVote { get; set; }

        public List<AnswerComment> Comments { get; set; }
    }
}