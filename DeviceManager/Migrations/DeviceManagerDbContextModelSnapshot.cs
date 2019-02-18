﻿// <auto-generated />
using System;
using DeviceManager.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DeviceManager.Migrations
{
    [DbContext(typeof(DeviceManagerDbContext))]
    partial class DeviceManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DeviceManager.EntityModel.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<int>("DeviceTypeId");

                    b.Property<string>("Name");

                    b.Property<decimal>("PriceDevice");

                    b.HasKey("Id");

                    b.HasIndex("DeviceTypeId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("DeviceManager.EntityModel.DevicePropertyValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DeviceId");

                    b.Property<int>("DeviceTypePropertyId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("DeviceTypePropertyId");

                    b.ToTable("DevicePropertyValues");
                });

            modelBuilder.Entity("DeviceManager.EntityModel.DeviceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("DeviceTypes");
                });

            modelBuilder.Entity("DeviceManager.EntityModel.DeviceTypeProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DeviceTypeId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("DeviceTypeId");

                    b.ToTable("DeviceTypeProperties");
                });

            modelBuilder.Entity("DeviceManager.EntityModel.Device", b =>
                {
                    b.HasOne("DeviceManager.EntityModel.DeviceType", "DeviceType")
                        .WithMany()
                        .HasForeignKey("DeviceTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DeviceManager.EntityModel.DevicePropertyValue", b =>
                {
                    b.HasOne("DeviceManager.EntityModel.Device", "Device")
                        .WithMany("DevicePropertyValues")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DeviceManager.EntityModel.DeviceTypeProperty", "DeviceTypeProperty")
                        .WithMany("DevicePropertyValues")
                        .HasForeignKey("DeviceTypePropertyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DeviceManager.EntityModel.DeviceType", b =>
                {
                    b.HasOne("DeviceManager.EntityModel.DeviceType", "Parent")
                        .WithMany("SubDeviceTypes")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("DeviceManager.EntityModel.DeviceTypeProperty", b =>
                {
                    b.HasOne("DeviceManager.EntityModel.DeviceType", "DeviceType")
                        .WithMany("DeviceTypeProperties")
                        .HasForeignKey("DeviceTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
