using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleLogger.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Path = table.Column<string>(type: "varchar(200)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "varchar(60)", nullable: false),
                    TimeProcess = table.Column<string>(type: "varchar(200)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_Projetos_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HostName = table.Column<string>(type: "varchar(200)", nullable: true),
                    Browser = table.Column<string>(type: "varchar(200)", nullable: false),
                    OperationSystem = table.Column<string>(type: "varchar(200)", nullable: false),
                    ClientAddress = table.Column<string>(type: "varchar(200)", nullable: true),
                    OperatorAddress = table.Column<string>(type: "varchar(200)", nullable: true),
                    ExternalAddress = table.Column<string>(type: "varchar(200)", nullable: true),
                    LogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Logs_LogId",
                        column: x => x.LogId,
                        principalTable: "Logs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Erros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "varchar(200)", nullable: false),
                    Message = table.Column<string>(type: "varchar(200)", nullable: false),
                    Tracer = table.Column<string>(type: "varchar(max)", nullable: false),
                    LogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Erros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Erros_Logs_LogId",
                        column: x => x.LogId,
                        principalTable: "Logs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Erros_Projetos_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requisicoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Method = table.Column<string>(type: "varchar(200)", nullable: false),
                    Uri = table.Column<string>(type: "varchar(200)", nullable: false),
                    UserAgent = table.Column<string>(type: "varchar(200)", nullable: false),
                    Headers = table.Column<string>(type: "varchar(max)", nullable: true),
                    Body = table.Column<string>(type: "varchar(max)", nullable: true),
                    Sise = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisicoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requisicoes_Logs_LogId",
                        column: x => x.LogId,
                        principalTable: "Logs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Respostas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusCode = table.Column<int>(type: "int", nullable: false),
                    Headers = table.Column<string>(type: "varchar(max)", nullable: true),
                    Sise = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respostas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Respostas_Logs_LogId",
                        column: x => x.LogId,
                        principalTable: "Logs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_LogId",
                table: "Clientes",
                column: "LogId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Erros_LogId",
                table: "Erros",
                column: "LogId");

            migrationBuilder.CreateIndex(
                name: "IX_Erros_ProjectId",
                table: "Erros",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ProjectId",
                table: "Logs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisicoes_LogId",
                table: "Requisicoes",
                column: "LogId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Respostas_LogId",
                table: "Respostas",
                column: "LogId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Erros");

            migrationBuilder.DropTable(
                name: "Requisicoes");

            migrationBuilder.DropTable(
                name: "Respostas");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Projetos");
        }
    }
}
