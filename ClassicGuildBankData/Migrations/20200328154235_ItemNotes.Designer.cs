﻿// <auto-generated />
using System;
using ClassicGuildBankData.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClassicGuildBankData.Migrations
{
    [DbContext(typeof(ClassicGuildBankDbContext))]
    [Migration("20200328154235_ItemNotes")]
    partial class ItemNotes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClassicGuildBankData.Models.Bag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BagContainerId");

                    b.Property<Guid>("CharacterId");

                    b.Property<int?>("ItemId");

                    b.Property<bool>("isBank");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("ItemId");

                    b.ToTable("Bag");
                });

            modelBuilder.Entity("ClassicGuildBankData.Models.BagSlot", b =>
                {
                    b.Property<Guid>("BagId");

                    b.Property<int>("SlotId");

                    b.Property<int?>("ItemId");

                    b.Property<string>("Notes");

                    b.Property<int>("Quantity");

                    b.HasKey("BagId", "SlotId");

                    b.HasIndex("ItemId");

                    b.ToTable("BagSlot");
                });

            modelBuilder.Entity("ClassicGuildBankData.Models.Character", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Gold");

                    b.Property<Guid>("GuildId");

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.ToTable("Character");
                });

            modelBuilder.Entity("ClassicGuildBankData.Models.ClassicGuildBankUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<Guid>("LastSelectedGuildId");

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PatreonAccessToken");

                    b.Property<int>("PatreonExpiration");

                    b.Property<string>("PatreonRefreshToken");

                    b.Property<string>("Patreon_Id");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ClassicGuildBankData.Models.Guild", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("InviteUrl");

                    b.Property<string>("Name");

                    b.Property<bool>("PublicLinkEnabled")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("PublicUrl");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Guild");
                });

            modelBuilder.Entity("ClassicGuildBankData.Models.GuildMember", b =>
                {
                    b.Property<Guid>("GuildId");

                    b.Property<string>("UserId");

                    b.Property<bool>("CanUpload");

                    b.Property<string>("DisplayName");

                    b.HasKey("GuildId", "UserId");

                    b.ToTable("GuildRole");
                });

            modelBuilder.Entity("ClassicGuildBankData.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Class");

                    b.Property<string>("CnName");

                    b.Property<string>("DeName");

                    b.Property<string>("EsName");

                    b.Property<string>("FrName");

                    b.Property<string>("Icon");

                    b.Property<string>("ItName");

                    b.Property<string>("KoName");

                    b.Property<string>("Name");

                    b.Property<string>("PtName");

                    b.Property<string>("Quality");

                    b.Property<string>("RuName");

                    b.Property<int?>("Subclass");

                    b.HasKey("Id");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("ClassicGuildBankData.Models.ItemRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CharacterName");

                    b.Property<DateTime?>("DateRequested");

                    b.Property<int>("Gold");

                    b.Property<Guid>("GuildId");

                    b.Property<string>("Reason");

                    b.Property<string>("Status");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.ToTable("ItemRequest");
                });

            modelBuilder.Entity("ClassicGuildBankData.Models.ItemRequestDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ItemId");

                    b.Property<Guid>("ItemRequestId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("ItemRequestId");

                    b.ToTable("ItemRequestDetail");
                });

            modelBuilder.Entity("ClassicGuildBankData.Models.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CharacterName");

                    b.Property<Guid>("GuildId");

                    b.Property<int?>("Money");

                    b.Property<DateTime>("TransactionDate");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("ClassicGuildBankData.Models.TransactionDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ItemId");

                    b.Property<int>("Quantity");

                    b.Property<Guid>("TransactionId");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("TransactionId");

                    b.ToTable("TransactionDetail");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ClassicGuildBankData.Models.Bag", b =>
                {
                    b.HasOne("ClassicGuildBankData.Models.Character", "Character")
                        .WithMany("Bags")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ClassicGuildBankData.Models.Item", "BagItem")
                        .WithMany("Bags")
                        .HasForeignKey("ItemId");
                });

            modelBuilder.Entity("ClassicGuildBankData.Models.BagSlot", b =>
                {
                    b.HasOne("ClassicGuildBankData.Models.Bag", "Bag")
                        .WithMany("BagSlots")
                        .HasForeignKey("BagId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ClassicGuildBankData.Models.Item", "Item")
                        .WithMany("Slots")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("ClassicGuildBankData.Models.Character", b =>
                {
                    b.HasOne("ClassicGuildBankData.Models.Guild", "Guild")
                        .WithMany("Characters")
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ClassicGuildBankData.Models.GuildMember", b =>
                {
                    b.HasOne("ClassicGuildBankData.Models.Guild", "Guild")
                        .WithMany("GuildMembers")
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ClassicGuildBankData.Models.ItemRequest", b =>
                {
                    b.HasOne("ClassicGuildBankData.Models.Guild", "Guild")
                        .WithMany("ItemRequests")
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ClassicGuildBankData.Models.ItemRequestDetail", b =>
                {
                    b.HasOne("ClassicGuildBankData.Models.Item", "Item")
                        .WithMany("ItemRequestDetails")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("ClassicGuildBankData.Models.ItemRequest", "ItemRequest")
                        .WithMany("Details")
                        .HasForeignKey("ItemRequestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ClassicGuildBankData.Models.Transaction", b =>
                {
                    b.HasOne("ClassicGuildBankData.Models.Guild", "Guild")
                        .WithMany("Transactions")
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ClassicGuildBankData.Models.TransactionDetail", b =>
                {
                    b.HasOne("ClassicGuildBankData.Models.Item", "Item")
                        .WithMany("TransactionDetails")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("ClassicGuildBankData.Models.Transaction", "Transaction")
                        .WithMany("TransactionDetails")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ClassicGuildBankData.Models.ClassicGuildBankUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ClassicGuildBankData.Models.ClassicGuildBankUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ClassicGuildBankData.Models.ClassicGuildBankUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ClassicGuildBankData.Models.ClassicGuildBankUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
