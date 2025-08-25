using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class RevertOwnershipChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ownerships_AspNetUsers_UserName",
                table: "Ownerships");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Ownerships",
                newName: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ownerships_AspNetUsers_AccountId",
                table: "Ownerships",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ownerships_AspNetUsers_AccountId",
                table: "Ownerships");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Ownerships",
                newName: "UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_Ownerships_AspNetUsers_UserName",
                table: "Ownerships",
                column: "UserName",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
