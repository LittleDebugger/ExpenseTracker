﻿// <auto-generated />
using System;
using ExpenseTracker.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExpenseTracker.Repository.Migrations
{
    [DbContext(typeof(ExpenseTrackerContext))]
    [Migration("20181008220028_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExpenseTracker.Repository.Entities.Currency", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Currency");

                    b.HasData(
                        new { Id = (short)1, Description = "CHF" },
                        new { Id = (short)2, Description = "USD" },
                        new { Id = (short)3, Description = "GBP" }
                    );
                });

            modelBuilder.Entity("ExpenseTracker.Repository.Entities.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<short>("CurrencyId");

                    b.Property<string>("Recipient")
                        .HasMaxLength(50);

                    b.Property<DateTime>("TransactionDate");

                    b.Property<short>("TransactionTypeId");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("ExpenseTracker.Repository.Entities.TransactionType", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("TransactionType");

                    b.HasData(
                        new { Id = (short)1, Description = "Food" },
                        new { Id = (short)2, Description = "Drinks" },
                        new { Id = (short)3, Description = "Other" }
                    );
                });

            modelBuilder.Entity("ExpenseTracker.Repository.Entities.Expense", b =>
                {
                    b.HasOne("ExpenseTracker.Repository.Entities.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ExpenseTracker.Repository.Entities.TransactionType", "TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
