namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Mobile", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Mobile");
        }
    }
}
