using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TodoTracker.Migrations
{
    /// <inheritdoc />
    public partial class SeedTaskAndCategoryData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskCategoryTaskModel");

            migrationBuilder.CreateTable(
                name: "TaskModelTaskCategory",
                columns: table => new
                {
                    TasksId = table.Column<int>(type: "int", nullable: false),
                    CategoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskModelTaskCategory", x => new { x.TasksId, x.CategoriesId });
                    table.ForeignKey(
                        name: "FK_TaskModelTaskCategory_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskModelTaskCategory_Tasks_TasksId",
                        column: x => x.TasksId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Work" },
                    { 2, "Personal" },
                    { 3, "Urgent" },
                    { 4, "Health" },
                    { 5, "Learning" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "IsCompleted", "TaskAssignDate", "TaskDescription", "TaskTitle" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete the annual financial report", "Finish report" },
                    { 2, false, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Milk, eggs, bread", "Buy groceries" },
                    { 3, false, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Routine check-up", "Doctor appointment" },
                    { 4, false, new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Go through the Microsoft EF Core documentation", "Study EF Core" },
                    { 5, false, new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Resolve issues in the API endpoints", "Fix bugs in project" }
                });

            migrationBuilder.InsertData(
                table: "TaskModelTaskCategory",
                columns: new[] { "CategoriesId", "TasksId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 1 },
                    { 2, 2 },
                    { 4, 3 },
                    { 5, 4 },
                    { 1, 5 },
                    { 3, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskModelTaskCategory_CategoriesId",
                table: "TaskModelTaskCategory",
                column: "CategoriesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskModelTaskCategory");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.CreateTable(
                name: "TaskCategoryTaskModel",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    TasksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskCategoryTaskModel", x => new { x.CategoriesId, x.TasksId });
                    table.ForeignKey(
                        name: "FK_TaskCategoryTaskModel_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskCategoryTaskModel_Tasks_TasksId",
                        column: x => x.TasksId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskCategoryTaskModel_TasksId",
                table: "TaskCategoryTaskModel",
                column: "TasksId");
        }
    }
}
