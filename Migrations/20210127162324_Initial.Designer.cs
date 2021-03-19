﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using escala_server.Data;

namespace escala_server.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210127162324_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("escala_server.Models.Function", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(30) CHARACTER SET utf8mb4")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Function");
                });

            modelBuilder.Entity("escala_server.Models.Group", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("escala_server.Models.Member", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Adm")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Image")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("SecretWord")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("escala_server.Models.MemberFunction", b =>
                {
                    b.Property<long>("MemberId")
                        .HasColumnType("bigint");

                    b.Property<long>("FunctionId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("MemberId", "FunctionId");

                    b.HasIndex("FunctionId");

                    b.ToTable("MemberFunction");
                });

            modelBuilder.Entity("escala_server.Models.MemberGroup", b =>
                {
                    b.Property<long>("MemberId")
                        .HasColumnType("bigint");

                    b.Property<long>("GroupId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Adm")
                        .HasColumnType("tinyint(1)");

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.HasKey("MemberId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("MemberGroup");
                });

            modelBuilder.Entity("escala_server.Models.MemberScale", b =>
                {
                    b.Property<long>("MemberId")
                        .HasColumnType("bigint");

                    b.Property<long>("ScaleId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.HasKey("MemberId", "ScaleId");

                    b.HasIndex("ScaleId");

                    b.ToTable("MemberScale");
                });

            modelBuilder.Entity("escala_server.Models.Scale", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Day")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Scale");
                });

            modelBuilder.Entity("escala_server.Models.Song", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("Difficulty")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Link")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("Singer")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("Solo")
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<string>("Tone")
                        .HasColumnType("varchar(3) CHARACTER SET utf8mb4")
                        .HasMaxLength(3);

                    b.HasKey("Id");

                    b.ToTable("Song");
                });

            modelBuilder.Entity("escala_server.Models.SongScale", b =>
                {
                    b.Property<long>("SongId")
                        .HasColumnType("bigint");

                    b.Property<long>("ScaleId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.HasKey("SongId", "ScaleId");

                    b.HasIndex("ScaleId");

                    b.ToTable("SongScale");
                });

            modelBuilder.Entity("escala_server.Models.MemberFunction", b =>
                {
                    b.HasOne("escala_server.Models.Function", "Function")
                        .WithMany("MemberFunction")
                        .HasForeignKey("FunctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("escala_server.Models.Member", "Member")
                        .WithMany("MemberFunction")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("escala_server.Models.MemberGroup", b =>
                {
                    b.HasOne("escala_server.Models.Group", "Group")
                        .WithMany("MemberGroup")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("escala_server.Models.Member", "Member")
                        .WithMany("MemberGroup")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("escala_server.Models.MemberScale", b =>
                {
                    b.HasOne("escala_server.Models.Member", "Member")
                        .WithMany("MemberScale")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("escala_server.Models.Scale", "Scale")
                        .WithMany("MemberScale")
                        .HasForeignKey("ScaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("escala_server.Models.SongScale", b =>
                {
                    b.HasOne("escala_server.Models.Scale", "Scale")
                        .WithMany("SongScale")
                        .HasForeignKey("ScaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("escala_server.Models.Song", "Song")
                        .WithMany("SongScale")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
