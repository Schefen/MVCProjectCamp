namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTalentsTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Talents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Talents",
                c => new
                    {
                        TalentId = c.Int(nullable: false, identity: true),
                        TalentName = c.Int(nullable: false),
                        TalentValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TalentId);
            
        }
    }
}
