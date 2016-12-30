namespace SNAP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
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
                "dbo.Entity_joueurs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Surnom = c.String(),
                        Arme_primaire = c.String(),
                        Arme_secondaire = c.String(),
                        Profil = c.String(),
                        Nombre_kill_tot = c.Int(),
                        Nombre_death_tot = c.Int(),
                        Nombre_assistance_tot = c.Int(),
                        Ratio_tot = c.Single(),
                        Classement = c.String(),
                        Nombre_de_point = c.Int(),
                        Nombre_de_participation = c.Int(),
                        Nom_classement = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Entity_Occurence",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Partie_ID = c.String(),
                        Joueurs_ID = c.String(),
                        Trophe_ID = c.String(),
                        Nombre_kill = c.Int(),
                        Nombre_death = c.Int(),
                        Nombre_assist = c.Int(),
                        facteur_de_risque = c.Int(),
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Entity_trophes");
            DropTable("dbo.Entity_partie");
            DropTable("dbo.Entity_Occurence");
            DropTable("dbo.Entity_joueurs");
            DropTable("dbo.Entity_Classement_Nom");
        }
    }
}
