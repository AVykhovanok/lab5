namespace lab4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        EquipmentId = c.Int(nullable: false, identity: true),
                        EquipmentName = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.EquipmentId);
            
            CreateTable(
                "dbo.Procedures",
                c => new
                    {
                        ProcedureId = c.Int(nullable: false, identity: true),
                        ProcedureName = c.String(),
                    })
                .PrimaryKey(t => t.ProcedureId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        PatientFirstName = c.String(),
                        PatientSecondName = c.String(),
                        PatientAge = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PatientId);
            
            CreateTable(
                "dbo.ProcedureEquipments",
                c => new
                    {
                        Procedure_ProcedureId = c.Int(nullable: false),
                        Equipment_EquipmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Procedure_ProcedureId, t.Equipment_EquipmentId })
                .ForeignKey("dbo.Procedures", t => t.Procedure_ProcedureId, cascadeDelete: true)
                .ForeignKey("dbo.Equipments", t => t.Equipment_EquipmentId, cascadeDelete: true)
                .Index(t => t.Procedure_ProcedureId)
                .Index(t => t.Equipment_EquipmentId);
            
            CreateTable(
                "dbo.PatientProcedures",
                c => new
                    {
                        Patient_PatientId = c.Int(nullable: false),
                        Procedure_ProcedureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Patient_PatientId, t.Procedure_ProcedureId })
                .ForeignKey("dbo.Patients", t => t.Patient_PatientId, cascadeDelete: true)
                .ForeignKey("dbo.Procedures", t => t.Procedure_ProcedureId, cascadeDelete: true)
                .Index(t => t.Patient_PatientId)
                .Index(t => t.Procedure_ProcedureId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientProcedures", "Procedure_ProcedureId", "dbo.Procedures");
            DropForeignKey("dbo.PatientProcedures", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.ProcedureEquipments", "Equipment_EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.ProcedureEquipments", "Procedure_ProcedureId", "dbo.Procedures");
            DropIndex("dbo.PatientProcedures", new[] { "Procedure_ProcedureId" });
            DropIndex("dbo.PatientProcedures", new[] { "Patient_PatientId" });
            DropIndex("dbo.ProcedureEquipments", new[] { "Equipment_EquipmentId" });
            DropIndex("dbo.ProcedureEquipments", new[] { "Procedure_ProcedureId" });
            DropTable("dbo.PatientProcedures");
            DropTable("dbo.ProcedureEquipments");
            DropTable("dbo.Patients");
            DropTable("dbo.Procedures");
            DropTable("dbo.Equipments");
        }
    }
}
