namespace SquareDanceASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVideoTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserVideo",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        Name = c.String(),
                        Path = c.String(),
                        Vote = c.Int(nullable: false),
                        ViewCount = c.Int(nullable: false),
                        UploadTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserVideo", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserVideo", new[] { "UserId" });
            DropTable("dbo.UserVideo");
        }
    }
}
