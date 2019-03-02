using System;
using System.Collections.Generic;
using QAForum.API.Models;

namespace QAForum.API.DAL
{
    public class ForumDbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ForumDbContext>
    {
        protected override void Seed(ForumDbContext context)
        {
            var questions = new List<Question>
            {
            new Question{Value="How Angular framework works?",CreatedDate=DateTime.Now},
            };

            questions.ForEach(q => context.Questions.Add(q));
            context.SaveChanges();
        }
    }
}