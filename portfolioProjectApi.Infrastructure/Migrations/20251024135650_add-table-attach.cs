using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addtableattach : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImagePath",
                table: "Portfolios");

            migrationBuilder.AddColumn<int>(
                name: "CvAttachmentId",
                table: "Portfolios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileImageAttachmentId",
                table: "Portfolios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    AttachmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    OriginalFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.AttachmentId);
                    table.ForeignKey(
                        name: "FK_Attachments_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_CvAttachmentId",
                table: "Portfolios",
                column: "CvAttachmentId",
                unique: true,
                filter: "[CvAttachmentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_ProfileImageAttachmentId",
                table: "Portfolios",
                column: "ProfileImageAttachmentId",
                unique: true,
                filter: "[ProfileImageAttachmentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_ProjectId",
                table: "Attachments",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_Attachments_CvAttachmentId",
                table: "Portfolios",
                column: "CvAttachmentId",
                principalTable: "Attachments",
                principalColumn: "AttachmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_Attachments_ProfileImageAttachmentId",
                table: "Portfolios",
                column: "ProfileImageAttachmentId",
                principalTable: "Attachments",
                principalColumn: "AttachmentId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_Attachments_CvAttachmentId",
                table: "Portfolios");

            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_Attachments_ProfileImageAttachmentId",
                table: "Portfolios");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropIndex(
                name: "IX_Portfolios_CvAttachmentId",
                table: "Portfolios");

            migrationBuilder.DropIndex(
                name: "IX_Portfolios_ProfileImageAttachmentId",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "CvAttachmentId",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "ProfileImageAttachmentId",
                table: "Portfolios");

            migrationBuilder.AddColumn<string>(
                name: "ProfileImagePath",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
