﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using evoWatch.Database;

#nullable disable

namespace evoWatch.Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("evoWatch.Database.Models.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Awards")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("evoWatch.Database.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("evoWatch.Database.Models.Character", b =>
                {
                    b.HasOne("evoWatch.Database.Models.Episode", "Episodes")
                        .WithMany("Characters")
                        .HasForeignKey("EpisodesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("evoWatch.Database.Models.Person", "People")
                        .WithMany("Characters")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Episodes");

                    b.Navigation("People");
                });

            modelBuilder.Entity("evoWatch.Database.Models.Episode", b =>
                {
                    b.HasOne("evoWatch.Database.Models.ProductionCompany", "ProductionCompanies")
                        .WithMany("Episodes")
                        .HasForeignKey("ProductionCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("evoWatch.Database.Models.Season", "Seasons")
                        .WithMany("Episodes")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductionCompanies");

                    b.Navigation("Seasons");
                });

            modelBuilder.Entity("evoWatch.Database.Models.PersonEpisode", b =>
                {
                    b.HasOne("evoWatch.Database.Models.Episode", "Episodes")
                        .WithMany("PersonEpisodes")
                        .HasForeignKey("EpisodesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("evoWatch.Database.Models.Person", "People")
                        .WithMany("PeopleEpisodes")
                        .HasForeignKey("PersoniD")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Episodes");

                    b.Navigation("People");
                });

            modelBuilder.Entity("evoWatch.Database.Models.Season", b =>
                {
                    b.HasOne("evoWatch.Database.Models.Series", "Series")
                        .WithMany("Seasons")
                        .HasForeignKey("SeriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Series");
                });

            modelBuilder.Entity("evoWatch.Database.Models.Episode", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("PersonEpisodes");
                });

            modelBuilder.Entity("evoWatch.Database.Models.Person", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("PeopleEpisodes");
                });

            modelBuilder.Entity("evoWatch.Database.Models.ProductionCompany", b =>
                {
                    b.Navigation("Episodes");
                });

            modelBuilder.Entity("evoWatch.Database.Models.Season", b =>
                {
                    b.Navigation("Episodes");
                });

            modelBuilder.Entity("evoWatch.Database.Models.Series", b =>
                {
                    b.Navigation("Seasons");
                });
#pragma warning restore 612, 618
        }
    }
}
