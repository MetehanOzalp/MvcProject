﻿namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_writer_image : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Writers", "ImagePath", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "ImagePath", c => c.String(maxLength: 100));
        }
    }
}
