namespace QAForum.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        Enrollments_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Question", t => t.Enrollments_Id)
                .Index(t => t.Enrollments_Id);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answer", "Enrollments_Id", "dbo.Question");
            DropIndex("dbo.Answer", new[] { "Enrollments_Id" });
            DropTable("dbo.Question");
            DropTable("dbo.Answer");
        }
    }
}
