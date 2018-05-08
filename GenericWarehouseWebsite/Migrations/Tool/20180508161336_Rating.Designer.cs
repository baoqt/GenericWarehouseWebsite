﻿// <auto-generated />
using GenericWarehouseWebsite.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace GenericWarehouseWebsite.Migrations.Tool
{
    [DbContext(typeof(WarehouseContext))]
    [Migration("20180508161336_Rating")]
    partial class Rating
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GenericWarehouseWebsite.Models.Component", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bin");

                    b.Property<decimal>("Cost");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("OwnerID");

                    b.Property<string>("PartNumber");

                    b.Property<int>("Quantity");

                    b.HasKey("ID");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("GenericWarehouseWebsite.Models.Tool", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bin");

                    b.Property<decimal>("Cost");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("OwnerID");

                    b.Property<string>("PartNumber");

                    b.Property<int>("Quantity");

                    b.HasKey("ID");

                    b.ToTable("Tools");
                });
#pragma warning restore 612, 618
        }
    }
}
