﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_headingstatusadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Headers", "HeaderStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Headers", "HeaderStatus");
        }
    }
}
