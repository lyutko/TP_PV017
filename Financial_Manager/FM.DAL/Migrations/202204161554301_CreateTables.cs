namespace FM.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Balances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Money = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CurrencyId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Costs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Money = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        CostTypeId = c.Int(nullable: false),
                        BalanceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Balances", t => t.BalanceId, cascadeDelete: true)
                .ForeignKey("dbo.CostTypes", t => t.CostTypeId, cascadeDelete: true)
                .Index(t => t.CostTypeId)
                .Index(t => t.BalanceId);
            
            CreateTable(
                "dbo.CostTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Char = c.String(nullable: false, maxLength: 1, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Incomes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Money = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        IncomeSourceId = c.Int(nullable: false),
                        BalanceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Balances", t => t.BalanceId, cascadeDelete: true)
                .ForeignKey("dbo.IncomeSources", t => t.IncomeSourceId, cascadeDelete: true)
                .Index(t => t.IncomeSourceId)
                .Index(t => t.BalanceId);
            
            CreateTable(
                "dbo.IncomeSources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Balances", "UserId", "dbo.Users");
            DropForeignKey("dbo.Incomes", "IncomeSourceId", "dbo.IncomeSources");
            DropForeignKey("dbo.Incomes", "BalanceId", "dbo.Balances");
            DropForeignKey("dbo.Balances", "CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.Costs", "CostTypeId", "dbo.CostTypes");
            DropForeignKey("dbo.Costs", "BalanceId", "dbo.Balances");
            DropIndex("dbo.Incomes", new[] { "BalanceId" });
            DropIndex("dbo.Incomes", new[] { "IncomeSourceId" });
            DropIndex("dbo.Costs", new[] { "BalanceId" });
            DropIndex("dbo.Costs", new[] { "CostTypeId" });
            DropIndex("dbo.Balances", new[] { "UserId" });
            DropIndex("dbo.Balances", new[] { "CurrencyId" });
            DropTable("dbo.Users");
            DropTable("dbo.IncomeSources");
            DropTable("dbo.Incomes");
            DropTable("dbo.Currencies");
            DropTable("dbo.CostTypes");
            DropTable("dbo.Costs");
            DropTable("dbo.Balances");
        }
    }
}
