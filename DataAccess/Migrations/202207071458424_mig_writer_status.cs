﻿namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_writer_status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "Status");
        }
    }
}
