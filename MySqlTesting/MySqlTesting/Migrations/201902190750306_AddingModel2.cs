namespace MySqlTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingModel2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Supplier_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_Id)
                .Index(t => t.Supplier_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Supplier_Id", "dbo.Suppliers");
            DropIndex("dbo.Items", new[] { "Supplier_Id" });
            DropTable("dbo.Items");
        }
    }
}
