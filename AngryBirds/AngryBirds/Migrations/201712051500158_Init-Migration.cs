namespace AngryBirds.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Birds = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Points = c.Int(nullable: false),
                        PlayerId = c.Int(nullable: false),
                        LevelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.PlayerId)
                .ForeignKey("dbo.Levels", t => t.LevelId)
                .Index(t => t.PlayerId)
                .Index(t => t.LevelId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Scores", "LevelId", "dbo.Levels");
            DropForeignKey("dbo.Scores", "PlayerId", "dbo.Players");
            DropIndex("dbo.Scores", new[] { "LevelId" });
            DropIndex("dbo.Scores", new[] { "PlayerId" });
            DropTable("dbo.Players");
            DropTable("dbo.Scores");
            DropTable("dbo.Levels");
        }
    }
}
