namespace WebAuth.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCommit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "CONSOLE.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 300, unicode: false),
                        Name = c.String(nullable: false, maxLength: 256, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "CONSOLE.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 300, unicode: false),
                        RoleId = c.String(nullable: false, maxLength: 300, unicode: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("CONSOLE.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("CONSOLE.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "CONSOLE.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 300, unicode: false),
                        Email = c.String(maxLength: 256, unicode: false),
                        EmailConfirmed = c.Decimal(nullable: false, precision: 1, scale: 0),
                        PasswordHash = c.String(maxLength: 300, unicode: false),
                        SecurityStamp = c.String(maxLength: 300, unicode: false),
                        PhoneNumber = c.String(maxLength: 300, unicode: false),
                        PhoneNumberConfirmed = c.Decimal(nullable: false, precision: 1, scale: 0),
                        TwoFactorEnabled = c.Decimal(nullable: false, precision: 1, scale: 0),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Decimal(nullable: false, precision: 1, scale: 0),
                        AccessFailedCount = c.Decimal(nullable: false, precision: 10, scale: 0),
                        UserName = c.String(nullable: false, maxLength: 256, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "CONSOLE.AspNetUserClaims",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        UserId = c.String(nullable: false, maxLength: 300, unicode: false),
                        ClaimType = c.String(maxLength: 300, unicode: false),
                        ClaimValue = c.String(maxLength: 300, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("CONSOLE.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "CONSOLE.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 300, unicode: false),
                        ProviderKey = c.String(nullable: false, maxLength: 300, unicode: false),
                        UserId = c.String(nullable: false, maxLength: 300, unicode: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("CONSOLE.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("CONSOLE.AspNetUserRoles", "UserId", "CONSOLE.AspNetUsers");
            DropForeignKey("CONSOLE.AspNetUserLogins", "UserId", "CONSOLE.AspNetUsers");
            DropForeignKey("CONSOLE.AspNetUserClaims", "UserId", "CONSOLE.AspNetUsers");
            DropForeignKey("CONSOLE.AspNetUserRoles", "RoleId", "CONSOLE.AspNetRoles");
            DropIndex("CONSOLE.AspNetUserLogins", new[] { "UserId" });
            DropIndex("CONSOLE.AspNetUserClaims", new[] { "UserId" });
            DropIndex("CONSOLE.AspNetUsers", "UserNameIndex");
            DropIndex("CONSOLE.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("CONSOLE.AspNetUserRoles", new[] { "UserId" });
            DropIndex("CONSOLE.AspNetRoles", "RoleNameIndex");
            DropTable("CONSOLE.AspNetUserLogins");
            DropTable("CONSOLE.AspNetUserClaims");
            DropTable("CONSOLE.AspNetUsers");
            DropTable("CONSOLE.AspNetUserRoles");
            DropTable("CONSOLE.AspNetRoles");
        }
    }
}
