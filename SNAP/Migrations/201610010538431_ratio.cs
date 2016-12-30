namespace SNAP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ratio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Entity_Occurence", "ratio", c => c.Single());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Entity_Occurence", "ratio");
        }
    }
}
