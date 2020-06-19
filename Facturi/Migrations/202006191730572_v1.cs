namespace Facturi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banci",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nume = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Conturi",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IBAN = c.String(),
                        Moneda = c.String(),
                        SoldInitial = c.Double(),
                        DataDeschideriiContului = c.DateTime(),
                        Sold = c.Double(),
                        DataSold = c.DateTime(),
                        BancaId = c.Int(nullable: false),
                        CompanieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banci", t => t.BancaId, cascadeDelete: true)
                .ForeignKey("dbo.Companii", t => t.CompanieId, cascadeDelete: true)
                .Index(t => t.BancaId)
                .Index(t => t.CompanieId);
            
            CreateTable(
                "dbo.Companii",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nume = c.String(),
                        Email = c.String(),
                        Prioritate = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Facturi",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valoare = c.Double(nullable: false),
                        Moneda = c.String(),
                        DataEmitere = c.DateTime(nullable: false),
                        DataScadenta = c.DateTime(nullable: false),
                        FurnizorId = c.Int(),
                        ClientId = c.Int(),
                        Companie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companii", t => t.ClientId)
                .ForeignKey("dbo.Companii", t => t.FurnizorId)
                .ForeignKey("dbo.Companii", t => t.Companie_Id)
                .Index(t => t.FurnizorId)
                .Index(t => t.ClientId)
                .Index(t => t.Companie_Id);
            
            CreateTable(
                "dbo.Tranzactii",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ValoareFactura = c.Double(nullable: false),
                        ValoareTotala = c.Double(nullable: false),
                        Moneda = c.String(),
                        Data = c.DateTime(nullable: false),
                        isProcesata = c.Boolean(nullable: false),
                        TipOperatiune = c.String(),
                        FacturaId = c.Int(nullable: false),
                        ContFurnizorId = c.Int(),
                        ContClientId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Conturi", t => t.ContClientId)
                .ForeignKey("dbo.Conturi", t => t.ContFurnizorId)
                .ForeignKey("dbo.Facturi", t => t.FacturaId, cascadeDelete: true)
                .Index(t => t.FacturaId)
                .Index(t => t.ContFurnizorId)
                .Index(t => t.ContClientId);
            
            CreateTable(
                "dbo.Costuri",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Denumire = c.String(),
                        Valoare = c.Double(nullable: false),
                        Moneda = c.String(),
                        TranzactieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tranzactii", t => t.TranzactieId, cascadeDelete: true)
                .Index(t => t.TranzactieId);
            
            CreateTable(
                "dbo.Operatiuni",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Denumire = c.String(),
                        isFix = c.Boolean(nullable: false),
                        CostFix = c.Double(),
                        CostMinim = c.Double(),
                        isPercentage = c.Boolean(nullable: false),
                        PercentageValue = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TemplateExportBanci",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumeBanca = c.String(),
                        Template = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OperatiuneConts",
                c => new
                    {
                        Operatiune_Id = c.Int(nullable: false),
                        Cont_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Operatiune_Id, t.Cont_Id })
                .ForeignKey("dbo.Operatiuni", t => t.Operatiune_Id, cascadeDelete: true)
                .ForeignKey("dbo.Conturi", t => t.Cont_Id, cascadeDelete: true)
                .Index(t => t.Operatiune_Id)
                .Index(t => t.Cont_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OperatiuneConts", "Cont_Id", "dbo.Conturi");
            DropForeignKey("dbo.OperatiuneConts", "Operatiune_Id", "dbo.Operatiuni");
            DropForeignKey("dbo.Facturi", "Companie_Id", "dbo.Companii");
            DropForeignKey("dbo.Tranzactii", "FacturaId", "dbo.Facturi");
            DropForeignKey("dbo.Costuri", "TranzactieId", "dbo.Tranzactii");
            DropForeignKey("dbo.Tranzactii", "ContFurnizorId", "dbo.Conturi");
            DropForeignKey("dbo.Tranzactii", "ContClientId", "dbo.Conturi");
            DropForeignKey("dbo.Facturi", "FurnizorId", "dbo.Companii");
            DropForeignKey("dbo.Facturi", "ClientId", "dbo.Companii");
            DropForeignKey("dbo.Conturi", "CompanieId", "dbo.Companii");
            DropForeignKey("dbo.Conturi", "BancaId", "dbo.Banci");
            DropIndex("dbo.OperatiuneConts", new[] { "Cont_Id" });
            DropIndex("dbo.OperatiuneConts", new[] { "Operatiune_Id" });
            DropIndex("dbo.Costuri", new[] { "TranzactieId" });
            DropIndex("dbo.Tranzactii", new[] { "ContClientId" });
            DropIndex("dbo.Tranzactii", new[] { "ContFurnizorId" });
            DropIndex("dbo.Tranzactii", new[] { "FacturaId" });
            DropIndex("dbo.Facturi", new[] { "Companie_Id" });
            DropIndex("dbo.Facturi", new[] { "ClientId" });
            DropIndex("dbo.Facturi", new[] { "FurnizorId" });
            DropIndex("dbo.Conturi", new[] { "CompanieId" });
            DropIndex("dbo.Conturi", new[] { "BancaId" });
            DropTable("dbo.OperatiuneConts");
            DropTable("dbo.TemplateExportBanci");
            DropTable("dbo.Operatiuni");
            DropTable("dbo.Costuri");
            DropTable("dbo.Tranzactii");
            DropTable("dbo.Facturi");
            DropTable("dbo.Companii");
            DropTable("dbo.Conturi");
            DropTable("dbo.Banci");
        }
    }
}
