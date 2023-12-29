﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("Data.Entities.CarEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EngineType")
                        .HasColumnType("INTEGER")
                        .HasColumnName("engine_type");

                    b.Property<int>("MakerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Power")
                        .HasColumnType("INTEGER")
                        .HasColumnName("power");

                    b.Property<string>("Registration")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT")
                        .HasColumnName("registration");

                    b.Property<int>("Volume")
                        .HasColumnType("INTEGER")
                        .HasColumnName("volume");

                    b.HasKey("Id");

                    b.HasIndex("MakerId");

                    b.HasIndex("OwnerId");

                    b.ToTable("cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EngineType = 1,
                            MakerId = 1,
                            Name = "Ibiza",
                            OwnerId = 1,
                            Power = 130,
                            Registration = "KRA123AB",
                            Volume = 1200
                        },
                        new
                        {
                            Id = 2,
                            EngineType = 2,
                            MakerId = 2,
                            Name = "Astra",
                            OwnerId = 2,
                            Power = 180,
                            Registration = "WW123AB",
                            Volume = 1800
                        },
                        new
                        {
                            Id = 3,
                            EngineType = 2,
                            MakerId = 2,
                            Name = "Vectra",
                            OwnerId = 1,
                            Power = 100,
                            Registration = "KK1237B",
                            Volume = 1400
                        });
                });

            modelBuilder.Entity("Data.Entities.ContactEntity", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Birth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<int?>("OrganizationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ContactId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("contacts");

                    b.HasData(
                        new
                        {
                            ContactId = 1,
                            Birth = new DateTime(2000, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "adam@gmail.com",
                            Name = "Adam",
                            OrganizationId = 1,
                            Phone = "123456789"
                        },
                        new
                        {
                            ContactId = 2,
                            Birth = new DateTime(2000, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jarek@gmail.com",
                            Name = "jarek",
                            OrganizationId = 1,
                            Phone = "12345789"
                        },
                        new
                        {
                            ContactId = 3,
                            Birth = new DateTime(1990, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "marek@gmail.com",
                            Name = "marek",
                            OrganizationId = 2,
                            Phone = "1234569"
                        });
                });

            modelBuilder.Entity("Data.Entities.MakerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Makers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Seat"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Opel"
                        },
                        new
                        {
                            Id = 3,
                            Name = "BMW"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Mazada"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Audi"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Ford"
                        },
                        new
                        {
                            Id = 7,
                            Name = "VolksWagen"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Mercedes"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Ferrari"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Renault"
                        });
                });

            modelBuilder.Entity("Data.Entities.OrganizationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Organizations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Bardzo fajny opis",
                            Name = "Organizacja"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Nie fajny opis",
                            Name = "Firma"
                        });
                });

            modelBuilder.Entity("Data.Entities.OwnerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Owners");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Darek",
                            Phone = "123456789",
                            Surname = "Kowalski"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mariusz",
                            Phone = "987654321",
                            Surname = "Nowak"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = "0fdfe129-20e1-4192-b75b-17f4e06e865e",
                            ConcurrencyStamp = "0fdfe129-20e1-4192-b75b-17f4e06e865e",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "12164877-6a43-4e0e-aca7-e24140596fe7",
                            ConcurrencyStamp = "12164877-6a43-4e0e-aca7-e24140596fe7",
                            Name = "user",
                            NormalizedName = "USER"
                        });
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

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

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "6f28bdb0-da45-4363-bb8a-fd1f575a3912",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d80b7499-e71c-407f-94a0-74d13390ed01",
                            Email = "adam@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADAM@GMAIL.COM",
                            NormalizedUserName = "ADAM",
                            PasswordHash = "AQAAAAEAACcQAAAAECKVZFjdymYAMPkRDKOLhoZGIaoIkS4kaB2nryMoUQwEttkMwrgdc2ddmtZGHqJEBw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "4a08255d-077a-4d99-93b5-49ef7888bba2",
                            TwoFactorEnabled = false,
                            UserName = "adam"
                        },
                        new
                        {
                            Id = "e7ae06d0-00e9-494d-97bb-e2b500194213",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "06bc0a28-bbaf-4d79-b1aa-f4cca8240fb7",
                            Email = "marek@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "MAREK@GMAIL.COM",
                            NormalizedUserName = "MAREK",
                            PasswordHash = "AQAAAAEAACcQAAAAEPyxFQSoTTEoVo/WXgzfG/0jfGym59FDUltlwZ1wZ5J1GNDBuZEGNP0ARM/NJCijzQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "87a793f2-28ff-46b3-852c-f9ff63e57216",
                            TwoFactorEnabled = false,
                            UserName = "marek"
                        },
                        new
                        {
                            Id = "7b448ce9-9a7b-48c6-910a-0084a4460066",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "50c5bf68-0711-4196-b60a-afaff9183b9f",
                            Email = "michal@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "MICHAL@GMAIL.COM",
                            NormalizedUserName = "MICHAL",
                            PasswordHash = "AQAAAAEAACcQAAAAELk0/NN62ccHqUPbohoDoM/nJ8iRCY3y/0cXoxP+x9XD4FiwSOji41vICYZ4aYRTcA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f6052561-4740-45be-a86a-db9850c3d5ab",
                            TwoFactorEnabled = false,
                            UserName = "michal"
                        });
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

                    b.HasData(
                        new
                        {
                            UserId = "6f28bdb0-da45-4363-bb8a-fd1f575a3912",
                            RoleId = "0fdfe129-20e1-4192-b75b-17f4e06e865e"
                        },
                        new
                        {
                            UserId = "e7ae06d0-00e9-494d-97bb-e2b500194213",
                            RoleId = "12164877-6a43-4e0e-aca7-e24140596fe7"
                        });
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

            modelBuilder.Entity("Data.Entities.CarEntity", b =>
                {
                    b.HasOne("Data.Entities.MakerEntity", "Maker")
                        .WithMany("Cars")
                        .HasForeignKey("MakerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.OwnerEntity", "Owner")
                        .WithMany("Cars")
                        .HasForeignKey("OwnerId");

                    b.Navigation("Maker");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Data.Entities.ContactEntity", b =>
                {
                    b.HasOne("Data.Entities.OrganizationEntity", "Organization")
                        .WithMany("Contacts")
                        .HasForeignKey("OrganizationId");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Data.Entities.OrganizationEntity", b =>
                {
                    b.OwnsOne("Data.Models.Address", "Address", b1 =>
                        {
                            b1.Property<int>("OrganizationEntityId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("OrganizationEntityId");

                            b1.ToTable("Organizations");

                            b1.WithOwner()
                                .HasForeignKey("OrganizationEntityId");

                            b1.HasData(
                                new
                                {
                                    OrganizationEntityId = 1,
                                    City = "Krakow",
                                    PostalCode = "31-200",
                                    Street = "Filpa"
                                },
                                new
                                {
                                    OrganizationEntityId = 2,
                                    City = "Warszawa",
                                    PostalCode = "54-120",
                                    Street = "Fiolkowa"
                                });
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Data.Entities.OwnerEntity", b =>
                {
                    b.OwnsOne("Data.Models.Address", "Address", b1 =>
                        {
                            b1.Property<int>("OwnerEntityId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("OwnerEntityId");

                            b1.ToTable("Owners");

                            b1.WithOwner()
                                .HasForeignKey("OwnerEntityId");

                            b1.HasData(
                                new
                                {
                                    OwnerEntityId = 1,
                                    City = "Krakow",
                                    PostalCode = "31-200",
                                    Street = "Filpa"
                                },
                                new
                                {
                                    OwnerEntityId = 2,
                                    City = "Warszawa",
                                    PostalCode = "54-120",
                                    Street = "Fiolkowa"
                                });
                        });

                    b.Navigation("Address");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entities.MakerEntity", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Data.Entities.OrganizationEntity", b =>
                {
                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("Data.Entities.OwnerEntity", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
