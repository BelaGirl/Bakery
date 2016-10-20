namespace Bakery.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Category");
            DropIndex("dbo.Products", new[] { "Category_Id" });
            
            RenameColumn(table: "dbo.Products", name: "Category_Id", newName: "CatId");
            AlterColumn("dbo.Products", "CatId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "CatId");
            AddForeignKey("dbo.Products", "CatId", "dbo.Category", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CatId", "dbo.Category");
            DropIndex("dbo.Products", new[] { "CatId" });
            AlterColumn("dbo.Products", "CatId", c => c.Int());
            RenameColumn(table: "dbo.Products", name: "CatId", newName: "Category_Id");
            AddColumn("dbo.Products", "CatId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "Category_Id");
            AddForeignKey("dbo.Products", "Category_Id", "dbo.Category", "Id");
        }
    }
}
