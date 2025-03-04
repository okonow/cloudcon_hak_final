﻿// <auto-generated />
using System;
using Domain.Enums;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240506072647_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "complexity", new[] { "easy", "normal", "difficult" });
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("DepartmentDescription")
                        .HasColumnType("text");

                    b.Property<Guid[]>("DepartmentEmployeesId")
                        .HasColumnType("uuid[]");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("DirectorId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Domain.Entities.EmployeeStatistics", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<TimeSpan>("AverageTimeForCompletingJob")
                        .HasColumnType("interval");

                    b.Property<int>("CompletedDifficultJobsCount")
                        .HasColumnType("integer");

                    b.Property<int>("CompletedEasyJobsCount")
                        .HasColumnType("integer");

                    b.Property<int>("CompletedNormalJobsCount")
                        .HasColumnType("integer");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Statistics");
                });

            modelBuilder.Entity("Domain.Entities.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Domain.Entities.Job", b =>
                {
                    b.OwnsMany("Domain.ValueObjects.JobAnswer", "JobAnswers", b1 =>
                        {
                            b1.Property<Guid>("JobId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<string>("Comment")
                                .HasColumnType("text");

                            b1.Property<DateTime>("DepartureTime")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("Description")
                                .HasColumnType("text");

                            b1.HasKey("JobId", "Id");

                            b1.ToTable("JobAnswer");

                            b1.WithOwner()
                                .HasForeignKey("JobId");

                            b1.OwnsOne("Domain.ValueObjects.StoredFile", "AttachedFile", b2 =>
                                {
                                    b2.Property<Guid>("JobAnswerJobId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("JobAnswerId")
                                        .HasColumnType("integer");

                                    b2.Property<byte[]>("Data")
                                        .IsRequired()
                                        .HasColumnType("bytea");

                                    b2.Property<string>("Extension")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.Property<string>("Name")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.HasKey("JobAnswerJobId", "JobAnswerId");

                                    b2.ToTable("JobAnswer");

                                    b2.WithOwner()
                                        .HasForeignKey("JobAnswerJobId", "JobAnswerId");
                                });

                            b1.Navigation("AttachedFile");
                        });

                    b.OwnsOne("Domain.ValueObjects.JobMetadata", "JobMetadata", b1 =>
                        {
                            b1.Property<Guid>("JobId")
                                .HasColumnType("uuid");

                            b1.Property<Complexity>("Complexity")
                                .HasColumnType("complexity");

                            b1.Property<Guid>("CreatorId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("Deadline")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<Guid?>("WorkerId")
                                .HasColumnType("uuid");

                            b1.HasKey("JobId");

                            b1.ToTable("Jobs");

                            b1.WithOwner()
                                .HasForeignKey("JobId");
                        });

                    b.Navigation("JobAnswers");

                    b.Navigation("JobMetadata")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
