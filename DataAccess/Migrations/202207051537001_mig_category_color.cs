namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_category_color : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "ColorCode", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "ColorCode");
        }
    }
}
