namespace lab4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Country : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Country", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "Country");
        }
    }
}
