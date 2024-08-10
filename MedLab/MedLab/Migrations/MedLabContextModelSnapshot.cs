﻿// <auto-generated />
using System;
using MedLab.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MedLab.Migrations
{
    [DbContext(typeof(MedLabContext))]
    partial class MedLabContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MedLab.Models.ContactMessage", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageID"));

                    b.Property<DateTime?>("DateReceived")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("IsResolved")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("MessageID");

                    b.ToTable("ContactMessage");
                });

            modelBuilder.Entity("MedLab.Models.Invoice", b =>
                {
                    b.Property<int>("InvoiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceID"));

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("BookingID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("InvoiceID");

                    b.HasIndex("BookingID");

                    b.HasIndex("UserID");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("MedLab.Models.Payment", b =>
                {
                    b.Property<int>("PaymentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentID"));

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool?>("IsRefunded")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentMethod")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RazorpayOrderId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RazorpayPaymentId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RazorpaySignature")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("PaymentID");

                    b.HasIndex("UserID");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("MedLab.Models.RefreshToken", b =>
                {
                    b.Property<int>("TokenID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TokenID"));

                    b.Property<DateTime?>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsRevoked")
                        .HasColumnType("bit");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("TokenID");

                    b.HasIndex("UserID");

                    b.ToTable("RefreshToken");
                });

            modelBuilder.Entity("MedLab.Models.Report", b =>
                {
                    b.Property<int>("ReportID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReportID"));

                    b.Property<int?>("BookingID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateIssued")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LabAssistantID")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReportURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TestID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ReportID");

                    b.HasIndex("BookingID");

                    b.HasIndex("LabAssistantID");

                    b.HasIndex("TestID");

                    b.HasIndex("UserID");

                    b.ToTable("Report");
                });

            modelBuilder.Entity("MedLab.Models.Test", b =>
                {
                    b.Property<int>("TestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestID"));

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PreparationInstructions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TestName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TestID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("MedLab.Models.TestBooking", b =>
                {
                    b.Property<int>("BookingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingID"));

                    b.Property<DateTime?>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LabAssistantID")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("TestID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("BookingID");

                    b.HasIndex("LabAssistantID");

                    b.HasIndex("TestID");

                    b.HasIndex("UserID");

                    b.ToTable("TestBooking");
                });

            modelBuilder.Entity("MedLab.Models.TestCategory", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("TestCategory");
                });

            modelBuilder.Entity("MedLab.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MedLab.Models.Invoice", b =>
                {
                    b.HasOne("MedLab.Models.TestBooking", "TestBooking")
                        .WithMany()
                        .HasForeignKey("BookingID");

                    b.HasOne("MedLab.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("TestBooking");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MedLab.Models.Payment", b =>
                {
                    b.HasOne("MedLab.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MedLab.Models.RefreshToken", b =>
                {
                    b.HasOne("MedLab.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MedLab.Models.Report", b =>
                {
                    b.HasOne("MedLab.Models.TestBooking", "TestBooking")
                        .WithMany()
                        .HasForeignKey("BookingID");

                    b.HasOne("MedLab.Models.User", "LabAssistant")
                        .WithMany()
                        .HasForeignKey("LabAssistantID");

                    b.HasOne("MedLab.Models.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestID");

                    b.HasOne("MedLab.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("LabAssistant");

                    b.Navigation("Test");

                    b.Navigation("TestBooking");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MedLab.Models.Test", b =>
                {
                    b.HasOne("MedLab.Models.TestCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MedLab.Models.TestBooking", b =>
                {
                    b.HasOne("MedLab.Models.User", "LabAssistant")
                        .WithMany()
                        .HasForeignKey("LabAssistantID");

                    b.HasOne("MedLab.Models.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestID");

                    b.HasOne("MedLab.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("LabAssistant");

                    b.Navigation("Test");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
