﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SchoolDatabaseImplement;

namespace SchoolDatabaseImplement.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    [Migration("20220128231951_change-teacher-id-type")]
    partial class changeteacheridtype
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("SchoolDatabaseImplement.Models.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.ActivityElective", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ActivityId")
                        .HasColumnType("integer");

                    b.Property<int>("ElectiveId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("ElectiveId");

                    b.ToTable("ActivityElectives");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.Elective", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("TeacherId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Electives");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.ElectiveMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ElectiveId")
                        .HasColumnType("integer");

                    b.Property<int>("MaterialCount")
                        .HasColumnType("integer");

                    b.Property<int>("MaterialId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ElectiveId");

                    b.HasIndex("MaterialId");

                    b.ToTable("ElectiveMaterials");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.Interest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("TeacherId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.MaterialInterest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("InterestId")
                        .HasColumnType("integer");

                    b.Property<int>("MaterialId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("InterestId");

                    b.HasIndex("MaterialId");

                    b.ToTable("MaterialInterests");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.Medal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ElectiveId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TeacherId")
                        .HasColumnType("text");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ElectiveId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Medals");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Grade")
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.Teacher", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Position")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.Activity", b =>
                {
                    b.HasOne("SchoolDatabaseImplement.Models.Student", "Student")
                        .WithMany("Activities")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.ActivityElective", b =>
                {
                    b.HasOne("SchoolDatabaseImplement.Models.Activity", "Activity")
                        .WithMany("ActivityElectives")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolDatabaseImplement.Models.Elective", "Elective")
                        .WithMany("ActivityElectives")
                        .HasForeignKey("ElectiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("Elective");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.Elective", b =>
                {
                    b.HasOne("SchoolDatabaseImplement.Models.Teacher", "Teacher")
                        .WithMany("Electives")
                        .HasForeignKey("TeacherId");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.ElectiveMaterial", b =>
                {
                    b.HasOne("SchoolDatabaseImplement.Models.Elective", "Elective")
                        .WithMany("ElectiveMaterials")
                        .HasForeignKey("ElectiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolDatabaseImplement.Models.Material", "Material")
                        .WithMany("ElectiveMaterials")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Elective");

                    b.Navigation("Material");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.Interest", b =>
                {
                    b.HasOne("SchoolDatabaseImplement.Models.Student", "Student")
                        .WithMany("Interests")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.Material", b =>
                {
                    b.HasOne("SchoolDatabaseImplement.Models.Teacher", "Teacher")
                        .WithMany("Materials")
                        .HasForeignKey("TeacherId");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.MaterialInterest", b =>
                {
                    b.HasOne("SchoolDatabaseImplement.Models.Interest", "Interest")
                        .WithMany("MaterialInterests")
                        .HasForeignKey("InterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolDatabaseImplement.Models.Material", "Material")
                        .WithMany("MaterialInterests")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interest");

                    b.Navigation("Material");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.Medal", b =>
                {
                    b.HasOne("SchoolDatabaseImplement.Models.Elective", "Elective")
                        .WithMany("Medals")
                        .HasForeignKey("ElectiveId");

                    b.HasOne("SchoolDatabaseImplement.Models.Teacher", "Teacher")
                        .WithMany("Medals")
                        .HasForeignKey("TeacherId");

                    b.Navigation("Elective");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.Activity", b =>
                {
                    b.Navigation("ActivityElectives");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.Elective", b =>
                {
                    b.Navigation("ActivityElectives");

                    b.Navigation("ElectiveMaterials");

                    b.Navigation("Medals");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.Interest", b =>
                {
                    b.Navigation("MaterialInterests");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.Material", b =>
                {
                    b.Navigation("ElectiveMaterials");

                    b.Navigation("MaterialInterests");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.Student", b =>
                {
                    b.Navigation("Activities");

                    b.Navigation("Interests");
                });

            modelBuilder.Entity("SchoolDatabaseImplement.Models.Teacher", b =>
                {
                    b.Navigation("Electives");

                    b.Navigation("Materials");

                    b.Navigation("Medals");
                });
#pragma warning restore 612, 618
        }
    }
}
