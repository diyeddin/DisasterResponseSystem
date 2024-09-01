﻿// <auto-generated />
using System;
using DisasterResponseSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DisasterResponseSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DisasterResponseSystem.Models.Donation", b =>
                {
                    b.Property<int>("DonationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DonationID"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRecieved")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DonorID")
                        .HasColumnType("int");

                    b.Property<bool>("IsAllocated")
                        .HasColumnType("bit");

                    b.HasKey("DonationID");

                    b.HasIndex("DonorID");

                    b.ToTable("Donations");
                });

            modelBuilder.Entity("DisasterResponseSystem.Models.Donor", b =>
                {
                    b.Property<int>("DonorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DonorID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DonorID");

                    b.ToTable("Donor");
                });

            modelBuilder.Entity("DisasterResponseSystem.Models.Donation", b =>
                {
                    b.HasOne("DisasterResponseSystem.Models.Donor", "Donor")
                        .WithMany("Donations")
                        .HasForeignKey("DonorID");

                    b.Navigation("Donor");
                });

            modelBuilder.Entity("DisasterResponseSystem.Models.Donor", b =>
                {
                    b.Navigation("Donations");
                });
#pragma warning restore 612, 618
        }
    }
}
