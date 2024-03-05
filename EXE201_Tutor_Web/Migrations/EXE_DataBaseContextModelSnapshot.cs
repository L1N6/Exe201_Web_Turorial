﻿// <auto-generated />
using System;
using EXE201_Tutor_Web.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EXE201_Tutor_Web.Migrations
{
    [DbContext(typeof(EXE_DataBaseContext))]
    partial class EXE_DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EXE201_Tutor_Web.Entities.Coursera", b =>
                {
                    b.Property<int>("CourseraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CodeName")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("HashTag")
                        .HasColumnType("longtext");

                    b.Property<string>("Image")
                        .HasColumnType("longtext");

                    b.Property<string>("Major")
                        .HasColumnType("longtext");

                    b.Property<double>("Money")
                        .HasColumnType("double");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.Property<int>("TotalDate")
                        .HasColumnType("int");

                    b.HasKey("CourseraId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courseras");
                });

            modelBuilder.Entity("EXE201_Tutor_Web.Entities.CourseraDetail", b =>
                {
                    b.Property<int>("CourseraDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CodeName")
                        .HasColumnType("longtext");

                    b.Property<int>("CourseraId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("CourseraDetailId");

                    b.HasIndex("CourseraId");

                    b.ToTable("CourseraDetails");
                });

            modelBuilder.Entity("EXE201_Tutor_Web.Entities.Mooc", b =>
                {
                    b.Property<int>("MoocId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CodeName")
                        .HasColumnType("longtext");

                    b.Property<int>("CourseraDetailId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("MinScore")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("MoocId");

                    b.HasIndex("CourseraDetailId");

                    b.ToTable("Moocs");
                });

            modelBuilder.Entity("EXE201_Tutor_Web.Entities.MoocDetail", b =>
                {
                    b.Property<int>("MoocDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Answer")
                        .HasColumnType("longtext");

                    b.Property<string>("CodeName")
                        .HasColumnType("longtext");

                    b.Property<string>("Content")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("MoocId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int?>("Score")
                        .HasColumnType("int");

                    b.Property<int?>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("MoocDetailId");

                    b.HasIndex("MoocId");

                    b.ToTable("MoocDetails");
                });

            modelBuilder.Entity("EXE201_Tutor_Web.Entities.OnCoursera", b =>
                {
                    b.Property<int>("OnCourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CourseraId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("OnCourseId");

                    b.HasIndex("CourseraId");

                    b.HasIndex("StudentId");

                    b.ToTable("OnCoursera");
                });

            modelBuilder.Entity("EXE201_Tutor_Web.Entities.OnCourseraDetail", b =>
                {
                    b.Property<int>("OnCourseDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CourseraDetailId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("OnCourseId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.HasKey("OnCourseDetailId");

                    b.HasIndex("CourseraDetailId");

                    b.HasIndex("OnCourseId");

                    b.ToTable("OnCourseDetails");
                });

            modelBuilder.Entity("EXE201_Tutor_Web.Entities.OnMooc", b =>
                {
                    b.Property<int>("OnMoocId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateSuccess")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("MoocId")
                        .HasColumnType("int");

                    b.Property<int?>("OnCourseDetailId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.Property<int?>("TotalScore")
                        .HasColumnType("int");

                    b.HasKey("OnMoocId");

                    b.HasIndex("MoocId");

                    b.HasIndex("OnCourseDetailId");

                    b.ToTable("OnMoocs");
                });

            modelBuilder.Entity("EXE201_Tutor_Web.Entities.OnMoocDetail", b =>
                {
                    b.Property<int>("OnMoocDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Answer")
                        .HasColumnType("longtext");

                    b.Property<int?>("MoocDetailId")
                        .HasColumnType("int");

                    b.Property<int?>("OnMoocId")
                        .HasColumnType("int");

                    b.Property<int?>("Score")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.HasKey("OnMoocDetailId");

                    b.HasIndex("MoocDetailId");

                    b.HasIndex("OnMoocId");

                    b.ToTable("OnMoocDetails");
                });

            modelBuilder.Entity("EXE201_Tutor_Web.Entities.OrderCoursera", b =>
                {
                    b.Property<int>("OrderCourseraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BankDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("BankNumber")
                        .HasColumnType("longtext");

                    b.Property<int>("CourseraId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateAccepted")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<double>("Money")
                        .HasColumnType("double");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool?>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("OrderCourseraId");

                    b.HasIndex("CourseraId");

                    b.HasIndex("StudentId");

                    b.ToTable("OrderCourseras");
                });

            modelBuilder.Entity("EXE201_Tutor_Web.Entities.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("Avatar")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EXE201_Tutor_Web.Entities.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("EXE201_Tutor_Web.Entities.Coursera", b =>
                {
                    b.HasOne("EXE201_Tutor_Web.Entities.Teacher", "Teacher")
                        .WithMany("Courseras")
                        .HasForeignKey("TeacherId");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("EXE201_Tutor_Web.Entities.CourseraDetail", b =>
                {
                    b.HasOne("EXE201_Tutor_Web.Entities.Coursera", "Coursera")
                        .WithMany("CourseraDetails")
                        .HasForeignKey("CourseraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coursera");
                });

            modelBuilder.Entity("EXE201_Tutor_Web.Entities.Mooc", b =>
                {
                    b.HasOne("EXE201_Tutor_Web.Entities.CourseraDetail", "CourseraDetail")
                        .WithMany("Moocs")
                        .HasForeignKey("CourseraDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseraDetail");
                });

            modelBuilder.Entity("EXE201_Tutor_Web.Entities.MoocDetail", b =>
                {
                    b.HasOne("EXE201_Tutor_Web.Entities.Mooc", "Mooc")
                        .WithMany("MoocDetails")
                        .HasForeignKey("MoocId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mooc");
                });

            modelBuilder.Entity("EXE201_Tutor_Web.Entities.OnCoursera", b =>
                {
                    b.HasOne("EXE201_Tutor_Web.Entities.Coursera", "Coursera")
                        .WithMany("OnCoursera")
                        .HasForeignKey("CourseraId");

                    b.HasOne("EXE201_Tutor_Web.Entities.Student", "Student")
                        .WithMany("OnCoursera")
                        .HasForeignKey("StudentId");

                    b.Navigation("Coursera");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EXE201_Tutor_Web.Entities.OnCourseraDetail", b =>
                {
                    b.HasOne("EXE201_Tutor_Web.Entities.CourseraDetail", "CourseraDetail")
                        .WithMany("OnCourseraDetails")
                        .HasForeignKey("CourseraDetailId");

                    b.HasOne("EXE201_Tutor_Web.Entities.OnCoursera", "OnCoursera")
                        .WithMany("OnCourseDetails")
                        .HasForeignKey("OnCourseId");

                    b.Navigation("CourseraDetail");

                    b.Navigation("OnCoursera");
                });

            modelBuilder.Entity("EXE201_Tutor_Web.Entities.OnMooc", b =>
                {
                    b.HasOne("EXE201_Tutor_Web.Entities.Mooc", "Mooc")
                        .WithMany("OnMoocs")
                        .HasForeignKey("MoocId");

                    b.HasOne("EXE201_Tutor_Web.Entities.OnCourseraDetail", "OnCourseDetail")
                        .WithMany("OnMoocs")
                        .HasForeignKey("OnCourseDetailId");

                    b.Navigation("Mooc");

                    b.Navigation("OnCourseDetail");
                });

            modelBuilder.Entity("EXE201_Tutor_Web.Entities.OnMoocDetail", b =>
                {
                    b.HasOne("EXE201_Tutor_Web.Entities.MoocDetail", "MoocDetail")
                        .WithMany("OnMoocDetails")
                        .HasForeignKey("MoocDetailId");

                    b.HasOne("EXE201_Tutor_Web.Entities.OnMooc", "OnMooc")
                        .WithMany("OnMoocDetails")
                        .HasForeignKey("OnMoocId");

                    b.Navigation("MoocDetail");

                    b.Navigation("OnMooc");
                });

            modelBuilder.Entity("EXE201_Tutor_Web.Entities.OrderCoursera", b =>
                {
                    b.HasOne("EXE201_Tutor_Web.Entities.Coursera", "Coursera")
                        .WithMany("OrderCourseras")
                        .HasForeignKey("CourseraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EXE201_Tutor_Web.Entities.Student", "Student")
                        .WithMany("OrderCoursera")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coursera");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EXE201_Tutor_Web.Entities.Coursera", b =>
                {
                    b.Navigation("CourseraDetails");

                    b.Navigation("OnCoursera");

                    b.Navigation("OrderCourseras");
                });

            modelBuilder.Entity("EXE201_Tutor_Web.Entities.CourseraDetail", b =>
                {
                    b.Navigation("Moocs");

                    b.Navigation("OnCourseraDetails");
                });

            modelBuilder.Entity("EXE201_Tutor_Web.Entities.Mooc", b =>
                {
                    b.Navigation("MoocDetails");

                    b.Navigation("OnMoocs");
                });

            modelBuilder.Entity("EXE201_Tutor_Web.Entities.MoocDetail", b =>
                {
                    b.Navigation("OnMoocDetails");
                });

            modelBuilder.Entity("EXE201_Tutor_Web.Entities.OnCoursera", b =>
                {
                    b.Navigation("OnCourseDetails");
                });

            modelBuilder.Entity("EXE201_Tutor_Web.Entities.OnCourseraDetail", b =>
                {
                    b.Navigation("OnMoocs");
                });

            modelBuilder.Entity("EXE201_Tutor_Web.Entities.OnMooc", b =>
                {
                    b.Navigation("OnMoocDetails");
                });

            modelBuilder.Entity("EXE201_Tutor_Web.Entities.Student", b =>
                {
                    b.Navigation("OnCoursera");

                    b.Navigation("OrderCoursera");
                });

            modelBuilder.Entity("EXE201_Tutor_Web.Entities.Teacher", b =>
                {
                    b.Navigation("Courseras");
                });
#pragma warning restore 612, 618
        }
    }
}
