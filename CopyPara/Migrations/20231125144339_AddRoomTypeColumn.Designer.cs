﻿// <auto-generated />
using System;
using CopyPara.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CopyPara.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231125144339_AddRoomTypeColumn")]
    partial class AddRoomTypeColumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("CancerMachineType", b =>
                {
                    b.Property<ulong>("CancersId")
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("MachineTypesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CancersId", "MachineTypesId");

                    b.HasIndex("MachineTypesId");

                    b.ToTable("CancerMachineType");
                });

            modelBuilder.Entity("CopyPara.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<ulong>("DoctorId")
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("DoctorId1")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId1");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("CopyPara.Domain.Cancers.Cancer", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AvgTimeMins")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CancerType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Fractions")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cancers");

                    b.HasData(
                        new
                        {
                            Id = 1ul,
                            AvgTimeMins = 12,
                            CancerType = 4,
                            Fractions = "5,10,12"
                        },
                        new
                        {
                            Id = 2ul,
                            AvgTimeMins = 12,
                            CancerType = 1,
                            Fractions = "5,10,12"
                        },
                        new
                        {
                            Id = 3ul,
                            AvgTimeMins = 20,
                            CancerType = 2,
                            Fractions = "5,10,12"
                        },
                        new
                        {
                            Id = 4ul,
                            AvgTimeMins = 10,
                            CancerType = 6,
                            Fractions = "1,5,10,13,25,30"
                        },
                        new
                        {
                            Id = 5ul,
                            AvgTimeMins = 30,
                            CancerType = 0,
                            Fractions = "13,17,20,30"
                        },
                        new
                        {
                            Id = 6ul,
                            AvgTimeMins = 12,
                            CancerType = 3,
                            Fractions = "5,10,15,25,30,33,35"
                        },
                        new
                        {
                            Id = 7ul,
                            AvgTimeMins = 12,
                            CancerType = 7,
                            Fractions = "1,5,10,15,20,25,30,33"
                        },
                        new
                        {
                            Id = 8ul,
                            AvgTimeMins = 15,
                            CancerType = 8,
                            Fractions = "3,5,8"
                        },
                        new
                        {
                            Id = 9ul,
                            AvgTimeMins = 12,
                            CancerType = 5,
                            Fractions = "1,3,5,10,15,22,23,25,28,35"
                        },
                        new
                        {
                            Id = 10ul,
                            AvgTimeMins = 10,
                            CancerType = 9,
                            Fractions = "5,10,12"
                        });
                });

            modelBuilder.Entity("CopyPara.Domain.Doctors.Doctor", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("CopyPara.Domain.Machines.Machine", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("MachineTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MachineTypeId");

                    b.ToTable("Machines");

                    b.HasData(
                        new
                        {
                            Id = 5ul,
                            MachineTypeId = 1ul,
                            Name = "Unique - Clinac"
                        },
                        new
                        {
                            Id = 3ul,
                            MachineTypeId = 2ul,
                            Name = "VitalBeam 1"
                        },
                        new
                        {
                            Id = 4ul,
                            MachineTypeId = 2ul,
                            Name = "VitalBeam 2"
                        },
                        new
                        {
                            Id = 1ul,
                            MachineTypeId = 3ul,
                            Name = "TrueBeam 1"
                        },
                        new
                        {
                            Id = 2ul,
                            MachineTypeId = 3ul,
                            Name = "TrueBeam 2"
                        });
                });

            modelBuilder.Entity("CopyPara.Domain.Machines.MachineType", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Features")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("MachineTypes");

                    b.HasData(
                        new
                        {
                            Id = 1ul,
                            Features = "[]",
                            Type = 2
                        },
                        new
                        {
                            Id = 2ul,
                            Features = "[3,2]",
                            Type = 1
                        },
                        new
                        {
                            Id = 3ul,
                            Features = "[0,1,3,2]",
                            Type = 0
                        });
                });

            modelBuilder.Entity("CopyPara.Domain.Occasions.Occasion", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<ulong>("MachineId")
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("TimeSlotId")
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("TreatmentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MachineId");

                    b.HasIndex("TimeSlotId");

                    b.HasIndex("TreatmentId");

                    b.ToTable("Occasions");
                });

            modelBuilder.Entity("CopyPara.Domain.Occasions.Slot", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("End")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Start")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<ulong?>("UtilizationId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UtilizationId");

                    b.ToTable("Slot");
                });

            modelBuilder.Entity("CopyPara.Domain.Occasions.TimeSlot", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EndTime")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Length")
                        .HasColumnType("INTEGER");

                    b.Property<ulong?>("SlotId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StartTime")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ToDelete")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SlotId");

                    b.ToTable("TimeSlot");
                });

            modelBuilder.Entity("CopyPara.Domain.Patients.Patient", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsInpatient")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<ulong>("RoomId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("CopyPara.Domain.Rooms.Room", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberOfBeds")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoomType")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("WithBath")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("CopyPara.Domain.Treatments.Treatment", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("CancerId")
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("DoctorId")
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("PatientId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CancerId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Treatments");
                });

            modelBuilder.Entity("CopyPara.Domain.Utilizations.Utilization", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentUtilization")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<ulong>("MachineId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MachineId");

                    b.ToTable("Utilization");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CancerMachineType", b =>
                {
                    b.HasOne("CopyPara.Domain.Cancers.Cancer", null)
                        .WithMany()
                        .HasForeignKey("CancersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CopyPara.Domain.Machines.MachineType", null)
                        .WithMany()
                        .HasForeignKey("MachineTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CopyPara.Data.ApplicationUser", b =>
                {
                    b.HasOne("CopyPara.Domain.Doctors.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("CopyPara.Domain.Machines.Machine", b =>
                {
                    b.HasOne("CopyPara.Domain.Machines.MachineType", "MachineType")
                        .WithMany("Machines")
                        .HasForeignKey("MachineTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MachineType");
                });

            modelBuilder.Entity("CopyPara.Domain.Occasions.Occasion", b =>
                {
                    b.HasOne("CopyPara.Domain.Machines.Machine", "Machine")
                        .WithMany("Occasions")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CopyPara.Domain.Occasions.TimeSlot", "TimeSlot")
                        .WithMany()
                        .HasForeignKey("TimeSlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CopyPara.Domain.Treatments.Treatment", "Treatment")
                        .WithMany("Occasions")
                        .HasForeignKey("TreatmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Machine");

                    b.Navigation("TimeSlot");

                    b.Navigation("Treatment");
                });

            modelBuilder.Entity("CopyPara.Domain.Occasions.Slot", b =>
                {
                    b.HasOne("CopyPara.Domain.Utilizations.Utilization", null)
                        .WithMany("Slots")
                        .HasForeignKey("UtilizationId");
                });

            modelBuilder.Entity("CopyPara.Domain.Occasions.TimeSlot", b =>
                {
                    b.HasOne("CopyPara.Domain.Occasions.Slot", null)
                        .WithMany("TimeSlots")
                        .HasForeignKey("SlotId");
                });

            modelBuilder.Entity("CopyPara.Domain.Patients.Patient", b =>
                {
                    b.HasOne("CopyPara.Domain.Rooms.Room", "Room")
                        .WithMany("Patients")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("CopyPara.Domain.Treatments.Treatment", b =>
                {
                    b.HasOne("CopyPara.Domain.Cancers.Cancer", "Cancer")
                        .WithMany("Treatments")
                        .HasForeignKey("CancerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CopyPara.Domain.Doctors.Doctor", "Doctor")
                        .WithMany("Treatments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CopyPara.Domain.Patients.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cancer");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("CopyPara.Domain.Utilizations.Utilization", b =>
                {
                    b.HasOne("CopyPara.Domain.Machines.Machine", "Machine")
                        .WithMany("Utilization")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Machine");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CopyPara.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CopyPara.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CopyPara.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CopyPara.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CopyPara.Domain.Cancers.Cancer", b =>
                {
                    b.Navigation("Treatments");
                });

            modelBuilder.Entity("CopyPara.Domain.Doctors.Doctor", b =>
                {
                    b.Navigation("Treatments");
                });

            modelBuilder.Entity("CopyPara.Domain.Machines.Machine", b =>
                {
                    b.Navigation("Occasions");

                    b.Navigation("Utilization");
                });

            modelBuilder.Entity("CopyPara.Domain.Machines.MachineType", b =>
                {
                    b.Navigation("Machines");
                });

            modelBuilder.Entity("CopyPara.Domain.Occasions.Slot", b =>
                {
                    b.Navigation("TimeSlots");
                });

            modelBuilder.Entity("CopyPara.Domain.Rooms.Room", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("CopyPara.Domain.Treatments.Treatment", b =>
                {
                    b.Navigation("Occasions");
                });

            modelBuilder.Entity("CopyPara.Domain.Utilizations.Utilization", b =>
                {
                    b.Navigation("Slots");
                });
#pragma warning restore 612, 618
        }
    }
}
