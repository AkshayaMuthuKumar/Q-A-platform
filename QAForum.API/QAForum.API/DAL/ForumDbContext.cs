using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using QAForum.API.Models;

namespace QAForum.API.DAL
{
    public class ForumDbContext : DbContext
    {
        public ForumDbContext() : base("ForumDbContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ForumDbContext, Migrations.Configuration>());
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<QuestionComment> QuestionComment { get; set; }
        public DbSet<AnswerComment> AnswwerComment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}