namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_addtalent : DbMigration
    {
        public override void Up()
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
            
            DropTable("dbo.Skills");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        UserImage = c.String(maxLength: 100),
                        UserTitle = c.String(maxLength: 50),
                        UserAbout = c.String(maxLength: 200),
                        SkillName = c.String(maxLength: 50),
                        SkillRatio = c.String(),
                    })
                .PrimaryKey(t => t.SkillId);
            
            DropTable("dbo.Talents");
        }
    }
}
