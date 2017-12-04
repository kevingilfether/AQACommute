namespace AQACommute.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCommuteID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CommuteID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CommuteID");
        }
    }
}
