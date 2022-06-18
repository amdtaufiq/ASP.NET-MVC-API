namespace Logique_api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressUsers",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        DetailUserID = c.Guid(nullable: false),
                        Address = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                        DeletedBy = c.String(),
                        IsDelete = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DetailUsers", t => t.DetailUserID, cascadeDelete: true)
                .Index(t => t.DetailUserID);
            
            CreateTable(
                "dbo.DetailUsers",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        MembershipType = c.Int(nullable: false),
                        MembershipFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                        DeletedBy = c.String(),
                        IsDelete = c.Boolean(),
                        CreditCard_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CreditCards", t => t.CreditCard_Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CreditCard_Id);
            
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        DetailUserID = c.Guid(nullable: false),
                        Number = c.String(),
                        Type = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                        DeletedBy = c.String(),
                        IsDelete = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DetailUsers", t => t.DetailUserID, cascadeDelete: true)
                .Index(t => t.DetailUserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        TermAndCondition = c.Boolean(nullable: false),
                        Password = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                        DeletedBy = c.String(),
                        IsDelete = c.Boolean(),
                        DetailUser_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DetailUsers", t => t.DetailUser_Id)
                .Index(t => t.DetailUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetailUsers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "DetailUser_Id", "dbo.DetailUsers");
            DropForeignKey("dbo.DetailUsers", "CreditCard_Id", "dbo.CreditCards");
            DropForeignKey("dbo.CreditCards", "DetailUserID", "dbo.DetailUsers");
            DropForeignKey("dbo.AddressUsers", "DetailUserID", "dbo.DetailUsers");
            DropIndex("dbo.Users", new[] { "DetailUser_Id" });
            DropIndex("dbo.CreditCards", new[] { "DetailUserID" });
            DropIndex("dbo.DetailUsers", new[] { "CreditCard_Id" });
            DropIndex("dbo.DetailUsers", new[] { "UserId" });
            DropIndex("dbo.AddressUsers", new[] { "DetailUserID" });
            DropTable("dbo.Users");
            DropTable("dbo.CreditCards");
            DropTable("dbo.DetailUsers");
            DropTable("dbo.AddressUsers");
        }
    }
}
