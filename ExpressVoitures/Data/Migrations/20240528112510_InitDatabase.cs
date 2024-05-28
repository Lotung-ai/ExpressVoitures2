using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExpressVoitures.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Finitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Years",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Years", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modeles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modeles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modeles_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    FinitionId = table.Column<int>(type: "int", nullable: false),
                    DateOfPurchase = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Repair = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepairPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DateOfAvailabilityForSale = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SellingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DateOfSale = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_Finitions_FinitionId",
                        column: x => x.FinitionId,
                        principalTable: "Finitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_Modeles_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Modeles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_Years_YearId",
                        column: x => x.YearId,
                        principalTable: "Years",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mazda" },
                    { 2, "Ford" },
                    { 3, "Toyota" },
                    { 4, "Honda" },
                    { 5, "BMW" }
                });

            migrationBuilder.InsertData(
                table: "Finitions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Base" },
                    { 2, "Sport" },
                    { 3, "Luxury" },
                    { 4, "Premium" }
                });

            migrationBuilder.InsertData(
                table: "Years",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, 1990 },
                    { 2, 1991 },
                    { 3, 1992 },
                    { 4, 1993 },
                    { 5, 1994 },
                    { 6, 1995 },
                    { 7, 1996 },
                    { 8, 1997 },
                    { 9, 1998 },
                    { 10, 1999 },
                    { 11, 2000 },
                    { 12, 2001 },
                    { 13, 2002 },
                    { 14, 2003 },
                    { 15, 2004 },
                    { 16, 2005 },
                    { 17, 2006 },
                    { 18, 2007 },
                    { 19, 2008 },
                    { 20, 2009 },
                    { 21, 2010 },
                    { 22, 2011 },
                    { 23, 2012 },
                    { 24, 2013 },
                    { 25, 2014 },
                    { 26, 2015 },
                    { 27, 2016 },
                    { 28, 2017 },
                    { 29, 2018 },
                    { 30, 2019 },
                    { 31, 2020 },
                    { 32, 2021 },
                    { 33, 2022 },
                    { 34, 2023 },
                    { 35, 2024 }
                });

            migrationBuilder.InsertData(
                table: "Modeles",
                columns: new[] { "Id", "BrandId", "Name" },
                values: new object[,]
                {
                    { 1, 2, "Focus" },
                    { 2, 2, "Mustang" },
                    { 3, 3, "Corolla" },
                    { 4, 3, "Camry" },
                    { 5, 1, "2" },
                    { 6, 1, "3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrandId",
                table: "Cars",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_FinitionId",
                table: "Cars",
                column: "FinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ModelId",
                table: "Cars",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_YearId",
                table: "Cars",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_Modeles_BrandId",
                table: "Modeles",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Finitions");

            migrationBuilder.DropTable(
                name: "Modeles");

            migrationBuilder.DropTable(
                name: "Years");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
