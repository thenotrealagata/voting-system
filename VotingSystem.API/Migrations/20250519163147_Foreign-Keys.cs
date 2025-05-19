using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotingSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class NoIdea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoteOption_Votes_VoteId",
                table: "VoteOption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VoteOption",
                table: "VoteOption");

            migrationBuilder.RenameTable(
                name: "VoteOption",
                newName: "VoteOptions");

            migrationBuilder.RenameIndex(
                name: "IX_VoteOption_VoteId",
                table: "VoteOptions",
                newName: "IX_VoteOptions_VoteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VoteOptions",
                table: "VoteOptions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VoteOptions_Votes_VoteId",
                table: "VoteOptions",
                column: "VoteId",
                principalTable: "Votes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoteOptions_Votes_VoteId",
                table: "VoteOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VoteOptions",
                table: "VoteOptions");

            migrationBuilder.RenameTable(
                name: "VoteOptions",
                newName: "VoteOption");

            migrationBuilder.RenameIndex(
                name: "IX_VoteOptions_VoteId",
                table: "VoteOption",
                newName: "IX_VoteOption_VoteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VoteOption",
                table: "VoteOption",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VoteOption_Votes_VoteId",
                table: "VoteOption",
                column: "VoteId",
                principalTable: "Votes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
