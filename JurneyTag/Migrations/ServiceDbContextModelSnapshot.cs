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
#pragma warning restore 612, 618
        }
    }
}