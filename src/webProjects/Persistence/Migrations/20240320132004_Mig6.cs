using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaims_OperationClaims_OperationClaimId1",
                table: "UserOperationClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaims_Users_UserId1",
                table: "UserOperationClaims");

            migrationBuilder.DropIndex(
                name: "IX_UserOperationClaims_OperationClaimId1",
                table: "UserOperationClaims");

            migrationBuilder.DropIndex(
                name: "IX_UserOperationClaims_UserId1",
                table: "UserOperationClaims");

            migrationBuilder.DropColumn(
                name: "OperationClaimId1",
                table: "UserOperationClaims");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserOperationClaims");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UserOperationClaims",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "OperationClaimId",
                table: "UserOperationClaims",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "UserOperationClaims",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId",
                principalTable: "OperationClaims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaims_Users_UserId",
                table: "UserOperationClaims",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                table: "UserOperationClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaims_Users_UserId",
                table: "UserOperationClaims");

            migrationBuilder.DropIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims");

            migrationBuilder.DropIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "UserOperationClaims");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserOperationClaims",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "OperationClaimId",
                table: "UserOperationClaims",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "OperationClaimId1",
                table: "UserOperationClaims",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "UserOperationClaims",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId1",
                table: "UserOperationClaims",
                column: "OperationClaimId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_UserId1",
                table: "UserOperationClaims",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaims_OperationClaims_OperationClaimId1",
                table: "UserOperationClaims",
                column: "OperationClaimId1",
                principalTable: "OperationClaims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaims_Users_UserId1",
                table: "UserOperationClaims",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
