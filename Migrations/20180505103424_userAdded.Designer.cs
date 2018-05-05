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
    [Migration("20180505103424_userAdded")]
    partial class userAdded
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

                    b.Property<string>("UserAccountId");

                    b.Property<string>("author");

                    b.Property<double>("cost");

                    b.Property<string>("description");

                    b.Property<string>("genre");

                    b.Property<string>("image");

                    b.Property<string>("keyAuthorId");

                    b.Property<double>("rating");

                    b.Property<string>("title");

                    b.HasKey("Id");

                    b.HasIndex("UserAccountId");

                    b.ToTable("books");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.CardInfo", b =>
                {
                    b.Property<string>("cardInfoID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("cardNumber");

                    b.Property<string>("cardholderName");

                    b.Property<string>("cvc");

                    b.HasKey("cardInfoID");

                    b.ToTable("CardInfo");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.Cart", b =>
                {
                    b.Property<string>("cartID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("quantityInCart");

                    b.Property<double>("totalCost");

                    b.HasKey("cartID");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.CartItem", b =>
                {
                    b.Property<string>("cartItemID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("bookQuantity");

                    b.Property<string>("cartID");

                    b.Property<double>("itemCost");

                    b.HasKey("cartItemID");

                    b.HasIndex("cartID");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.Order", b =>
                {
                    b.Property<string>("orderID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserAccountId");

                    b.Property<string>("itemsBoughtcartID");

                    b.Property<string>("orderShippingInfoShippingInfoID");

                    b.HasKey("orderID");

                    b.HasIndex("UserAccountId");

                    b.HasIndex("itemsBoughtcartID");

                    b.HasIndex("orderShippingInfoShippingInfoID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.ShippingInfo", b =>
                {
                    b.Property<string>("ShippingInfoID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("address");

                    b.Property<string>("city");

                    b.Property<string>("country");

                    b.Property<int>("zipCode");

                    b.HasKey("ShippingInfoID");

                    b.ToTable("ShippingInfo");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.UserAccount", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ShippingInfoID");

                    b.Property<string>("aspUserId");

                    b.Property<string>("cardInfoID");

                    b.Property<int?>("favoriteBookId");

                    b.Property<string>("password");

                    b.Property<string>("picture");

                    b.Property<string>("userName");

                    b.HasKey("Id");

                    b.HasIndex("ShippingInfoID");

                    b.HasIndex("cardInfoID");

                    b.HasIndex("favoriteBookId");

                    b.ToTable("userAccounts");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.Book", b =>
                {
                    b.HasOne("BookCave.Data.EntityModels.UserAccount")
                        .WithMany("wishList")
                        .HasForeignKey("UserAccountId");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.CartItem", b =>
                {
                    b.HasOne("BookCave.Data.EntityModels.Cart")
                        .WithMany("itemsInCart")
                        .HasForeignKey("cartID");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.Order", b =>
                {
                    b.HasOne("BookCave.Data.EntityModels.UserAccount")
                        .WithMany("orderHistory")
                        .HasForeignKey("UserAccountId");

                    b.HasOne("BookCave.Data.EntityModels.Cart", "itemsBought")
                        .WithMany()
                        .HasForeignKey("itemsBoughtcartID");

                    b.HasOne("BookCave.Data.EntityModels.ShippingInfo", "orderShippingInfo")
                        .WithMany()
                        .HasForeignKey("orderShippingInfoShippingInfoID");
                });

            modelBuilder.Entity("BookCave.Data.EntityModels.UserAccount", b =>
                {
                    b.HasOne("BookCave.Data.EntityModels.ShippingInfo", "shippingInfo")
                        .WithMany()
                        .HasForeignKey("ShippingInfoID");

                    b.HasOne("BookCave.Data.EntityModels.CardInfo", "cardInfo")
                        .WithMany()
                        .HasForeignKey("cardInfoID");

                    b.HasOne("BookCave.Data.EntityModels.Book", "favoriteBook")
                        .WithMany()
                        .HasForeignKey("favoriteBookId");
                });
#pragma warning restore 612, 618
        }
    }
}