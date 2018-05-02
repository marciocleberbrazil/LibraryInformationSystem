namespace LibraryInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeBorrowerClass : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Borrowers", new[] { "Location_LocationId" });
            DropColumn("dbo.Borrowers", "LocationId");
            RenameColumn(table: "dbo.Borrowers", name: "Location_LocationId", newName: "LocationId");
            AlterColumn("dbo.Borrowers", "LocationId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Borrowers", "LocationId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Borrowers", new[] { "LocationId" });
            AlterColumn("dbo.Borrowers", "LocationId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Borrowers", name: "LocationId", newName: "Location_LocationId");
            AddColumn("dbo.Borrowers", "LocationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Borrowers", "Location_LocationId");
        }
    }
}
