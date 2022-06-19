using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionFormation.Migrations
{
    public partial class Participants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participantss_Formations_FormationID",
                table: "Participantss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participantss",
                table: "Participantss");

            migrationBuilder.RenameTable(
                name: "Participantss",
                newName: "Participants");

            migrationBuilder.RenameIndex(
                name: "IX_Participantss_FormationID",
                table: "Participants",
                newName: "IX_Participants_FormationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participants",
                table: "Participants",
                column: "ParticipantsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Formations_FormationID",
                table: "Participants",
                column: "FormationID",
                principalTable: "Formations",
                principalColumn: "FormationID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Formations_FormationID",
                table: "Participants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participants",
                table: "Participants");

            migrationBuilder.RenameTable(
                name: "Participants",
                newName: "Participantss");

            migrationBuilder.RenameIndex(
                name: "IX_Participants_FormationID",
                table: "Participantss",
                newName: "IX_Participantss_FormationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participantss",
                table: "Participantss",
                column: "ParticipantsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participantss_Formations_FormationID",
                table: "Participantss",
                column: "FormationID",
                principalTable: "Formations",
                principalColumn: "FormationID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
