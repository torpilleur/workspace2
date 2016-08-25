namespace SNAP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addJoueur : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Entity_joueurs", "Nombre_kill_tot", c => c.String());
            AddColumn("dbo.Entity_joueurs", "Nombre_death_tot", c => c.String());
            AddColumn("dbo.Entity_joueurs", "Nombre_assistance_tot", c => c.String());
            AddColumn("dbo.Entity_joueurs", "Ratio", c => c.String());
            AddColumn("dbo.Entity_joueurs", "Classement", c => c.String());
            AddColumn("dbo.Entity_joueurs", "Nombre_de_point", c => c.String());
            AddColumn("dbo.Entity_joueurs", "Nombre_de_participation", c => c.String());
            AddColumn("dbo.Entity_joueurs", "Nom_classement", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Entity_joueurs", "Nom_classement");
            DropColumn("dbo.Entity_joueurs", "Nombre_de_participation");
            DropColumn("dbo.Entity_joueurs", "Nombre_de_point");
            DropColumn("dbo.Entity_joueurs", "Classement");
            DropColumn("dbo.Entity_joueurs", "Ratio");
            DropColumn("dbo.Entity_joueurs", "Nombre_assistance_tot");
            DropColumn("dbo.Entity_joueurs", "Nombre_death_tot");
            DropColumn("dbo.Entity_joueurs", "Nombre_kill_tot");
        }
    }
}
