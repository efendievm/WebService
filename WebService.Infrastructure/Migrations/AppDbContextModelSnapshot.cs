﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebService.Infrastructure;

#nullable disable

namespace WebService.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebService.Domain.CalculationMeter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("CalculationMeters");
                });

            modelBuilder.Entity("WebService.Domain.CalculationMeterByPeriod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CalculationMeterId")
                        .HasColumnType("integer");

                    b.Property<int>("MeasurementPointId")
                        .HasColumnType("integer");

                    b.Property<int>("PeriodId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CalculationMeterId");

                    b.HasIndex("MeasurementPointId");

                    b.HasIndex("PeriodId", "CalculationMeterId")
                        .IsUnique();

                    b.HasIndex("PeriodId", "MeasurementPointId")
                        .IsUnique();

                    b.ToTable("CalculationMeterByPeriods");
                });

            modelBuilder.Entity("WebService.Domain.ConsumptionObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SubsidiaryOrganizationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubsidiaryOrganizationId");

                    b.ToTable("ConsumptionObjects");
                });

            modelBuilder.Entity("WebService.Domain.CurrentTransformer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<int>("TransformationRatio")
                        .HasColumnType("integer");

                    b.Property<int>("TransformerType")
                        .HasColumnType("integer");

                    b.Property<DateTime>("VerificationDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("CurrentTransformers");
                });

            modelBuilder.Entity("WebService.Domain.MeasurementPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ConsumptionObjectId")
                        .HasColumnType("integer");

                    b.Property<int>("CurrentTransformerId")
                        .HasColumnType("integer");

                    b.Property<int>("MeterId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("VoltageTransformerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ConsumptionObjectId");

                    b.HasIndex("CurrentTransformerId")
                        .IsUnique();

                    b.HasIndex("MeterId")
                        .IsUnique();

                    b.HasIndex("VoltageTransformerId")
                        .IsUnique();

                    b.ToTable("MeasurementPoints");
                });

            modelBuilder.Entity("WebService.Domain.Meter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MeterType")
                        .HasColumnType("integer");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<DateTime>("VerificationDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Meters");
                });

            modelBuilder.Entity("WebService.Domain.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("WebService.Domain.Period", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("End")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Periods");
                });

            modelBuilder.Entity("WebService.Domain.SubsidiaryOrganization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("SubsidiaryOrganizations");
                });

            modelBuilder.Entity("WebService.Domain.SupplyPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ConsumptionObjectId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ConsumptionObjectId");

                    b.ToTable("SupplyPoints");
                });

            modelBuilder.Entity("WebService.Domain.VoltageTransformer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<int>("TransformationRatio")
                        .HasColumnType("integer");

                    b.Property<int>("TransformerType")
                        .HasColumnType("integer");

                    b.Property<DateTime>("VerificationDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("VoltageTransformers");
                });

            modelBuilder.Entity("WebService.Domain.CalculationMeterByPeriod", b =>
                {
                    b.HasOne("WebService.Domain.CalculationMeter", "CalculationMeter")
                        .WithMany("CalculationMeterByPeriods")
                        .HasForeignKey("CalculationMeterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebService.Domain.MeasurementPoint", "MeasurementPoint")
                        .WithMany("CalculationMeterByPeriods")
                        .HasForeignKey("MeasurementPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebService.Domain.Period", "Period")
                        .WithMany("CalculationMeterByPeriods")
                        .HasForeignKey("PeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CalculationMeter");

                    b.Navigation("MeasurementPoint");

                    b.Navigation("Period");
                });

            modelBuilder.Entity("WebService.Domain.ConsumptionObject", b =>
                {
                    b.HasOne("WebService.Domain.SubsidiaryOrganization", "SubsidiaryOrganization")
                        .WithMany("ConsumptionObjects")
                        .HasForeignKey("SubsidiaryOrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubsidiaryOrganization");
                });

            modelBuilder.Entity("WebService.Domain.MeasurementPoint", b =>
                {
                    b.HasOne("WebService.Domain.ConsumptionObject", "ConsumptionObject")
                        .WithMany("MeasurementPoints")
                        .HasForeignKey("ConsumptionObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebService.Domain.CurrentTransformer", "CurrentTransformer")
                        .WithOne("MeasurementPoint")
                        .HasForeignKey("WebService.Domain.MeasurementPoint", "CurrentTransformerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebService.Domain.Meter", "Meter")
                        .WithOne("MeasurementPoint")
                        .HasForeignKey("WebService.Domain.MeasurementPoint", "MeterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebService.Domain.VoltageTransformer", "VoltageTransformer")
                        .WithOne("MeasurementPoint")
                        .HasForeignKey("WebService.Domain.MeasurementPoint", "VoltageTransformerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConsumptionObject");

                    b.Navigation("CurrentTransformer");

                    b.Navigation("Meter");

                    b.Navigation("VoltageTransformer");
                });

            modelBuilder.Entity("WebService.Domain.SubsidiaryOrganization", b =>
                {
                    b.HasOne("WebService.Domain.Organization", "Organization")
                        .WithMany("SubsidaryOrganizations")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("WebService.Domain.SupplyPoint", b =>
                {
                    b.HasOne("WebService.Domain.ConsumptionObject", "ConsumptionObject")
                        .WithMany("SupplyPoints")
                        .HasForeignKey("ConsumptionObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConsumptionObject");
                });

            modelBuilder.Entity("WebService.Domain.CalculationMeter", b =>
                {
                    b.Navigation("CalculationMeterByPeriods");
                });

            modelBuilder.Entity("WebService.Domain.ConsumptionObject", b =>
                {
                    b.Navigation("MeasurementPoints");

                    b.Navigation("SupplyPoints");
                });

            modelBuilder.Entity("WebService.Domain.CurrentTransformer", b =>
                {
                    b.Navigation("MeasurementPoint")
                        .IsRequired();
                });

            modelBuilder.Entity("WebService.Domain.MeasurementPoint", b =>
                {
                    b.Navigation("CalculationMeterByPeriods");
                });

            modelBuilder.Entity("WebService.Domain.Meter", b =>
                {
                    b.Navigation("MeasurementPoint")
                        .IsRequired();
                });

            modelBuilder.Entity("WebService.Domain.Organization", b =>
                {
                    b.Navigation("SubsidaryOrganizations");
                });

            modelBuilder.Entity("WebService.Domain.Period", b =>
                {
                    b.Navigation("CalculationMeterByPeriods");
                });

            modelBuilder.Entity("WebService.Domain.SubsidiaryOrganization", b =>
                {
                    b.Navigation("ConsumptionObjects");
                });

            modelBuilder.Entity("WebService.Domain.VoltageTransformer", b =>
                {
                    b.Navigation("MeasurementPoint")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
