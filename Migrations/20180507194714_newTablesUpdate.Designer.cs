﻿// <auto-generated />
using BookCave.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BookCave.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180507194714_newTablesUpdate")]
    partial class newTablesUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookCave.Data.EntityModels.Author", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("authorDescription");

                    b.Property<string>("authorName");

                    b.Property<string>("image");

                    b.HasKey("Id");

                    b.ToTable("authors");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("author");

                    b.Property<double>("cost");

                    b.Property<string>("description");

                    b.Property<string>("genre");

                    b.Property<string>("image");

                    b.Property<string>("keyAuthorId");

                    b.Property<double>("rating");

                    b.Property<string>("title");

                    b.HasKey("Id");

                    b.ToTable("books");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.CardInfo", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("aspUserIdForCardInfo");

                    b.Property<string>("cardNumber");

                    b.Property<string>("cardholderName");

                    b.Property<string>("cvc");

                    b.HasKey("Id");

                    b.ToTable("cardInfo");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<double>("Ratings");

                    b.Property<int>("reviewBookId");

                    b.Property<string>("reviewFromUserName");

                    b.HasKey("Id");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.ShippingInfo", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("address");

                    b.Property<string>("aspUserIdForShipping");

                    b.Property<string>("city");

                    b.Property<string>("country");

                    b.Property<string>("zipCode");

                    b.HasKey("Id");

                    b.ToTable("shipingInfo");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.UserAccount", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("aspUserId");

                    b.Property<string>("cardInfoForUserId");

                    b.Property<int>("favoriteBookForUserId");

                    b.Property<string>("password");

                    b.Property<string>("picture");

                    b.Property<string>("shippingInfoForUserId");

                    b.Property<string>("userName");

                    b.HasKey("Id");

                    b.ToTable("userAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}
