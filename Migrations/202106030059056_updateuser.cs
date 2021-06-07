namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateuser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserIfoes",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserIfoes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserIfoes", new[] { "UserId" });
            DropTable("dbo.UserIfoes");
        }
    }
}
