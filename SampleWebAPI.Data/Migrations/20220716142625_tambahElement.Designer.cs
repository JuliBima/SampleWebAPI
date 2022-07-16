﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SampleWebAPI.Data;

#nullable disable

namespace SampleWebAPI.Data.Migrations
{
    [DbContext(typeof(SamuraiContext))]
    [Migration("20220716142625_tambahElement")]
    partial class tambahElement
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ElementSword", b =>
                {
                    b.Property<int>("ElementsElementId")
                        .HasColumnType("int");

                    b.Property<int>("SwordsId")
                        .HasColumnType("int");

                    b.HasKey("ElementsElementId", "SwordsId");

                    b.HasIndex("SwordsId");

                    b.ToTable("ElementSword");
                });

            modelBuilder.Entity("SampleWebAPI.Domain.Battle", b =>
                {
                    b.Property<int>("BattleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BattleId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BattleId");

                    b.ToTable("Battles");
                });

            modelBuilder.Entity("SampleWebAPI.Domain.BattleSamurai", b =>
                {
                    b.Property<int>("BattleId")
                        .HasColumnType("int");

                    b.Property<int>("SamuraiId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateJoined")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("BattleId", "SamuraiId");

                    b.HasIndex("SamuraiId");

                    b.ToTable("BattleSamurai");
                });

            modelBuilder.Entity("SampleWebAPI.Domain.Element", b =>
                {
                    b.Property<int>("ElementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ElementId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ElementId");

                    b.ToTable("Elements");
                });

            modelBuilder.Entity("SampleWebAPI.Domain.Horse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SamuraiId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SamuraiId")
                        .IsUnique();

                    b.ToTable("Horse");
                });

            modelBuilder.Entity("SampleWebAPI.Domain.Quote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("SamuraiId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SamuraiId");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("SampleWebAPI.Domain.Samurai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Samurais");
                });

            modelBuilder.Entity("SampleWebAPI.Domain.SamuraiBattleStat", b =>
                {
                    b.Property<string>("EarliestBattle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumberOfBattles")
                        .HasColumnType("int");

                    b.ToView("SamuraiBattleStats");
                });

            modelBuilder.Entity("SampleWebAPI.Domain.Sword", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NameSword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SamuraiId")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SamuraiId");

                    b.ToTable("Swords");
                });

            modelBuilder.Entity("ElementSword", b =>
                {
                    b.HasOne("SampleWebAPI.Domain.Element", null)
                        .WithMany()
                        .HasForeignKey("ElementsElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SampleWebAPI.Domain.Sword", null)
                        .WithMany()
                        .HasForeignKey("SwordsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SampleWebAPI.Domain.BattleSamurai", b =>
                {
                    b.HasOne("SampleWebAPI.Domain.Battle", null)
                        .WithMany()
                        .HasForeignKey("BattleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SampleWebAPI.Domain.Samurai", null)
                        .WithMany()
                        .HasForeignKey("SamuraiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SampleWebAPI.Domain.Horse", b =>
                {
                    b.HasOne("SampleWebAPI.Domain.Samurai", null)
                        .WithOne("Horse")
                        .HasForeignKey("SampleWebAPI.Domain.Horse", "SamuraiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SampleWebAPI.Domain.Quote", b =>
                {
                    b.HasOne("SampleWebAPI.Domain.Samurai", "Samurai")
                        .WithMany("Quotes")
                        .HasForeignKey("SamuraiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Samurai");
                });

            modelBuilder.Entity("SampleWebAPI.Domain.Sword", b =>
                {
                    b.HasOne("SampleWebAPI.Domain.Samurai", "Samurai")
                        .WithMany("Swords")
                        .HasForeignKey("SamuraiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Samurai");
                });

            modelBuilder.Entity("SampleWebAPI.Domain.Samurai", b =>
                {
                    b.Navigation("Horse")
                        .IsRequired();

                    b.Navigation("Quotes");

                    b.Navigation("Swords");
                });
#pragma warning restore 612, 618
        }
    }
}
