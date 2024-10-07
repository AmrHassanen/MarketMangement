using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketMangement.MVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateOFtheProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceCategories_properties_PropertyId",
                table: "DeviceCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_DevicePropertyItems_ProperyItems_PropertyItemId",
                table: "DevicePropertyItems");

            migrationBuilder.DropTable(
                name: "DeviceProperyItem");

            migrationBuilder.DropTable(
                name: "ProperyItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_properties",
                table: "properties");

            migrationBuilder.RenameTable(
                name: "properties",
                newName: "Properties");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Properties",
                table: "Properties",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "PropertyItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyItems", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_DevicePropertyItem_properyItemsId",
                table: "DevicePropertyItem",
                column: "properyItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceCategories_Properties_PropertyId",
                table: "DeviceCategories",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DevicePropertyItems_PropertyItems_PropertyItemId",
                table: "DevicePropertyItems",
                column: "PropertyItemId",
                principalTable: "PropertyItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceCategories_Properties_PropertyId",
                table: "DeviceCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_DevicePropertyItems_PropertyItems_PropertyItemId",
                table: "DevicePropertyItems");

            migrationBuilder.DropTable(
                name: "DevicePropertyItem");

            migrationBuilder.DropTable(
                name: "PropertyItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Properties",
                table: "Properties");

            migrationBuilder.RenameTable(
                name: "Properties",
                newName: "properties");

            migrationBuilder.AddPrimaryKey(
                name: "PK_properties",
                table: "properties",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "ProperyItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProperyItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceProperyItem",
                columns: table => new
                {
                    DevicesID = table.Column<int>(type: "int", nullable: false),
                    properyItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceProperyItem", x => new { x.DevicesID, x.properyItemsId });
                    table.ForeignKey(
                        name: "FK_DeviceProperyItem_Devices_DevicesID",
                        column: x => x.DevicesID,
                        principalTable: "Devices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceProperyItem_ProperyItems_properyItemsId",
                        column: x => x.properyItemsId,
                        principalTable: "ProperyItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceProperyItem_properyItemsId",
                table: "DeviceProperyItem",
                column: "properyItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceCategories_properties_PropertyId",
                table: "DeviceCategories",
                column: "PropertyId",
                principalTable: "properties",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DevicePropertyItems_ProperyItems_PropertyItemId",
                table: "DevicePropertyItems",
                column: "PropertyItemId",
                principalTable: "ProperyItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
