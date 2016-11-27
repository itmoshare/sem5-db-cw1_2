namespace cw1_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        Training_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Trainings", t => t.Training_Id)
                .Index(t => t.PersonId)
                .Index(t => t.Training_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 40),
                        MiddleName = c.String(nullable: false, maxLength: 30),
                        Photo = c.Binary(),
                        BirthDate = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trainings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomId = c.Int(nullable: false),
                        StaffId = c.Int(nullable: false),
                        ProgramId = c.Int(nullable: false),
                        TimeBegin = c.Time(nullable: false, precision: 7),
                        TimeEnd = c.Time(nullable: false, precision: 7),
                        Days = c.String(maxLength: 50),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .ForeignKey("dbo.Staffs", t => t.StaffId, cascadeDelete: true)
                .ForeignKey("dbo.TrainingPrograms", t => t.ProgramId, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .Index(t => t.RoomId)
                .Index(t => t.StaffId)
                .Index(t => t.ProgramId)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        WorkTimeBegin = c.Time(nullable: false, precision: 7),
                        WorkTimeEnd = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        PositionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Positions", t => t.PositionId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.PositionId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        Salary = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrainingPrograms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Program = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 20),
                        IncomeDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Safes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChangeRoom = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SafeReservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        SafeId = c.Int(nullable: false),
                        ReservationDateStart = c.DateTime(nullable: false),
                        ReservationDateEnd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Safes", t => t.SafeId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.SafeId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        Type = c.String(nullable: false, maxLength: 30),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Person_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "Person_Id", "dbo.People");
            DropForeignKey("dbo.SafeReservations", "SafeId", "dbo.Safes");
            DropForeignKey("dbo.SafeReservations", "PersonId", "dbo.People");
            DropForeignKey("dbo.Equipments", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Trainings", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Trainings", "ProgramId", "dbo.TrainingPrograms");
            DropForeignKey("dbo.Trainings", "StaffId", "dbo.Staffs");
            DropForeignKey("dbo.Staffs", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Staffs", "PersonId", "dbo.People");
            DropForeignKey("dbo.Trainings", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Clients", "Training_Id", "dbo.Trainings");
            DropForeignKey("dbo.Clients", "PersonId", "dbo.People");
            DropIndex("dbo.Services", new[] { "Person_Id" });
            DropIndex("dbo.SafeReservations", new[] { "SafeId" });
            DropIndex("dbo.SafeReservations", new[] { "PersonId" });
            DropIndex("dbo.Equipments", new[] { "RoomId" });
            DropIndex("dbo.Staffs", new[] { "PositionId" });
            DropIndex("dbo.Staffs", new[] { "PersonId" });
            DropIndex("dbo.Trainings", new[] { "Client_Id" });
            DropIndex("dbo.Trainings", new[] { "ProgramId" });
            DropIndex("dbo.Trainings", new[] { "StaffId" });
            DropIndex("dbo.Trainings", new[] { "RoomId" });
            DropIndex("dbo.Clients", new[] { "Training_Id" });
            DropIndex("dbo.Clients", new[] { "PersonId" });
            DropTable("dbo.Services");
            DropTable("dbo.SafeReservations");
            DropTable("dbo.Safes");
            DropTable("dbo.Equipments");
            DropTable("dbo.TrainingPrograms");
            DropTable("dbo.Positions");
            DropTable("dbo.Staffs");
            DropTable("dbo.Rooms");
            DropTable("dbo.Trainings");
            DropTable("dbo.People");
            DropTable("dbo.Clients");
        }
    }
}
