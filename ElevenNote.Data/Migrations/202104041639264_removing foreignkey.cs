namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removingforeignkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Note", "Id", "dbo.Categories");
            DropIndex("dbo.Note", new[] { "Id" });
            RenameColumn(table: "dbo.Note", name: "Id", newName: "Category_Id");
            AlterColumn("dbo.Note", "Category_Id", c => c.Int());
            CreateIndex("dbo.Note", "Category_Id");
            AddForeignKey("dbo.Note", "Category_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Note", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Note", new[] { "Category_Id" });
            AlterColumn("dbo.Note", "Category_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Note", name: "Category_Id", newName: "Id");
            CreateIndex("dbo.Note", "Id");
            AddForeignKey("dbo.Note", "Id", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
