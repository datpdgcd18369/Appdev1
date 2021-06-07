namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class time : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "StartDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Courses", "EndDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Courses", "StartDay");
            DropColumn("dbo.Courses", "EndDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "EndDay", c => c.DateTime(nullable: false));
            AddColumn("dbo.Courses", "StartDay", c => c.DateTime(nullable: false));
            DropColumn("dbo.Courses", "EndDateTime");
            DropColumn("dbo.Courses", "StartDateTime");
        }
    }
}
