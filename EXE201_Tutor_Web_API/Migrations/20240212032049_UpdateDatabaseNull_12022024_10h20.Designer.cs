﻿// <auto-generated />
using System;
using EXE201_Tutor_Web_API.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EXE201_Tutor_Web_API.Migrations
{
    [DbContext(typeof(Exe201_Tutor_Context))]
    [Migration("20240212032049_UpdateDatabaseNull_12022024_10h20")]
    partial class UpdateDatabaseNull_12022024_10h20
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EXE201_Tutor_Web_API.Entites.Coursera", b =>
                {
                    b.Property<int>("CourseraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseraId"), 1L, 1);

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CourseraId");

                    b.ToTable("Coursera");
                });

            modelBuilder.Entity("EXE201_Tutor_Web_API.Entites.CourseraDetail", b =>
                {
                    b.Property<int>("CourseraDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseraDetailId"), 1L, 1);

                    b.Property<int>("CourseraId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseraDetailId");

                    b.ToTable("CourseraDetail");
                });

            modelBuilder.Entity("EXE201_Tutor_Web_API.Entites.Mooc", b =>
                {
                    b.Property<int>("MoocId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MoocId"), 1L, 1);

                    b.Property<int>("CourseraDetailId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MinScore")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MoocId");

                    b.ToTable("Mooc");
                });

            modelBuilder.Entity("EXE201_Tutor_Web_API.Entites.MoocDetail", b =>
                {
                    b.Property<int>("MoocDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MoocDetailId"), 1L, 1);

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("MoocId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Score")
                        .HasColumnType("int");

                    b.Property<int?>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("MoocDetailId");

                    b.ToTable("MoocDetail");
                });

            modelBuilder.Entity("EXE201_Tutor_Web_API.Entites.OnCourseDetail", b =>
                {
                    b.Property<int>("OnCourseDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OnCourseDetailId"), 1L, 1);

                    b.Property<int>("CourseraDetailId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("OnCourseId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OnCourseDetailId");

                    b.ToTable("OnCourseDetail");
                });

            modelBuilder.Entity("EXE201_Tutor_Web_API.Entites.OnMooc", b =>
                {
                    b.Property<int>("OnMoocId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OnMoocId"), 1L, 1);

                    b.Property<DateTime?>("DateSuccess")
                        .HasColumnType("datetime2");

                    b.Property<int>("MoocId")
                        .HasColumnType("int");

                    b.Property<int>("OnCourseDetailId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TotalScore")
                        .HasColumnType("int");

                    b.HasKey("OnMoocId");

                    b.ToTable("OnMooc");
                });

            modelBuilder.Entity("EXE201_Tutor_Web_API.Entites.OnMoocDetail", b =>
                {
                    b.Property<int>("OnMoocDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OnMoocDetailId"), 1L, 1);

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MoocDetailId")
                        .HasColumnType("int");

                    b.Property<int>("OnMoocId")
                        .HasColumnType("int");

                    b.Property<int?>("Score")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OnMoocDetailId");

                    b.ToTable("OnMoocDetail");
                });

            modelBuilder.Entity("EXE201_Tutor_Web_API.Entites.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
