﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Data.Mgrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240508184641_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Offer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("CountOfProducts")
                        .HasColumnType("integer");

                    b.Property<decimal>("OfferCost")
                        .HasColumnType("numeric");

                    b.Property<string>("OfferName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ShoppingCartId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ShoppingListId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ShoppingCartId");

                    b.HasIndex("ShoppingListId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("Domain.Entities.ShoppingCart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("Domain.Entities.ShoppingList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("ShoppingLists");
                });

            modelBuilder.Entity("Domain.Entities.StoreAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("MoneyBalance")
                        .HasColumnType("numeric");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("StoreAccounts");
                });

            modelBuilder.Entity("Domain.Entities.Offer", b =>
                {
                    b.HasOne("Domain.Entities.ShoppingCart", null)
                        .WithMany("Offers")
                        .HasForeignKey("ShoppingCartId");

                    b.HasOne("Domain.Entities.ShoppingList", null)
                        .WithMany("Offers")
                        .HasForeignKey("ShoppingListId");

                    b.OwnsOne("Domain.ValueObjects.OfferDescription", "Description", b1 =>
                        {
                            b1.Property<Guid>("OfferId")
                                .HasColumnType("uuid");

                            b1.Property<string>("MainInformation")
                                .HasColumnType("text");

                            b1.Property<string>("OfferDescriptionTitle")
                                .HasColumnType("text");

                            b1.HasKey("OfferId");

                            b1.ToTable("Offers");

                            b1.WithOwner()
                                .HasForeignKey("OfferId");

                            b1.OwnsMany("Domain.ValueObjects.StoredFile", "AddedPhotos", b2 =>
                                {
                                    b2.Property<Guid>("OfferDescriptionOfferId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b2.Property<int>("Id"));

                                    b2.Property<byte[]>("Data")
                                        .IsRequired()
                                        .HasColumnType("bytea");

                                    b2.Property<string>("Extension")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.Property<string>("Name")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.HasKey("OfferDescriptionOfferId", "Id");

                                    b2.ToTable("StoredFile");

                                    b2.WithOwner()
                                        .HasForeignKey("OfferDescriptionOfferId");
                                });

                            b1.Navigation("AddedPhotos");
                        });

                    b.Navigation("Description")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.ShoppingCart", b =>
                {
                    b.Navigation("Offers");
                });

            modelBuilder.Entity("Domain.Entities.ShoppingList", b =>
                {
                    b.Navigation("Offers");
                });
#pragma warning restore 612, 618
        }
    }
}
