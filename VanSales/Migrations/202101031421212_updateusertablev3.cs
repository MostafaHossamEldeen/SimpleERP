namespace VanSales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateusertablev3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "lastlogin", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "createdate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "createdate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "lastlogin", c => c.DateTime(nullable: false));
        }
    }
}
