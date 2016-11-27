namespace cw1_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class indexes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Services", "Person_Id", "dbo.People");
            DropIndex("dbo.Trainings", new[] { "RoomId" });
            DropIndex("dbo.Trainings", new[] { "StaffId" });
            DropIndex("dbo.Trainings", new[] { "ProgramId" });
            DropIndex("dbo.Staffs", new[] { "PersonId" });
            DropIndex("dbo.Staffs", new[] { "PositionId" });
            DropIndex("dbo.Equipments", new[] { "RoomId" });
            DropIndex("dbo.SafeReservations", new[] { "PersonId" });
            DropIndex("dbo.SafeReservations", new[] { "SafeId" });
            DropIndex("dbo.Services", new[] { "Person_Id" });
            CreateIndex("dbo.Trainings", "RoomId");
            CreateIndex("dbo.Trainings", "StaffId");
            CreateIndex("dbo.Trainings", "ProgramId");
            CreateIndex("dbo.Staffs", "PersonId");
            CreateIndex("dbo.Staffs", "PositionId");
            CreateIndex("dbo.Equipments", "RoomId");
            CreateIndex("dbo.SafeReservations", "PersonId");
            CreateIndex("dbo.SafeReservations", "SafeId");
            CreateIndex("dbo.Services", "ClientId");
            AddForeignKey("dbo.Services", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
            DropColumn("dbo.Services", "Person_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "Person_Id", c => c.Int());
            DropForeignKey("dbo.Services", "ClientId", "dbo.Clients");
            DropIndex("dbo.Services", new[] { "ClientId" });
            DropIndex("dbo.SafeReservations", new[] { "SafeId" });
            DropIndex("dbo.SafeReservations", new[] { "PersonId" });
            DropIndex("dbo.Equipments", new[] { "RoomId" });
            DropIndex("dbo.Staffs", new[] { "PositionId" });
            DropIndex("dbo.Staffs", new[] { "PersonId" });
            DropIndex("dbo.Trainings", new[] { "ProgramId" });
            DropIndex("dbo.Trainings", new[] { "StaffId" });
            DropIndex("dbo.Trainings", new[] { "RoomId" });
            CreateIndex("dbo.Services", "Person_Id");
            CreateIndex("dbo.SafeReservations", "SafeId");
            CreateIndex("dbo.SafeReservations", "PersonId");
            CreateIndex("dbo.Equipments", "RoomId");
            CreateIndex("dbo.Staffs", "PositionId");
            CreateIndex("dbo.Staffs", "PersonId");
            CreateIndex("dbo.Trainings", "ProgramId");
            CreateIndex("dbo.Trainings", "StaffId");
            CreateIndex("dbo.Trainings", "RoomId");
            AddForeignKey("dbo.Services", "Person_Id", "dbo.People", "Id");
        }
    }
}
