using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Konyvtar.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Diakok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nev = table.Column<string>(type: "longtext", nullable: false),
                    Szul_hely = table.Column<string>(type: "longtext", nullable: false),
                    Szul_ido = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Lakcim = table.Column<string>(type: "longtext", nullable: false),
                    Osztaly = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    Aktiv = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Letrehozva = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modositva = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diakok", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Konyvek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Cim_hun = table.Column<string>(type: "longtext", nullable: false),
                    Cim = table.Column<string>(type: "longtext", nullable: false),
                    Ajanlo = table.Column<string>(type: "longtext", nullable: false),
                    Kiadas_eve = table.Column<int>(type: "int", nullable: false),
                    Peldanyszam = table.Column<int>(type: "int", nullable: false),
                    Szpeldany = table.Column<int>(type: "int", nullable: false),
                    Kiado = table.Column<string>(type: "longtext", nullable: false),
                    Mufaj = table.Column<string>(type: "longtext", nullable: false),
                    Szerzo = table.Column<string>(type: "longtext", nullable: false),
                    Max_kolcsonzes = table.Column<int>(type: "int", nullable: false),
                    Aktiv = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Letrehozva = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modositva = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konyvek", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Mufajok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Mufaj = table.Column<string>(type: "longtext", nullable: false),
                    Aktiv = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Letrehozva = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modositva = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mufajok", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Szerzok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nev = table.Column<string>(type: "longtext", nullable: false),
                    Szul_ido = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Szul_hely = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Ismerteto = table.Column<string>(type: "longtext", nullable: false),
                    Aktiv = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Letrehozva = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modositva = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Szerzok", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Olvasojegyek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Diak_id = table.Column<int>(type: "int", nullable: false),
                    Kiadas_datum = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Lejarati_datum = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Aktiv = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Letrehozva = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modositva = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Olvasojegyek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Olvasojegyek_Diakok_Diak_id",
                        column: x => x.Diak_id,
                        principalTable: "Diakok",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Kolcsonzesek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Diak_id = table.Column<int>(type: "int", nullable: false),
                    Konyv_id = table.Column<int>(type: "int", nullable: false),
                    Kolcsonzes_datum = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Visszahozatal_hatarido = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Visszahozatal_datum = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Aktiv = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Letrehozva = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modositva = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kolcsonzesek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kolcsonzesek_Diakok_Diak_id",
                        column: x => x.Diak_id,
                        principalTable: "Diakok",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kolcsonzesek_Konyvek_Konyv_id",
                        column: x => x.Konyv_id,
                        principalTable: "Konyvek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Mufajkonyvek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Mufaj_id = table.Column<int>(type: "int", nullable: false),
                    Konyv_id = table.Column<int>(type: "int", nullable: false),
                    Aktiv = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Letrehozva = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modositva = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mufajkonyvek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mufajkonyvek_Konyvek_Konyv_id",
                        column: x => x.Konyv_id,
                        principalTable: "Konyvek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mufajkonyvek_Mufajok_Mufaj_id",
                        column: x => x.Mufaj_id,
                        principalTable: "Mufajok",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Szerzokonyvek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Szerzo_id = table.Column<int>(type: "int", nullable: false),
                    Konyv_id = table.Column<int>(type: "int", nullable: false),
                    Aktiv = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Letrehozva = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modositva = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Szerzokonyvek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Szerzokonyvek_Konyvek_Konyv_id",
                        column: x => x.Konyv_id,
                        principalTable: "Konyvek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Szerzokonyvek_Szerzok_Szerzo_id",
                        column: x => x.Szerzo_id,
                        principalTable: "Szerzok",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Kolcsonzesek_Diak_id",
                table: "Kolcsonzesek",
                column: "Diak_id");

            migrationBuilder.CreateIndex(
                name: "IX_Kolcsonzesek_Konyv_id",
                table: "Kolcsonzesek",
                column: "Konyv_id");

            migrationBuilder.CreateIndex(
                name: "IX_Mufajkonyvek_Konyv_id",
                table: "Mufajkonyvek",
                column: "Konyv_id");

            migrationBuilder.CreateIndex(
                name: "IX_Mufajkonyvek_Mufaj_id",
                table: "Mufajkonyvek",
                column: "Mufaj_id");

            migrationBuilder.CreateIndex(
                name: "IX_Olvasojegyek_Diak_id",
                table: "Olvasojegyek",
                column: "Diak_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Szerzokonyvek_Konyv_id",
                table: "Szerzokonyvek",
                column: "Konyv_id");

            migrationBuilder.CreateIndex(
                name: "IX_Szerzokonyvek_Szerzo_id",
                table: "Szerzokonyvek",
                column: "Szerzo_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kolcsonzesek");

            migrationBuilder.DropTable(
                name: "Mufajkonyvek");

            migrationBuilder.DropTable(
                name: "Olvasojegyek");

            migrationBuilder.DropTable(
                name: "Szerzokonyvek");

            migrationBuilder.DropTable(
                name: "Mufajok");

            migrationBuilder.DropTable(
                name: "Diakok");

            migrationBuilder.DropTable(
                name: "Konyvek");

            migrationBuilder.DropTable(
                name: "Szerzok");
        }
    }
}
