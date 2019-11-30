namespace lab4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class City : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "City", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "City");
        }
    }
}
