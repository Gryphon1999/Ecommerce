namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmenfashion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenFashions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Type = c.String(),
                        Size = c.String(),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MenFashions");
        }
    }
}
