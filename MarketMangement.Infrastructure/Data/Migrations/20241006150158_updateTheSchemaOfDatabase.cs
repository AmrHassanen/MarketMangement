using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketMangement.MVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateTheSchemaOfDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DevicePropertyItem");

            migrationBuilder.DropTable(
                name: "DevicePropertyItems");

            migrationBuilder.AddColumn<int>(
                name: "DeviceId",
                table: "PropertyItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyItems_DeviceId",
                table: "PropertyItems",
                column: "DeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyItems_Devices_DeviceId",
                table: "PropertyItems",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyItems_Devices_DeviceId",
                table: "PropertyItems");

            migrationBuilder.DropIndex(
                name: "IX_PropertyItems_DeviceId",
                table: "PropertyItems");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "PropertyItems");

            migrationBuilder.CreateTable(
                name: "DevicePropertyItem",
                columns: table => new
                {
                    DevicesID = table.Column<int>(type: "int", nullable: false),
                    properyItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevicePropertyItem", x => new { x.DevicesID, x.properyItemsId });
                    table.ForeignKey(
                        name: "FK_DevicePropertyItem_Devices_DevicesID",
                        column: x => x.DevicesID,
                        principalTable: "Devices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DevicePropertyItem_PropertyItems_properyItemsId",
                        column: x => x.properyItemsId,
                        principalTable: "PropertyItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DevicePropertyItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    PropertyItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevicePropertyItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DevicePropertyItems_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DevicePropertyItems_PropertyItems_PropertyItemId",
                        column: x => x.PropertyItemId,
                        principalTable: "PropertyItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DevicePropertyItem_properyItemsId",
                table: "DevicePropertyItem",
                column: "properyItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_DevicePropertyItems_DeviceId",
                table: "DevicePropertyItems",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DevicePropertyItems_PropertyItemId",
                table: "DevicePropertyItems",
                column: "PropertyItemId");
        }
    }
}
