namespace SNAP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class classement : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Entity_joueurs", "classement", c => c.Int());
            AddColumn("dbo.Entity_Occurence", "Delta_point", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Entity_Occurence", "Delta_point");
            DropColumn("dbo.Entity_joueurs", "classement");
        }
    }
}
