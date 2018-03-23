using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace userDashBoard.Migrations
{
    public partial class Loop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Messages",
                newName: "Messages");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Comments",
                newName: "Messages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Messages",
                table: "Messages",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "Messages",
                table: "Comments",
                newName: "Content");
        }
    }
}
