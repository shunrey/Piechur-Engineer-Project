﻿// <auto-generated />
using JurneyTag.Peristence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JurneyTag.Migrations
{
    [DbContext(typeof(ServiceDbContext))]
    partial class ServiceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JurneyTag.Core.Models.Accomodation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressBuild");

                    b.Property<string>("AddressCity");

                    b.Property<string>("AddressStreet");

                    b.Property<string>("Description");

                    b.Property<double>("MapPositionLatitude");

                    b.Property<double>("MapPositionLongitude");

                    b.Property<string>("Name");

                    b.Property<string>("Standard");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Accomodations");
                });

            modelBuilder.Entity("JurneyTag.Core.Models.Alimentation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccomodationId");

                    b.Property<double>("AdditionalPrice");

                    b.Property<string>("IsInOffert");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("AccomodationId");

                    b.ToTable("Alimentations");
                });

            modelBuilder.Entity("JurneyTag.Core.Models.Attraction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressBuild");

                    b.Property<string>("AddressCity");

                    b.Property<string>("AddressStreet");

                    b.Property<string>("Description");

                    b.Property<double>("HalfTicketPrice");

                    b.Property<double>("MapPositionLatitude");

                    b.Property<double>("MapPositionLongitude");

                    b.Property<string>("Name");

                    b.Property<string>("SeasonTime");

                    b.Property<double>("TicketPrice");

                    b.HasKey("Id");

                    b.ToTable("Attractions");
                });

            modelBuilder.Entity("JurneyTag.Core.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccomodationId");

                    b.Property<int>("Number");

                    b.Property<double>("Price");

                    b.Property<string>("Standard");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("AccomodationId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("JurneyTag.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Area");

                    b.Property<string>("Description");

                    b.Property<double>("MapPositionLatitude");

                    b.Property<double>("MapPositionLongitude");

                    b.Property<double>("MetersAboveSeaLevel");

                    b.Property<string>("Name");

                    b.Property<int>("Population");

                    b.Property<double>("PopulationDensity");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("JurneyTag.Core.Models.Alimentation", b =>
                {
                    b.HasOne("JurneyTag.Core.Models.Accomodation", "Accomodation")
                        .WithMany("Alimentations")
                        .HasForeignKey("AccomodationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JurneyTag.Core.Models.Room", b =>
                {
                    b.HasOne("JurneyTag.Core.Models.Accomodation", "Accomodation")
                        .WithMany("Rooms")
                        .HasForeignKey("AccomodationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
