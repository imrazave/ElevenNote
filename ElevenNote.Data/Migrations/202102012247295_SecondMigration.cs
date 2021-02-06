namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Note", "Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Note", "Id");
            AddForeignKey("dbo.Note", "Id", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Note", "Id", "dbo.Categories");
            DropIndex("dbo.Note", new[] { "Id" });
            DropColumn("dbo.Note", "Id");
            DropTable("dbo.Categories");
        }
    }
}
