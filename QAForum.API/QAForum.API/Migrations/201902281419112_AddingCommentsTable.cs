namespace QAForum.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCommentsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answer", "Enrollments_Id", "dbo.Question");
            DropIndex("dbo.Answer", new[] { "Enrollments_Id" });
            RenameColumn(table: "dbo.Answer", name: "Enrollments_Id", newName: "QuestionId");
            CreateTable(
                "dbo.AnswerComment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnswerId = c.Int(nullable: false),
                        Value = c.String(),
                        UserId = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Answer", t => t.AnswerId, cascadeDelete: true)
                .Index(t => t.AnswerId);
            
            CreateTable(
                "dbo.QuestionComment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        UserId = c.String(),
                        Value = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Question", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            AddColumn("dbo.Answer", "UserId", c => c.String());
            AddColumn("dbo.Answer", "UpVote", c => c.Int(nullable: false));
            AddColumn("dbo.Answer", "DownVote", c => c.Int(nullable: false));
            AddColumn("dbo.Question", "UserId", c => c.String());
            AddColumn("dbo.Question", "UpVote", c => c.Int(nullable: false));
            AddColumn("dbo.Question", "DownVote", c => c.Int(nullable: false));
            AlterColumn("dbo.Answer", "QuestionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Answer", "QuestionId");
            AddForeignKey("dbo.Answer", "QuestionId", "dbo.Question", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answer", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.QuestionComment", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.AnswerComment", "AnswerId", "dbo.Answer");
            DropIndex("dbo.QuestionComment", new[] { "QuestionId" });
            DropIndex("dbo.AnswerComment", new[] { "AnswerId" });
            DropIndex("dbo.Answer", new[] { "QuestionId" });
            AlterColumn("dbo.Answer", "QuestionId", c => c.Int());
            DropColumn("dbo.Question", "DownVote");
            DropColumn("dbo.Question", "UpVote");
            DropColumn("dbo.Question", "UserId");
            DropColumn("dbo.Answer", "DownVote");
            DropColumn("dbo.Answer", "UpVote");
            DropColumn("dbo.Answer", "UserId");
            DropTable("dbo.QuestionComment");
            DropTable("dbo.AnswerComment");
            RenameColumn(table: "dbo.Answer", name: "QuestionId", newName: "Enrollments_Id");
            CreateIndex("dbo.Answer", "Enrollments_Id");
            AddForeignKey("dbo.Answer", "Enrollments_Id", "dbo.Question", "Id");
        }
    }
}
