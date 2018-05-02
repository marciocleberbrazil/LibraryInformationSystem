namespace LibraryInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeBookRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AuthorBooks", "Author_AuthorId", "dbo.Authors");
            DropForeignKey("dbo.AuthorBooks", "Book_BookId", "dbo.Books");
            DropForeignKey("dbo.PublisherBooks", "Publisher_PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.PublisherBooks", "Book_BookId", "dbo.Books");
            DropIndex("dbo.AuthorBooks", new[] { "Author_AuthorId" });
            DropIndex("dbo.AuthorBooks", new[] { "Book_BookId" });
            DropIndex("dbo.PublisherBooks", new[] { "Publisher_PublisherId" });
            DropIndex("dbo.PublisherBooks", new[] { "Book_BookId" });
            AddColumn("dbo.Books", "AuthorId", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "PublisherId", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "AuthorId");
            CreateIndex("dbo.Books", "PublisherId");
            AddForeignKey("dbo.Books", "AuthorId", "dbo.Authors", "AuthorId", cascadeDelete: true);
            AddForeignKey("dbo.Books", "PublisherId", "dbo.Publishers", "PublisherId", cascadeDelete: true);
            DropTable("dbo.AuthorBooks");
            DropTable("dbo.PublisherBooks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PublisherBooks",
                c => new
                    {
                        Publisher_PublisherId = c.Int(nullable: false),
                        Book_BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Publisher_PublisherId, t.Book_BookId });
            
            CreateTable(
                "dbo.AuthorBooks",
                c => new
                    {
                        Author_AuthorId = c.Int(nullable: false),
                        Book_BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Author_AuthorId, t.Book_BookId });
            
            DropForeignKey("dbo.Books", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "PublisherId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropColumn("dbo.Books", "PublisherId");
            DropColumn("dbo.Books", "AuthorId");
            CreateIndex("dbo.PublisherBooks", "Book_BookId");
            CreateIndex("dbo.PublisherBooks", "Publisher_PublisherId");
            CreateIndex("dbo.AuthorBooks", "Book_BookId");
            CreateIndex("dbo.AuthorBooks", "Author_AuthorId");
            AddForeignKey("dbo.PublisherBooks", "Book_BookId", "dbo.Books", "BookId", cascadeDelete: true);
            AddForeignKey("dbo.PublisherBooks", "Publisher_PublisherId", "dbo.Publishers", "PublisherId", cascadeDelete: true);
            AddForeignKey("dbo.AuthorBooks", "Book_BookId", "dbo.Books", "BookId", cascadeDelete: true);
            AddForeignKey("dbo.AuthorBooks", "Author_AuthorId", "dbo.Authors", "AuthorId", cascadeDelete: true);
        }
    }
}
