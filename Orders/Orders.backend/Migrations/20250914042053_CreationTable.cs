using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orders.backend.Migrations
{
    /// <inheritdoc />
    public partial class CreationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__Countries",
                table: "_Countries");

            migrationBuilder.RenameTable(
                name: "_Countries",
                newName: "Countries");

            migrationBuilder.RenameIndex(
                name: "IX__Countries_Name",
                table: "Countries",
                newName: "IX_Countries_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "_Countries");

            migrationBuilder.RenameIndex(
                name: "IX_Countries_Name",
                table: "_Countries",
                newName: "IX__Countries_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Countries",
                table: "_Countries",
                column: "Id");
        }
    }
}
