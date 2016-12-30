namespace SNAP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastdb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Entity_joueurs", "Niveau", c => c.Int());
            AddColumn("dbo.Entity_Occurence", "Nombre_point", c => c.Int());
            DropColumn("dbo.Entity_joueurs", "Classement");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Entity_joueurs", "Classement", c => c.String());
            DropColumn("dbo.Entity_Occurence", "Nombre_point");
            DropColumn("dbo.Entity_joueurs", "Niveau");
        }
    }
}
