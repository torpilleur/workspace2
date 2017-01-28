namespace SNAP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class suptrophe : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Entity_trophes");
        }
        
        public override void Down()
        {
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
    }
}
