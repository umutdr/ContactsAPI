using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactsAPI.Data.Migrations
{
    public partial class OwnerUserId_FieldAdded_ToContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerUserId",
                table: "Contacts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_OwnerUserId",
                table: "Contacts",
                column: "OwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_OwnerUserId",
                table: "Contacts",
                column: "OwnerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_OwnerUserId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_OwnerUserId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "OwnerUserId",
                table: "Contacts");
        }
    }
}
