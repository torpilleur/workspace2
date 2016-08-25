namespace SNAP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
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
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Entity_joueurs");
        }
    }
}
