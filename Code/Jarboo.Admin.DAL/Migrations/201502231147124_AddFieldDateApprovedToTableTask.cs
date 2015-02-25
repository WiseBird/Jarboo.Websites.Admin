namespace Jarboo.Admin.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldDateApprovedToTableTask : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "DateApproved", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "DateApproved");
        }
    }
}
