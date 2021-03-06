// <auto-generated />
using System;
using System.Collections.Generic;
using DoctorsClient.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DoctorsClient.Migrations
{
    [DbContext(typeof(DoctorContext))]
    [Migration("20210702154339_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DoctorsClient.Models.Account", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .HasColumnType("text");

                    b.Property<string>("role")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("DoctorsClient.Models.Diagnose", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Diagnoses");
                });

            modelBuilder.Entity("DoctorsClient.Models.Doctor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .HasColumnType("text");

                    b.Property<string>("patronymic")
                        .HasColumnType("text");

                    b.Property<string>("position")
                        .HasColumnType("text");

                    b.Property<string>("surname")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("DoctorsClient.Models.Medication", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("text")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Medications");
                });

            modelBuilder.Entity("DoctorsClient.Models.Outpatient_card", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("date")
                        .HasColumnType("text");

                    b.Property<int>("diagnoseid")
                        .HasColumnType("integer");

                    b.Property<int>("doctorid")
                        .HasColumnType("integer");

                    b.Property<string>("inspection_description")
                        .HasColumnType("text");

                    b.Property<int>("medicationid")
                        .HasColumnType("integer");

                    b.Property<int>("patientid")
                        .HasColumnType("integer");

                    b.Property<List<int>>("symptomid")
                        .HasColumnType("integer[]");

                    b.Property<TimeSpan>("time")
                        .HasColumnType("interval");

                    b.HasKey("id");

                    b.HasIndex("diagnoseid");

                    b.HasIndex("doctorid");

                    b.HasIndex("medicationid");

                    b.HasIndex("patientid");

                    b.ToTable("Outpatient_cards");
                });

            modelBuilder.Entity("DoctorsClient.Models.Patient", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<string>("gender")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<string>("numberpassport")
                        .HasColumnType("text");

                    b.Property<string>("numberpolicy")
                        .HasColumnType("text");

                    b.Property<string>("patronymic")
                        .HasColumnType("text");

                    b.Property<string>("phone")
                        .HasColumnType("text");

                    b.Property<string>("photourl")
                        .HasColumnType("text");

                    b.Property<string>("placeofresidence")
                        .HasColumnType("text");

                    b.Property<string>("residenceaddress")
                        .HasColumnType("text");

                    b.Property<string>("surname")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("DoctorsClient.Models.Symptom", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<List<int>>("outpatient_cardid")
                        .HasColumnType("integer[]");

                    b.HasKey("id");

                    b.ToTable("Symptoms");
                });

            modelBuilder.Entity("DoctorsClient.Models.Test", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("accountid")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<int>("testtwoid")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("accountid");

                    b.HasIndex("testtwoid");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("DoctorsClient.Models.Testtwo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Testtwo");
                });

            modelBuilder.Entity("Outpatient_cardSymptom", b =>
                {
                    b.Property<int>("Outpatient_Cardid")
                        .HasColumnType("integer");

                    b.Property<int>("Symptomid")
                        .HasColumnType("integer");

                    b.HasKey("Outpatient_Cardid", "Symptomid");

                    b.HasIndex("Symptomid");

                    b.ToTable("Outpatient_cardSymptom");
                });

            modelBuilder.Entity("DoctorsClient.Models.Outpatient_card", b =>
                {
                    b.HasOne("DoctorsClient.Models.Diagnose", "Diagnose")
                        .WithMany()
                        .HasForeignKey("diagnoseid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorsClient.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("doctorid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorsClient.Models.Medication", "Medication")
                        .WithMany()
                        .HasForeignKey("medicationid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorsClient.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("patientid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diagnose");

                    b.Navigation("Doctor");

                    b.Navigation("Medication");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("DoctorsClient.Models.Test", b =>
                {
                    b.HasOne("DoctorsClient.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("accountid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorsClient.Models.Testtwo", "Testtwo")
                        .WithMany()
                        .HasForeignKey("testtwoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Testtwo");
                });

            modelBuilder.Entity("Outpatient_cardSymptom", b =>
                {
                    b.HasOne("DoctorsClient.Models.Outpatient_card", null)
                        .WithMany()
                        .HasForeignKey("Outpatient_Cardid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorsClient.Models.Symptom", null)
                        .WithMany()
                        .HasForeignKey("Symptomid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
