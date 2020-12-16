namespace CMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Defaults : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "LastPurchase", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Customer", "ClassificationId", c => c.Int(nullable: false));
            AlterColumn("dbo.Customer", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customer", "UserId", c => c.Int());
            AlterColumn("dbo.Customer", "ClassificationId", c => c.Int());
            AlterColumn("dbo.Customer", "LastPurchase", c => c.DateTime(storeType: "date"));
        }
    }
}
