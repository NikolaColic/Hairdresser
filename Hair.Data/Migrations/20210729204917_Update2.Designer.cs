﻿// <auto-generated />
using System;
using Hair.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hair.Data.Migrations
{
    [DbContext(typeof(HairdresserDbContext))]
    [Migration("20210729204917_Update2")]
    partial class Update2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hair.Data.Entities.FavouriteHairdresser", b =>
                {
                    b.Property<int>("FavouriteHairdresserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HairdresserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("FavouriteHairdresserId");

                    b.HasIndex("HairdresserId");

                    b.HasIndex("UserId");

                    b.ToTable("FavouriteHairdresser");
                });

            modelBuilder.Entity("Hair.Data.Entities.Hairdresser", b =>
                {
                    b.Property<int>("HairdresserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Gmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MunicipalityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(12)")
                        .HasMaxLength(12);

                    b.Property<string>("Pricelist")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxId")
                        .IsRequired()
                        .HasColumnType("nvarchar(12)")
                        .HasMaxLength(12);

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HairdresserId");

                    b.HasIndex("MunicipalityId");

                    b.HasIndex("UserId");

                    b.ToTable("Hairdresser");
                });

            modelBuilder.Entity("Hair.Data.Entities.HairdresserImage", b =>
                {
                    b.Property<int>("HairdresserImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HairdresserId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HairdresserImageId");

                    b.HasIndex("HairdresserId");

                    b.ToTable("HairdresserImage");
                });

            modelBuilder.Entity("Hair.Data.Entities.Municipality", b =>
                {
                    b.Property<int>("MunicipalityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MunicipalityId");

                    b.ToTable("Municipality");
                });

            modelBuilder.Entity("Hair.Data.Entities.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HairdresserId")
                        .HasColumnType("int");

                    b.Property<int>("Mark")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ReservationId");

                    b.HasIndex("HairdresserId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("Hair.Data.Entities.SocialHairdresser", b =>
                {
                    b.Property<int>("SocialHairdresserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HairdresserId")
                        .HasColumnType("int");

                    b.Property<int?>("SocialNetworkId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SocialHairdresserId");

                    b.HasIndex("HairdresserId");

                    b.HasIndex("SocialNetworkId");

                    b.ToTable("SocialHairdresser");
                });

            modelBuilder.Entity("Hair.Data.Entities.SocialNetwork", b =>
                {
                    b.Property<int>("SocialNetworkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SocialNetworkId");

                    b.ToTable("SocialNetwork");
                });

            modelBuilder.Entity("Hair.Data.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Hair.Data.Entities.FavouriteHairdresser", b =>
                {
                    b.HasOne("Hair.Data.Entities.Hairdresser", "Hairdresser")
                        .WithMany()
                        .HasForeignKey("HairdresserId");

                    b.HasOne("Hair.Data.Entities.User", "User")
                        .WithMany("FavouritesHairdresser")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Hair.Data.Entities.Hairdresser", b =>
                {
                    b.HasOne("Hair.Data.Entities.Municipality", "Municipality")
                        .WithMany()
                        .HasForeignKey("MunicipalityId");

                    b.HasOne("Hair.Data.Entities.User", "Owner")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Hair.Data.Entities.HairdresserImage", b =>
                {
                    b.HasOne("Hair.Data.Entities.Hairdresser", "Hairdresser")
                        .WithMany("Images")
                        .HasForeignKey("HairdresserId");
                });

            modelBuilder.Entity("Hair.Data.Entities.Reservation", b =>
                {
                    b.HasOne("Hair.Data.Entities.Hairdresser", "Hairdresser")
                        .WithMany("Reservations")
                        .HasForeignKey("HairdresserId");

                    b.HasOne("Hair.Data.Entities.User", "User")
                        .WithMany("ReservationsHistory")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Hair.Data.Entities.SocialHairdresser", b =>
                {
                    b.HasOne("Hair.Data.Entities.Hairdresser", "Hairdresser")
                        .WithMany("SocialNetworks")
                        .HasForeignKey("HairdresserId");

                    b.HasOne("Hair.Data.Entities.SocialNetwork", "SocialNetwork")
                        .WithMany()
                        .HasForeignKey("SocialNetworkId");
                });
#pragma warning restore 612, 618
        }
    }
}
