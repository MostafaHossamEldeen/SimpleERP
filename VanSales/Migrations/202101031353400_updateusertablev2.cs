namespace VanSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateusertablev2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "lockaccount", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "lastlogin", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "createdate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "createdate");
            DropColumn("dbo.AspNetUsers", "lastlogin");
            DropColumn("dbo.AspNetUsers", "lockaccount");
        }
    }
}
