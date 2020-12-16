namespace CMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Login : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserSys", "Login", c => c.String());
            AlterColumn("dbo.UserSys", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserSys", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.UserSys", "Login", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
