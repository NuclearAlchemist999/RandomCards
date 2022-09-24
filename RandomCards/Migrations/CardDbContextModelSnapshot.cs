﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RandomCards.Data;

#nullable disable

namespace RandomCards.Migrations
{
    [DbContext(typeof(CardDbContext))]
    partial class CardDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RandomCards.Models.Card", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cards");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ed2d048f-1912-46ba-a57b-e28f3c292fab"),
                            Name = "ace spades"
                        },
                        new
                        {
                            Id = new Guid("786f5c46-767e-4148-ba59-a4d77fff417e"),
                            Name = "two spades"
                        },
                        new
                        {
                            Id = new Guid("b00e992a-07c0-4498-8201-00204554d4e6"),
                            Name = "three spades"
                        },
                        new
                        {
                            Id = new Guid("8f07c4c5-08d1-4386-b0d6-13f3a4df3c02"),
                            Name = "four spades"
                        },
                        new
                        {
                            Id = new Guid("bf0ddee0-789d-4a18-89eb-e9716f202fb4"),
                            Name = "five spades"
                        },
                        new
                        {
                            Id = new Guid("c1ce5893-7fa8-45e9-834b-bea81cd47944"),
                            Name = "six spades"
                        },
                        new
                        {
                            Id = new Guid("8e16adba-7bfd-4698-9025-8f793af3a67a"),
                            Name = "seven spades"
                        },
                        new
                        {
                            Id = new Guid("208b7e46-9e24-4595-b8e2-53ff62b83466"),
                            Name = "eight spades"
                        },
                        new
                        {
                            Id = new Guid("a3f95ac1-d02b-440f-b170-76d2e0b98208"),
                            Name = "nine spades"
                        },
                        new
                        {
                            Id = new Guid("007f7c60-4646-4ffc-8683-42c04a554d81"),
                            Name = "ten spades"
                        },
                        new
                        {
                            Id = new Guid("a10c43f9-503c-40a0-aa04-e361d25c52bb"),
                            Name = "jack spades"
                        },
                        new
                        {
                            Id = new Guid("4fb56ecf-df1e-4cd2-b72c-1e4bf0fdd511"),
                            Name = "queen spades"
                        },
                        new
                        {
                            Id = new Guid("99c9b894-ba6d-4ee8-bd0c-a527d2f83036"),
                            Name = "king spades"
                        },
                        new
                        {
                            Id = new Guid("d958da25-4344-457d-bcc2-916610414ed0"),
                            Name = "ace diamonds"
                        },
                        new
                        {
                            Id = new Guid("93b8dc5a-239f-4792-8804-9f6ba304d377"),
                            Name = "two diamonds"
                        },
                        new
                        {
                            Id = new Guid("ad560d04-aef3-4613-9969-9e5c6e4d6759"),
                            Name = "three diamonds"
                        },
                        new
                        {
                            Id = new Guid("3d91aa6f-4325-4afc-a99d-38b113e52f2b"),
                            Name = "four diamonds"
                        },
                        new
                        {
                            Id = new Guid("3858f116-2552-416a-8263-b0ec6f76859b"),
                            Name = "five diamonds"
                        },
                        new
                        {
                            Id = new Guid("635e48f4-e1fb-4eac-ae2b-c658e813843d"),
                            Name = "six diamonds"
                        },
                        new
                        {
                            Id = new Guid("1c0bc9a9-9d51-4d8b-b79b-a898a958663f"),
                            Name = "seven diamonds"
                        },
                        new
                        {
                            Id = new Guid("e9e5bbb7-6a39-4665-9704-e5c3c9f5c7f7"),
                            Name = "eight diamonds"
                        },
                        new
                        {
                            Id = new Guid("f91cbf1d-5011-4ce5-89e2-154f8242f8d1"),
                            Name = "nine diamonds"
                        },
                        new
                        {
                            Id = new Guid("b922714e-1573-49f3-9625-a77325673527"),
                            Name = "ten diamonds"
                        },
                        new
                        {
                            Id = new Guid("f36b817b-1d2f-4764-bbd4-5134cb22c058"),
                            Name = "jack diamonds"
                        },
                        new
                        {
                            Id = new Guid("f8d855c5-3b35-4d53-8d74-64356fb2f6f3"),
                            Name = "queen diamonds"
                        },
                        new
                        {
                            Id = new Guid("b4266bf2-c05b-404b-af6b-0b626ec4d08c"),
                            Name = "king diamonds"
                        },
                        new
                        {
                            Id = new Guid("660e2b0d-ff7e-4a61-b357-1f8d63bcda1f"),
                            Name = "ace clubs"
                        },
                        new
                        {
                            Id = new Guid("24d276d8-0bed-4231-b075-ff349afff152"),
                            Name = "two clubs"
                        },
                        new
                        {
                            Id = new Guid("720d9b0c-d182-4c4d-aab0-c697f2eccef8"),
                            Name = "three clubs"
                        },
                        new
                        {
                            Id = new Guid("0493c1c2-189c-47fd-b597-ae3f4c5af752"),
                            Name = "four clubs"
                        },
                        new
                        {
                            Id = new Guid("c7a6c000-a283-43bc-9d44-c276e424900c"),
                            Name = "five clubs"
                        },
                        new
                        {
                            Id = new Guid("1b97392a-c25b-4ec3-957c-09dad7cac4fd"),
                            Name = "six clubs"
                        },
                        new
                        {
                            Id = new Guid("5b0d7fbb-d085-4008-9955-b8e863e2fbdb"),
                            Name = "seven clubs"
                        },
                        new
                        {
                            Id = new Guid("d4c97442-f9c4-4971-a57b-718c5fbc602f"),
                            Name = "eight clubs"
                        },
                        new
                        {
                            Id = new Guid("c6141a7d-0af1-4f37-9b05-3b3f58d6107a"),
                            Name = "nine clubs"
                        },
                        new
                        {
                            Id = new Guid("1e8dc7b2-8dc7-41b2-b8a5-eff6a4748adc"),
                            Name = "ten clubs"
                        },
                        new
                        {
                            Id = new Guid("072bf392-cb7e-41e6-8000-1d01780df5c3"),
                            Name = "jack clubs"
                        },
                        new
                        {
                            Id = new Guid("a51469a6-144c-4e64-a73e-7a5f21eac651"),
                            Name = "queen clubs"
                        },
                        new
                        {
                            Id = new Guid("fc47fd32-3396-4873-8aed-f3151d011ef8"),
                            Name = "king clubs"
                        },
                        new
                        {
                            Id = new Guid("c4549873-0003-4a38-9dbe-a7bc96e04a06"),
                            Name = "ace hearts"
                        },
                        new
                        {
                            Id = new Guid("9a681dd0-29b9-4ef5-b363-efbcf4e0c56e"),
                            Name = "two hearts"
                        },
                        new
                        {
                            Id = new Guid("606284cd-52af-414f-98d7-364cf6ccc5a3"),
                            Name = "three hearts"
                        },
                        new
                        {
                            Id = new Guid("6cfbed3a-ab70-4a4f-94e7-3d12e1089c56"),
                            Name = "four hearts"
                        },
                        new
                        {
                            Id = new Guid("04502fbe-faa0-4b2a-ac51-bf659fc9f208"),
                            Name = "five hearts"
                        },
                        new
                        {
                            Id = new Guid("788b08bc-60a7-4076-8a5b-d2d7d343c0fd"),
                            Name = "six hearts"
                        },
                        new
                        {
                            Id = new Guid("66915fbd-892c-4cc5-8f4c-9236c143dd0b"),
                            Name = "seven hearts"
                        },
                        new
                        {
                            Id = new Guid("06a61a93-882e-4dd1-92b6-3a034af8b03c"),
                            Name = "eight hearts"
                        },
                        new
                        {
                            Id = new Guid("8ffd4219-30d5-40e6-b577-d29e43a4085b"),
                            Name = "nine hearts"
                        },
                        new
                        {
                            Id = new Guid("fb39002e-8452-40e2-83de-a041cf2e2de0"),
                            Name = "ten hearts"
                        },
                        new
                        {
                            Id = new Guid("5d6cc6de-72c9-45bc-ae26-de2237ca3dac"),
                            Name = "jack hearts"
                        },
                        new
                        {
                            Id = new Guid("f1152d96-ed83-4607-ac1e-603c410eb0a3"),
                            Name = "queen hearts"
                        },
                        new
                        {
                            Id = new Guid("9a7fa761-9651-4711-a45b-3085d5dfcc54"),
                            Name = "king hearts"
                        });
                });

            modelBuilder.Entity("RandomCards.Models.CardGame", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("GameId");

                    b.ToTable("Cards_Games");
                });

            modelBuilder.Entity("RandomCards.Models.CardHand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HandId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("HandId");

                    b.ToTable("Cards_Hands");
                });

            modelBuilder.Entity("RandomCards.Models.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TimeStamp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("RandomCards.Models.Hand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Hands");
                });

            modelBuilder.Entity("RandomCards.Models.CardGame", b =>
                {
                    b.HasOne("RandomCards.Models.Card", "Card")
                        .WithMany("CardGames")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RandomCards.Models.Game", "Game")
                        .WithMany("CardGames")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Card");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("RandomCards.Models.CardHand", b =>
                {
                    b.HasOne("RandomCards.Models.Card", "Card")
                        .WithMany("CardHands")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RandomCards.Models.Hand", "Hand")
                        .WithMany("CardHands")
                        .HasForeignKey("HandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Card");

                    b.Navigation("Hand");
                });

            modelBuilder.Entity("RandomCards.Models.Hand", b =>
                {
                    b.HasOne("RandomCards.Models.Game", "Game")
                        .WithMany("Hands")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("RandomCards.Models.Card", b =>
                {
                    b.Navigation("CardGames");

                    b.Navigation("CardHands");
                });

            modelBuilder.Entity("RandomCards.Models.Game", b =>
                {
                    b.Navigation("CardGames");

                    b.Navigation("Hands");
                });

            modelBuilder.Entity("RandomCards.Models.Hand", b =>
                {
                    b.Navigation("CardHands");
                });
#pragma warning restore 612, 618
        }
    }
}