using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace alertingSystemBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfigurationsEscalade",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DelaiNiveau0VersNiveau1 = table.Column<int>(type: "integer", nullable: false),
                    DelaiNiveau1VersNiveau2 = table.Column<int>(type: "integer", nullable: false),
                    FrequenceVerification = table.Column<int>(type: "integer", nullable: false),
                    NombreRappelsMax = table.Column<int>(type: "integer", nullable: false),
                    IntervalleRappel = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationsEscalade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Escalades",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AlerteId = table.Column<long>(type: "bigint", nullable: false),
                    NiveauDepart = table.Column<int>(type: "integer", nullable: false),
                    NiveauArrivee = table.Column<int>(type: "integer", nullable: false),
                    DeclenchementAutomatique = table.Column<bool>(type: "boolean", nullable: false),
                    Raison = table.Column<string>(type: "text", nullable: false),
                    DateEscalade = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NotificationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escalades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planificateurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IntervalVerification = table.Column<int>(type: "integer", nullable: false),
                    Actif = table.Column<bool>(type: "boolean", nullable: false),
                    DerniereExecution = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planificateurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReglesEscalade",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    TypeAlerte = table.Column<int>(type: "integer", nullable: false),
                    Criticite = table.Column<int>(type: "integer", nullable: false),
                    NiveauSource = table.Column<int>(type: "integer", nullable: false),
                    NiveauCible = table.Column<int>(type: "integer", nullable: false),
                    DelaiAvantEscalade = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReglesEscalade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    Prenom = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Telephone = table.Column<string>(type: "text", nullable: false),
                    MotDePasseHash = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    Actif = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModification = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alertes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titre = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    TypeAlerte = table.Column<int>(type: "integer", nullable: false),
                    Criticite = table.Column<int>(type: "integer", nullable: false),
                    StatutAlert = table.Column<int>(type: "integer", nullable: false),
                    NiveauEscaladeActuel = table.Column<int>(type: "integer", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateNotification = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateEscaladeN1 = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateEscaladeN2 = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DatePriseEnCharge = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateResolution = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Metadata = table.Column<string>(type: "text", nullable: false),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    ResponsableActuelId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alertes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alertes_Users_ResponsableActuelId",
                        column: x => x.ResponsableActuelId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Historiques",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AlerteId = table.Column<long>(type: "bigint", nullable: false),
                    UtilisateurId = table.Column<long>(type: "bigint", nullable: false),
                    Action = table.Column<string>(type: "text", nullable: false),
                    AncienStatut = table.Column<int>(type: "integer", nullable: false),
                    NouveauStatut = table.Column<int>(type: "integer", nullable: false),
                    Commentaire = table.Column<string>(type: "text", nullable: false),
                    DateAction = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Metadata = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historiques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Historiques_Alertes_AlerteId",
                        column: x => x.AlerteId,
                        principalTable: "Alertes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Historiques_Users_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AlerteId = table.Column<long>(type: "bigint", nullable: false),
                    DestinataireId = table.Column<long>(type: "bigint", nullable: false),
                    TypeNotification = table.Column<int>(type: "integer", nullable: false),
                    Canal = table.Column<int>(type: "integer", nullable: false),
                    Titre = table.Column<string>(type: "text", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    Priorite = table.Column<int>(type: "integer", nullable: false),
                    Envoyee = table.Column<bool>(type: "boolean", nullable: false),
                    Lue = table.Column<bool>(type: "boolean", nullable: false),
                    DateEnvoi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLecture = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Metadata = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Alertes_AlerteId",
                        column: x => x.AlerteId,
                        principalTable: "Alertes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_DestinataireId",
                        column: x => x.DestinataireId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alertes_ResponsableActuelId",
                table: "Alertes",
                column: "ResponsableActuelId");

            migrationBuilder.CreateIndex(
                name: "IX_Historiques_AlerteId",
                table: "Historiques",
                column: "AlerteId");

            migrationBuilder.CreateIndex(
                name: "IX_Historiques_UtilisateurId",
                table: "Historiques",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_AlerteId",
                table: "Notifications",
                column: "AlerteId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_DestinataireId",
                table: "Notifications",
                column: "DestinataireId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigurationsEscalade");

            migrationBuilder.DropTable(
                name: "Escalades");

            migrationBuilder.DropTable(
                name: "Historiques");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Planificateurs");

            migrationBuilder.DropTable(
                name: "ReglesEscalade");

            migrationBuilder.DropTable(
                name: "Alertes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
