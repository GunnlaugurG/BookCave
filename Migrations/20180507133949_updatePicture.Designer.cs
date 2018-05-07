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
    [Migration("20180507133949_updatePicture")]
    partial class updatePicture
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

                    b.Property<string>("cardNumber");

                    b.Property<string>("cardholderName");

                    b.Property<string>("cvc");

                    b.HasKey("Id");

                    b.ToTable("CardInfo");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.ShippingInfo", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("address");

                    b.Property<string>("city");

                    b.Property<string>("country");

                    b.Property<string>("zipCode");

                    b.HasKey("Id");

                    b.ToTable("ShippingInfo");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.UserAccount", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("aspUserId");

                    b.Property<string>("cardInfoId");

                    b.Property<int?>("favoriteBookId");

                    b.Property<string>("password");

                    b.Property<byte[]>("picture")
                        .HasMaxLength(16);

                    b.Property<string>("shippingInfoId");

                    b.Property<string>("userName");

                    b.HasKey("Id");

                    b.HasIndex("cardInfoId");

                    b.HasIndex("favoriteBookId");

                    b.HasIndex("shippingInfoId");

                    b.ToTable("userAccounts");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.UserAccount", b =>
                {
                    b.HasOne("BookCave.Data.EntityModels.CardInfo", "cardInfo")
                        .WithMany()
                        .HasForeignKey("cardInfoId");

                    b.HasOne("BookCave.Data.EntityModels.Book", "favoriteBook")
                        .WithMany()
                        .HasForeignKey("favoriteBookId");

                    b.HasOne("BookCave.Data.EntityModels.ShippingInfo", "shippingInfo")
                        .WithMany()
                        .HasForeignKey("shippingInfoId");
                });
#pragma warning restore 612, 618
        }
    }
}
