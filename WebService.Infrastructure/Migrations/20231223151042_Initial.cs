using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalculationMeters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculationMeters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrentTransformers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    TransformerType = table.Column<int>(type: "integer", nullable: false),
                    VerificationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TransformationRatio = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentTransformers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    MeterType = table.Column<int>(type: "integer", nullable: false),
                    VerificationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Periods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VoltageTransformers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    TransformerType = table.Column<int>(type: "integer", nullable: false),
                    VerificationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TransformationRatio = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoltageTransformers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubsidiaryOrganizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    OrganizationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubsidiaryOrganizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubsidiaryOrganizations_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsumptionObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    SubsidiaryOrganizationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumptionObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumptionObjects_SubsidiaryOrganizations_SubsidiaryOrgani~",
                        column: x => x.SubsidiaryOrganizationId,
                        principalTable: "SubsidiaryOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ConsumptionObjectId = table.Column<int>(type: "integer", nullable: false),
                    MeterId = table.Column<int>(type: "integer", nullable: false),
                    CurrentTransformerId = table.Column<int>(type: "integer", nullable: false),
                    VoltageTransformerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeasurementPoints_ConsumptionObjects_ConsumptionObjectId",
                        column: x => x.ConsumptionObjectId,
                        principalTable: "ConsumptionObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeasurementPoints_CurrentTransformers_CurrentTransformerId",
                        column: x => x.CurrentTransformerId,
                        principalTable: "CurrentTransformers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeasurementPoints_Meters_MeterId",
                        column: x => x.MeterId,
                        principalTable: "Meters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeasurementPoints_VoltageTransformers_VoltageTransformerId",
                        column: x => x.VoltageTransformerId,
                        principalTable: "VoltageTransformers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplyPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ConsumptionObjectId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplyPoints_ConsumptionObjects_ConsumptionObjectId",
                        column: x => x.ConsumptionObjectId,
                        principalTable: "ConsumptionObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalculationMeterByPeriods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PeriodId = table.Column<int>(type: "integer", nullable: false),
                    MeasurementPointId = table.Column<int>(type: "integer", nullable: false),
                    CalculationMeterId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculationMeterByPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalculationMeterByPeriods_CalculationMeters_CalculationMete~",
                        column: x => x.CalculationMeterId,
                        principalTable: "CalculationMeters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalculationMeterByPeriods_MeasurementPoints_MeasurementPoin~",
                        column: x => x.MeasurementPointId,
                        principalTable: "MeasurementPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalculationMeterByPeriods_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalculationMeterByPeriods_CalculationMeterId",
                table: "CalculationMeterByPeriods",
                column: "CalculationMeterId");

            migrationBuilder.CreateIndex(
                name: "IX_CalculationMeterByPeriods_MeasurementPointId",
                table: "CalculationMeterByPeriods",
                column: "MeasurementPointId");

            migrationBuilder.CreateIndex(
                name: "IX_CalculationMeterByPeriods_PeriodId_CalculationMeterId",
                table: "CalculationMeterByPeriods",
                columns: new[] { "PeriodId", "CalculationMeterId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CalculationMeterByPeriods_PeriodId_MeasurementPointId",
                table: "CalculationMeterByPeriods",
                columns: new[] { "PeriodId", "MeasurementPointId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConsumptionObjects_SubsidiaryOrganizationId",
                table: "ConsumptionObjects",
                column: "SubsidiaryOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementPoints_ConsumptionObjectId",
                table: "MeasurementPoints",
                column: "ConsumptionObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementPoints_CurrentTransformerId",
                table: "MeasurementPoints",
                column: "CurrentTransformerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementPoints_MeterId",
                table: "MeasurementPoints",
                column: "MeterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementPoints_VoltageTransformerId",
                table: "MeasurementPoints",
                column: "VoltageTransformerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubsidiaryOrganizations_OrganizationId",
                table: "SubsidiaryOrganizations",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyPoints_ConsumptionObjectId",
                table: "SupplyPoints",
                column: "ConsumptionObjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculationMeterByPeriods");

            migrationBuilder.DropTable(
                name: "SupplyPoints");

            migrationBuilder.DropTable(
                name: "CalculationMeters");

            migrationBuilder.DropTable(
                name: "MeasurementPoints");

            migrationBuilder.DropTable(
                name: "Periods");

            migrationBuilder.DropTable(
                name: "ConsumptionObjects");

            migrationBuilder.DropTable(
                name: "CurrentTransformers");

            migrationBuilder.DropTable(
                name: "Meters");

            migrationBuilder.DropTable(
                name: "VoltageTransformers");

            migrationBuilder.DropTable(
                name: "SubsidiaryOrganizations");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
