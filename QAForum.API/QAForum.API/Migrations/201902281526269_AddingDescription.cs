namespace QAForum.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answer", "Description", c => c.String());
            AddColumn("dbo.Question", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Question", "Description");
            DropColumn("dbo.Answer", "Description");
        }
    }
}
