﻿// <auto-generated />
using DatabaseProject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace DatabaseProjectTest.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20180422201508_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("DatabaseProject.Bio", b =>
                {
                    b.Property<string>("userName")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("bio");

                    b.HasKey("userName");

                    b.ToTable("Bios");
                });

            modelBuilder.Entity("DatabaseProject.Books", b =>
                {
                    b.Property<string>("userName")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("books");

                    b.HasKey("userName");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("DatabaseProject.Career", b =>
                {
                    b.Property<string>("userName")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("careerGoals");

                    b.HasKey("userName");

                    b.ToTable("Careers");
                });

            modelBuilder.Entity("DatabaseProject.Club", b =>
                {
                    b.Property<string>("clubName")
                        .ValueGeneratedOnAdd();

                    b.HasKey("clubName");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("DatabaseProject.ContactInfo", b =>
                {
                    b.Property<string>("userName")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Behance");

                    b.Property<string>("Facebook");

                    b.Property<string>("Instagram");

                    b.Property<string>("Linkedin");

                    b.Property<string>("Twitter");

                    b.Property<string>("email");

                    b.Property<string>("phone");

                    b.Property<string>("websiteURL");

                    b.HasKey("userName");

                    b.ToTable("ContactInfos");
                });

            modelBuilder.Entity("DatabaseProject.Foods", b =>
                {
                    b.Property<string>("userName")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("foods");

                    b.HasKey("userName");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("DatabaseProject.Hobbies", b =>
                {
                    b.Property<string>("userName")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("hobbies");

                    b.HasKey("userName");

                    b.ToTable("Hobbies");
                });

            modelBuilder.Entity("DatabaseProject.Interest", b =>
                {
                    b.Property<string>("interestName")
                        .ValueGeneratedOnAdd();

                    b.HasKey("interestName");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("DatabaseProject.Location", b =>
                {
                    b.Property<string>("userName")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("address");

                    b.Property<string>("city");

                    b.Property<string>("state");

                    b.Property<int>("zip");

                    b.HasKey("userName");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("DatabaseProject.Major", b =>
                {
                    b.Property<string>("major")
                        .ValueGeneratedOnAdd();

                    b.HasKey("major");

                    b.ToTable("Majors");
                });

            modelBuilder.Entity("DatabaseProject.Movies", b =>
                {
                    b.Property<string>("userName")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("movies");

                    b.HasKey("userName");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("DatabaseProject.Music", b =>
                {
                    b.Property<string>("userName")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("music");

                    b.HasKey("userName");

                    b.ToTable("Musics");
                });

            modelBuilder.Entity("DatabaseProject.Personality", b =>
                {
                    b.Property<string>("userName")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("personalityType");

                    b.HasKey("userName");

                    b.ToTable("Personality");
                });

            modelBuilder.Entity("DatabaseProject.PetPeeves", b =>
                {
                    b.Property<string>("userName")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("petPeeves");

                    b.HasKey("userName");

                    b.ToTable("PetPeeves");
                });

            modelBuilder.Entity("DatabaseProject.RelationshipStatus", b =>
                {
                    b.Property<string>("userName")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("status");

                    b.HasKey("userName");

                    b.ToTable("RelationshipStatuses");
                });

            modelBuilder.Entity("DatabaseProject.Shows", b =>
                {
                    b.Property<string>("userName")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("shows");

                    b.HasKey("userName");

                    b.ToTable("Shows");
                });

            modelBuilder.Entity("DatabaseProject.UserClub", b =>
                {
                    b.Property<string>("clubName");

                    b.Property<string>("userName");

                    b.HasKey("clubName", "userName");

                    b.ToTable("UserClubs");
                });

            modelBuilder.Entity("DatabaseProject.UserInterest", b =>
                {
                    b.Property<string>("interestName");

                    b.Property<string>("userName");

                    b.HasKey("interestName", "userName");

                    b.ToTable("UserInterests");
                });

            modelBuilder.Entity("DatabaseProject.UserMajor", b =>
                {
                    b.Property<string>("major");

                    b.Property<string>("userName");

                    b.HasKey("major", "userName");

                    b.ToTable("UserMajors");
                });

            modelBuilder.Entity("DatabaseProject.Users", b =>
                {
                    b.Property<string>("userName")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("birthdayDay");

                    b.Property<int>("birthdayMonth");

                    b.Property<string>("email");

                    b.Property<string>("firstName");

                    b.Property<string>("lastName");

                    b.Property<string>("standing");

                    b.Property<string>("workplace");

                    b.HasKey("userName");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}