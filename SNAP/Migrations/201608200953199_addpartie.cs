namespace SNAP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpartie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Entity_Classement_Nom",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Nombre_point_ref = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Entity_Occurence",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Partie_ID = c.Int(),
                        Joueurs_ID = c.Int(),
                        Trophe_ID = c.Int(),
                        Nombre_kill = c.Int(),
                        Nombre_death = c.Int(),
                        Nombre_assist = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Entity_partie",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Date = c.String(),
                        Nombre_de_participant = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Entity_trophes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Condition_attribution = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Entity_joueurs", "Ratio_tot", c => c.Single());
            AlterColumn("dbo.Entity_joueurs", "Nombre_kill_tot", c => c.Int());
            AlterColumn("dbo.Entity_joueurs", "Nombre_death_tot", c => c.Int());
            AlterColumn("dbo.Entity_joueurs", "Nombre_assistance_tot", c => c.Int());
            AlterColumn("dbo.Entity_joueurs", "Nombre_de_point", c => c.Int());
            AlterColumn("dbo.Entity_joueurs", "Nombre_de_participation", c => c.Int());
            DropColumn("dbo.Entity_joueurs", "Ratio");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Entity_joueurs", "Ratio", c => c.String());
            AlterColumn("dbo.Entity_joueurs", "Nombre_de_participation", c => c.String());
            AlterColumn("dbo.Entity_joueurs", "Nombre_de_point", c => c.String());
            AlterColumn("dbo.Entity_joueurs", "Nombre_assistance_tot", c => c.String());
            AlterColumn("dbo.Entity_joueurs", "Nombre_death_tot", c => c.String());
            AlterColumn("dbo.Entity_joueurs", "Nombre_kill_tot", c => c.String());
            DropColumn("dbo.Entity_joueurs", "Ratio_tot");
            DropTable("dbo.Entity_trophes");
            DropTable("dbo.Entity_partie");
            DropTable("dbo.Entity_Occurence");
            DropTable("dbo.Entity_Classement_Nom");
        }
    }
}
