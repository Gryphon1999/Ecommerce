namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCategoryInProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "categoryId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "categoryId");
        }
    }
}
