﻿// <auto-generated />
using HeadlessCMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HeadlessCMS.Migrations
{
    [DbContext(typeof(CmsDbContext))]
    [Migration("20230912055739_testdbmedia")]
    partial class testdbmedia
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HeadlessCMS.Models.Components", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("pageId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("HeadlessCMS.Models.Content", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("Component_id")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Content");
                });

            modelBuilder.Entity("HeadlessCMS.Models.Page", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("CreatedOn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("websiteID")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("Page");
                });

            modelBuilder.Entity("HeadlessCMS.Models.Website", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("CreatedOn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Website");
                });

            modelBuilder.Entity("HeadlessCMS.Models.Content", b =>
                {
                    b.OwnsOne("HeadlessCMS.Models.Content+Media", "mediaJSON", b1 =>
                        {
                            b1.Property<int>("Contentid")
                                .HasColumnType("integer");

                            b1.Property<string>("AltText")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Imageurl")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("VideoUrl")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("Contentid");

                            b1.ToTable("Content");

                            b1.WithOwner()
                                .HasForeignKey("Contentid");
                        });

                    b.Navigation("mediaJSON")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
