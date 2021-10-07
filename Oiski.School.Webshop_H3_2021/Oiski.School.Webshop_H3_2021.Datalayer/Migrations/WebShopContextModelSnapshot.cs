﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oiski.School.Webshop_H3_2021.Datalayer.Domain;

namespace Oiski.School.Webshop_H3_2021.Datalayer.Migrations
{
    [DbContext(typeof(WebShopContext))]
    partial class WebShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Oiski.School.Webshop_H3_2021.Datalayer.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CustomerLoginID")
                        .HasColumnType("int");

                    b.Property<int>("DeliveryType")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("CustomerID");

                    b.HasIndex("CustomerLoginID")
                        .IsUnique()
                        .HasFilter("[CustomerLoginID] IS NOT NULL");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Oiski.School.Webshop_H3_2021.Datalayer.Entities.CustomerLogin", b =>
                {
                    b.Property<int>("CustomerLoginID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerLoginID");

                    b.ToTable("CustomerLogins");
                });

            modelBuilder.Entity("Oiski.School.Webshop_H3_2021.Datalayer.Entities.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Oiski.School.Webshop_H3_2021.Datalayer.Entities.OrderProduct", b =>
                {
                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.HasKey("ProductID", "OrderID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("Oiski.School.Webshop_H3_2021.Datalayer.Entities.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InStock")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Oiski.School.Webshop_H3_2021.Datalayer.Entities.ProductImage", b =>
                {
                    b.Property<int>("ProductImageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("ImageStream")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductImageID");

                    b.HasIndex("ProductID");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("Oiski.School.Webshop_H3_2021.Datalayer.Entities.ProductType", b =>
                {
                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("TypeID")
                        .HasColumnType("int");

                    b.HasKey("ProductID", "TypeID");

                    b.HasIndex("TypeID");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("Oiski.School.Webshop_H3_2021.Datalayer.Entities.Type", b =>
                {
                    b.Property<int>("TypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeID");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("Oiski.School.Webshop_H3_2021.Datalayer.Entities.Customer", b =>
                {
                    b.HasOne("Oiski.School.Webshop_H3_2021.Datalayer.Entities.CustomerLogin", "CustomerLogin")
                        .WithOne("Customer")
                        .HasForeignKey("Oiski.School.Webshop_H3_2021.Datalayer.Entities.Customer", "CustomerLoginID");

                    b.Navigation("CustomerLogin");
                });

            modelBuilder.Entity("Oiski.School.Webshop_H3_2021.Datalayer.Entities.Order", b =>
                {
                    b.HasOne("Oiski.School.Webshop_H3_2021.Datalayer.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Oiski.School.Webshop_H3_2021.Datalayer.Entities.OrderProduct", b =>
                {
                    b.HasOne("Oiski.School.Webshop_H3_2021.Datalayer.Entities.Order", null)
                        .WithMany("Products")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Oiski.School.Webshop_H3_2021.Datalayer.Entities.Product", null)
                        .WithMany("Orders")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Oiski.School.Webshop_H3_2021.Datalayer.Entities.ProductImage", b =>
                {
                    b.HasOne("Oiski.School.Webshop_H3_2021.Datalayer.Entities.Product", null)
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Oiski.School.Webshop_H3_2021.Datalayer.Entities.ProductType", b =>
                {
                    b.HasOne("Oiski.School.Webshop_H3_2021.Datalayer.Entities.Product", "Product")
                        .WithMany("Types")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Oiski.School.Webshop_H3_2021.Datalayer.Entities.Type", "Type")
                        .WithMany("Products")
                        .HasForeignKey("TypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Oiski.School.Webshop_H3_2021.Datalayer.Entities.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Oiski.School.Webshop_H3_2021.Datalayer.Entities.CustomerLogin", b =>
                {
                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Oiski.School.Webshop_H3_2021.Datalayer.Entities.Order", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Oiski.School.Webshop_H3_2021.Datalayer.Entities.Product", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("ProductImages");

                    b.Navigation("Types");
                });

            modelBuilder.Entity("Oiski.School.Webshop_H3_2021.Datalayer.Entities.Type", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
