﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quiz.Data.Data;

#nullable disable

namespace Quiz.Data.Migrations
{
    [DbContext(typeof(QuizDbContext))]
    [Migration("20230926142949_FixFKs")]
    partial class FixFKs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Quiz.Models.Entities.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnswerId")
                        .HasColumnType("int");

                    b.Property<string>("AnswerText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("QuoteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("QuoteId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Quiz.Models.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Albert Einstein"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Buddha"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Dalai Lama"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Elon Musk"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Freddie Mercury"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Michelle Obama"
                        });
                });

            modelBuilder.Entity("Quiz.Models.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CorrectAuthorId")
                        .HasColumnType("int");

                    b.Property<int>("FalseAuthor1Id")
                        .HasColumnType("int");

                    b.Property<int>("FalseAuthor2Id")
                        .HasColumnType("int");

                    b.Property<int>("QuestionType")
                        .HasColumnType("int");

                    b.Property<int>("QuoteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CorrectAuthorId");

                    b.HasIndex("FalseAuthor1Id");

                    b.HasIndex("FalseAuthor2Id");

                    b.HasIndex("QuoteId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CorrectAuthorId = 1,
                            FalseAuthor1Id = 2,
                            FalseAuthor2Id = 3,
                            QuestionType = 0,
                            QuoteId = 1
                        },
                        new
                        {
                            Id = 2,
                            CorrectAuthorId = 1,
                            FalseAuthor1Id = 3,
                            FalseAuthor2Id = 4,
                            QuestionType = 0,
                            QuoteId = 2
                        },
                        new
                        {
                            Id = 3,
                            CorrectAuthorId = 1,
                            FalseAuthor1Id = 4,
                            FalseAuthor2Id = 5,
                            QuestionType = 0,
                            QuoteId = 3
                        },
                        new
                        {
                            Id = 4,
                            CorrectAuthorId = 2,
                            FalseAuthor1Id = 5,
                            FalseAuthor2Id = 6,
                            QuestionType = 0,
                            QuoteId = 4
                        },
                        new
                        {
                            Id = 5,
                            CorrectAuthorId = 2,
                            FalseAuthor1Id = 6,
                            FalseAuthor2Id = 6,
                            QuestionType = 0,
                            QuoteId = 5
                        },
                        new
                        {
                            Id = 6,
                            CorrectAuthorId = 2,
                            FalseAuthor1Id = 5,
                            FalseAuthor2Id = 4,
                            QuestionType = 0,
                            QuoteId = 6
                        },
                        new
                        {
                            Id = 7,
                            CorrectAuthorId = 3,
                            FalseAuthor1Id = 4,
                            FalseAuthor2Id = 3,
                            QuestionType = 0,
                            QuoteId = 7
                        },
                        new
                        {
                            Id = 8,
                            CorrectAuthorId = 3,
                            FalseAuthor1Id = 2,
                            FalseAuthor2Id = 1,
                            QuestionType = 0,
                            QuoteId = 8
                        },
                        new
                        {
                            Id = 9,
                            CorrectAuthorId = 3,
                            FalseAuthor1Id = 1,
                            FalseAuthor2Id = 2,
                            QuestionType = 0,
                            QuoteId = 9
                        });
                });

            modelBuilder.Entity("Quiz.Models.Entities.Quote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Quotes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Text = "Learn from yesterday, live for today, hope for tomorrow. The important thing is not to stop questioning."
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 1,
                            Text = "We cannot solve our problems with the same thinking we used when we created them."
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 1,
                            Text = "Life is like riding a bicycle. To keep your balance, you must keep moving."
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 2,
                            Text = "Do not dwell in the past, do not dream of the future, concentrate the mind on the present moment."
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 2,
                            Text = "Three things cannot be long hidden: the sun, the moon, and the truth."
                        },
                        new
                        {
                            Id = 6,
                            AuthorId = 2,
                            Text = "You will not be punished for your anger, you will be punished by your anger."
                        },
                        new
                        {
                            Id = 7,
                            AuthorId = 3,
                            Text = "In order to carry a positive action we must develop here a positive vision."
                        },
                        new
                        {
                            Id = 8,
                            AuthorId = 3,
                            Text = "Be kind whenever possible. It is always possible."
                        },
                        new
                        {
                            Id = 9,
                            AuthorId = 3,
                            Text = "Be kind whenever possible. It is always possible."
                        });
                });

            modelBuilder.Entity("Quiz.Models.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Quiz.Models.Entities.UserAnswers", b =>
                {
                    b.Property<int>("AnswerId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AnswerId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAnswers");
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
                    b.HasOne("Quiz.Models.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Quiz.Models.Entities.User", null)
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

                    b.HasOne("Quiz.Models.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Quiz.Models.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Quiz.Models.Entities.Answer", b =>
                {
                    b.HasOne("Quiz.Models.Entities.Author", "AnswerAuthor")
                        .WithMany()
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Quiz.Models.Entities.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Quiz.Models.Entities.Quote", "Quote")
                        .WithMany()
                        .HasForeignKey("QuoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnswerAuthor");

                    b.Navigation("Question");

                    b.Navigation("Quote");
                });

            modelBuilder.Entity("Quiz.Models.Entities.Question", b =>
                {
                    b.HasOne("Quiz.Models.Entities.Author", "CorrectAuthor")
                        .WithMany()
                        .HasForeignKey("CorrectAuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Quiz.Models.Entities.Author", "FalseAuthor1")
                        .WithMany()
                        .HasForeignKey("FalseAuthor1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Quiz.Models.Entities.Author", "FalseAuthor2")
                        .WithMany()
                        .HasForeignKey("FalseAuthor2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Quiz.Models.Entities.Quote", "AskedQuote")
                        .WithMany()
                        .HasForeignKey("QuoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AskedQuote");

                    b.Navigation("CorrectAuthor");

                    b.Navigation("FalseAuthor1");

                    b.Navigation("FalseAuthor2");
                });

            modelBuilder.Entity("Quiz.Models.Entities.Quote", b =>
                {
                    b.HasOne("Quiz.Models.Entities.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Quiz.Models.Entities.UserAnswers", b =>
                {
                    b.HasOne("Quiz.Models.Entities.Answer", "Answer")
                        .WithMany("AnswerUsers")
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Quiz.Models.Entities.User", "User")
                        .WithMany("AnswerUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Answer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Quiz.Models.Entities.Answer", b =>
                {
                    b.Navigation("AnswerUsers");
                });

            modelBuilder.Entity("Quiz.Models.Entities.User", b =>
                {
                    b.Navigation("AnswerUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
