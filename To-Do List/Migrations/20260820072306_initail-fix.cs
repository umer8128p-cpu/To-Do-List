using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace To_Do_List.Migrations
{
    /// <inheritdoc />
    public partial class initailfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Teams",
                columns: table => new
                {
                    team_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    team_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    members_num = table.Column<int>(type: "int", nullable: false),
                    team_admin = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_Team__F82DEDBC5DED588A", x => x.team_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_TeamTasks",
                columns: table => new
                {
                    t_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    t_title = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    t_discription = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    t_status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    t_Date = table.Column<DateOnly>(type: "date", nullable: false),
                    t_Time = table.Column<TimeOnly>(type: "time", nullable: false),
                    t_CompletedDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_Team__E579775F4F98DA08", x => x.t_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_User",
                columns: table => new
                {
                    User_Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    User_Password = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    User_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    User_Phone = table.Column<int>(type: "int", nullable: true),
                    Confirm_Password = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_User", x => x.User_Email);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Category",
                columns: table => new
                {
                    Category_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    User = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_Cate__6DB38D6EA1CFE59F", x => x.Category_Id);
                    table.ForeignKey(
                        name: "fk_Category_User",
                        column: x => x.User,
                        principalTable: "tbl_User",
                        principalColumn: "User_Email");
                });

            migrationBuilder.CreateTable(
                name: "tbl_Tasks",
                columns: table => new
                {
                    Task_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Task_Title = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Task_Discription = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Task_Category = table.Column<int>(type: "int", nullable: true),
                    Task_User = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Task_Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Task_Time = table.Column<TimeOnly>(type: "time", nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Completed_Date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_Task__716F4AED2479F05D", x => x.Task_Id);
                    table.ForeignKey(
                        name: "fk_Task_Category",
                        column: x => x.Task_Category,
                        principalTable: "tbl_Category",
                        principalColumn: "Category_Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_Task_User",
                        column: x => x.Task_User,
                        principalTable: "tbl_User",
                        principalColumn: "User_Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Category_User",
                table: "tbl_Category",
                column: "User");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Tasks_Task_Category",
                table: "tbl_Tasks",
                column: "Task_Category");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Tasks_Task_User",
                table: "tbl_Tasks",
                column: "Task_User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Tasks");

            migrationBuilder.DropTable(
                name: "tbl_Teams");

            migrationBuilder.DropTable(
                name: "tbl_TeamTasks");

            migrationBuilder.DropTable(
                name: "tbl_Category");

            migrationBuilder.DropTable(
                name: "tbl_User");
        }
    }
}
