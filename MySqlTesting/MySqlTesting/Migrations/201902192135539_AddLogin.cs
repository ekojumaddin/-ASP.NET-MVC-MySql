namespace MySqlTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLogin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logins", "LoginErrorMessage", c => c.String(unicode: false));
            AlterColumn("dbo.Logins", "Username", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Logins", "Password", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Logins", "Password", c => c.String(unicode: false));
            AlterColumn("dbo.Logins", "Username", c => c.String(unicode: false));
            DropColumn("dbo.Logins", "LoginErrorMessage");
        }
    }
}
