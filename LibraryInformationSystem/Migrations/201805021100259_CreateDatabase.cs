namespace LibraryInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accesses",
                c => new
                    {
                        AccessId = c.Int(nullable: false, identity: true),
                        DueDate = c.DateTime(nullable: false),
                        IsReserved = c.Boolean(nullable: false),
                        BorrowerId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccessId)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Borrowers", t => t.BorrowerId, cascadeDelete: true)
                .Index(t => t.BorrowerId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        ISBN = c.String(),
                        Title = c.String(),
                        Published = c.DateTime(nullable: false),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrentPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.BookId);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        PublisherId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PublisherId);
            
            CreateTable(
                "dbo.Borrowers",
                c => new
                    {
                        BorrowerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        Address2 = c.String(),
                        LocationId = c.Int(nullable: false),
                        Location_LocationId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BorrowerId)
                .ForeignKey("dbo.Locations", t => t.Location_LocationId)
                .Index(t => t.Location_LocationId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.LocationId);
            
            CreateTable(
                "dbo.AuthorBooks",
                c => new
                    {
                        Author_AuthorId = c.Int(nullable: false),
                        Book_BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Author_AuthorId, t.Book_BookId })
                .ForeignKey("dbo.Authors", t => t.Author_AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_BookId, cascadeDelete: true)
                .Index(t => t.Author_AuthorId)
                .Index(t => t.Book_BookId);
            
            CreateTable(
                "dbo.PublisherBooks",
                c => new
                    {
                        Publisher_PublisherId = c.Int(nullable: false),
                        Book_BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Publisher_PublisherId, t.Book_BookId })
                .ForeignKey("dbo.Publishers", t => t.Publisher_PublisherId, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_BookId, cascadeDelete: true)
                .Index(t => t.Publisher_PublisherId)
                .Index(t => t.Book_BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accesses", "BorrowerId", "dbo.Borrowers");
            DropForeignKey("dbo.Borrowers", "Location_LocationId", "dbo.Locations");
            DropForeignKey("dbo.Accesses", "BookId", "dbo.Books");
            DropForeignKey("dbo.PublisherBooks", "Book_BookId", "dbo.Books");
            DropForeignKey("dbo.PublisherBooks", "Publisher_PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.AuthorBooks", "Book_BookId", "dbo.Books");
            DropForeignKey("dbo.AuthorBooks", "Author_AuthorId", "dbo.Authors");
            DropIndex("dbo.PublisherBooks", new[] { "Book_BookId" });
            DropIndex("dbo.PublisherBooks", new[] { "Publisher_PublisherId" });
            DropIndex("dbo.AuthorBooks", new[] { "Book_BookId" });
            DropIndex("dbo.AuthorBooks", new[] { "Author_AuthorId" });
            DropIndex("dbo.Borrowers", new[] { "Location_LocationId" });
            DropIndex("dbo.Accesses", new[] { "BookId" });
            DropIndex("dbo.Accesses", new[] { "BorrowerId" });
            DropTable("dbo.PublisherBooks");
            DropTable("dbo.AuthorBooks");
            DropTable("dbo.Locations");
            DropTable("dbo.Borrowers");
            DropTable("dbo.Publishers");
            DropTable("dbo.Authors");
            DropTable("dbo.Books");
            DropTable("dbo.Accesses");
        }
    }
}
