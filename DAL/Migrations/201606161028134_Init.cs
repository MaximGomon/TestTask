namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Login = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 150),
                        LastName = c.String(maxLength: 150),
                        Phone = c.String(maxLength: 15),
                        Email = c.String(nullable: false, maxLength: 100),
                        Address = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
        }
    }
}
