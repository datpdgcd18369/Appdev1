namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datatimeCoures : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "StartDay", c => c.DateTime(nullable: false));
            AddColumn("dbo.Courses", "EndDay", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "EndDay");
            DropColumn("dbo.Courses", "StartDay");
        }
    }
}
