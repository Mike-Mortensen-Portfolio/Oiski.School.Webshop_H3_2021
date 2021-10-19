﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oiski.School.Webshop_H3_2021.Datalayer.Domain;

namespace Oiski.School.Webshop_H3_2021.Datalayer.Migrations
{
    [DbContext(typeof(WebshopContext))]
    [Migration("20211019112346_ContextFix#29")]
    partial class ContextFix29
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
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

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("CustomerID");

                    b.HasIndex("UserID")
                        .IsUnique()
                        .HasFilter("[UserID] IS NOT NULL");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerID = 1,
                            Address = "Nygade 38A, 2",
                            City = "Aabenraa",
                            Country = "Denmark",
                            DeliveryType = 0,
                            Email = "jasminnielsen97@gmail.com",
                            FirstName = "Jasmin",
                            LastName = "Nielsen",
                            PaymentMethod = 0,
                            PhoneNumber = "26139596",
                            ZipCode = 6200
                        },
                        new
                        {
                            CustomerID = 2,
                            Address = "Ringgade 65",
                            City = "Sønderborg",
                            Country = "Denmark",
                            DeliveryType = 0,
                            Email = "zhakalen@gmail.com",
                            FirstName = "Mike",
                            LastName = "Mortensen",
                            PaymentMethod = 0,
                            PhoneNumber = "25987658",
                            ZipCode = 6400
                        },
                        new
                        {
                            CustomerID = 3,
                            Address = "Nordre Ringvej 20",
                            City = "Vojens",
                            Country = "Denmark",
                            DeliveryType = 0,
                            Email = "ulrikLarsen@gmail.com",
                            FirstName = "Ulrik",
                            LastName = "Larsen",
                            PaymentMethod = 0,
                            PhoneNumber = "25496875",
                            ZipCode = 6500
                        });
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

                    b.HasData(
                        new
                        {
                            OrderID = 1,
                            CustomerID = 2,
                            OrderDate = new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            OrderID = 2,
                            CustomerID = 1,
                            OrderDate = new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Oiski.School.Webshop_H3_2021.Datalayer.Entities.OrderProduct", b =>
                {
                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductID", "OrderID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderProducts");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            OrderID = 1,
                            Quantity = 0
                        },
                        new
                        {
                            ProductID = 4,
                            OrderID = 1,
                            Quantity = 0
                        },
                        new
                        {
                            ProductID = 5,
                            OrderID = 1,
                            Quantity = 0
                        },
                        new
                        {
                            ProductID = 2,
                            OrderID = 2,
                            Quantity = 0
                        },
                        new
                        {
                            ProductID = 3,
                            OrderID = 2,
                            Quantity = 0
                        });
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

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            BrandName = "New Look",
                            Description = "These pants are great for the Autumn weather.",
                            InStock = 125,
                            Price = 40.58m,
                            Title = "High-waisted jeans"
                        },
                        new
                        {
                            ProductID = 2,
                            BrandName = "TopShop",
                            Description = "The perfect outfit for your lower body.",
                            InStock = 50,
                            Price = 26.25m,
                            Title = "Skater skirt"
                        },
                        new
                        {
                            ProductID = 3,
                            BrandName = "NA-KD",
                            Description = "Beer parties on the beach? This is your dress.",
                            InStock = 75,
                            Price = 53.75m,
                            Title = "Summer dress"
                        },
                        new
                        {
                            ProductID = 4,
                            BrandName = "Nike",
                            Description = "Love long walks? Choose these sneakers.",
                            InStock = 130,
                            Price = 88m,
                            Title = "Sneakers paradise"
                        },
                        new
                        {
                            ProductID = 5,
                            BrandName = "H&M",
                            Description = "Drink a warm cup of chocolate while cozing up in this sweater.",
                            InStock = 109,
                            Price = 28m,
                            Title = "Warm knitted-sweater"
                        },
                        new
                        {
                            ProductID = 6,
                            BrandName = "Nike Air",
                            Description = "Perfect for the daily life.",
                            InStock = 180,
                            Price = 52m,
                            Title = "Simple Sneakers"
                        },
                        new
                        {
                            ProductID = 7,
                            BrandName = "H&M Basic",
                            Description = "Style it however you'd want to!",
                            InStock = 256,
                            Price = 15m,
                            Title = "Simple T-shirt"
                        });
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

                    b.HasData(
                        new
                        {
                            ProductImageID = 1,
                            ImageStream = new byte[0],
                            ProductID = 1,
                            Title = "High-Waisted-Jeans-Front"
                        },
                        new
                        {
                            ProductImageID = 2,
                            ImageStream = new byte[0],
                            ProductID = 1,
                            Title = "High-Waisted-Jeans-Back"
                        },
                        new
                        {
                            ProductImageID = 3,
                            ImageStream = new byte[0],
                            ProductID = 2,
                            Title = "Skater-Skirt-Front"
                        },
                        new
                        {
                            ProductImageID = 4,
                            ImageStream = new byte[0],
                            ProductID = 2,
                            Title = "Skater-Skirt-Back"
                        },
                        new
                        {
                            ProductImageID = 5,
                            ImageStream = new byte[0],
                            ProductID = 3,
                            Title = "Summer-Dress-Front"
                        },
                        new
                        {
                            ProductImageID = 6,
                            ImageStream = new byte[0],
                            ProductID = 3,
                            Title = "Summer-Dress-Back"
                        },
                        new
                        {
                            ProductImageID = 7,
                            ImageStream = new byte[0],
                            ProductID = 4,
                            Title = "Sneakers-Paradise-Front"
                        },
                        new
                        {
                            ProductImageID = 8,
                            ImageStream = new byte[0],
                            ProductID = 4,
                            Title = "Sneakers-Paradise-Back"
                        },
                        new
                        {
                            ProductImageID = 9,
                            ImageStream = new byte[0],
                            ProductID = 5,
                            Title = "Warm-Knitted-Sweater-Front"
                        },
                        new
                        {
                            ProductImageID = 10,
                            ImageStream = new byte[0],
                            ProductID = 5,
                            Title = "Warm-Knitted-Sweater-Back"
                        });
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

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            TypeID = 1
                        },
                        new
                        {
                            ProductID = 1,
                            TypeID = 12
                        },
                        new
                        {
                            ProductID = 2,
                            TypeID = 2
                        },
                        new
                        {
                            ProductID = 2,
                            TypeID = 3
                        },
                        new
                        {
                            ProductID = 2,
                            TypeID = 12
                        },
                        new
                        {
                            ProductID = 3,
                            TypeID = 4
                        },
                        new
                        {
                            ProductID = 3,
                            TypeID = 5
                        },
                        new
                        {
                            ProductID = 3,
                            TypeID = 13
                        },
                        new
                        {
                            ProductID = 4,
                            TypeID = 6
                        },
                        new
                        {
                            ProductID = 4,
                            TypeID = 7
                        },
                        new
                        {
                            ProductID = 5,
                            TypeID = 8
                        },
                        new
                        {
                            ProductID = 5,
                            TypeID = 9
                        },
                        new
                        {
                            ProductID = 5,
                            TypeID = 11
                        },
                        new
                        {
                            ProductID = 6,
                            TypeID = 6
                        },
                        new
                        {
                            ProductID = 6,
                            TypeID = 7
                        },
                        new
                        {
                            ProductID = 7,
                            TypeID = 8
                        },
                        new
                        {
                            ProductID = 7,
                            TypeID = 11
                        });
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

                    b.HasData(
                        new
                        {
                            TypeID = 1,
                            Name = "Jeans"
                        },
                        new
                        {
                            TypeID = 2,
                            Name = "Skirt"
                        },
                        new
                        {
                            TypeID = 3,
                            Name = "Skater-Skirt"
                        },
                        new
                        {
                            TypeID = 4,
                            Name = "Dress"
                        },
                        new
                        {
                            TypeID = 5,
                            Name = "Short-Dress"
                        },
                        new
                        {
                            TypeID = 6,
                            Name = "Footwear"
                        },
                        new
                        {
                            TypeID = 7,
                            Name = "Sneakers"
                        },
                        new
                        {
                            TypeID = 8,
                            Name = "Sweater"
                        },
                        new
                        {
                            TypeID = 9,
                            Name = "Knitted-Sweater"
                        },
                        new
                        {
                            TypeID = 10,
                            Name = "T-shirt"
                        },
                        new
                        {
                            TypeID = 11,
                            Name = "Upper-wear"
                        },
                        new
                        {
                            TypeID = 12,
                            Name = "Bottom"
                        },
                        new
                        {
                            TypeID = 13,
                            Name = "Full-body"
                        });
                });

            modelBuilder.Entity("Oiski.School.Webshop_H3_2021.Datalayer.Entities.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            CustomerID = 2,
                            IsAdmin = true,
                            Password = "P@ssw0rd"
                        },
                        new
                        {
                            UserID = 2,
                            CustomerID = 3,
                            IsAdmin = false,
                            Password = "P@ssw0rd"
                        },
                        new
                        {
                            UserID = 3,
                            CustomerID = 1,
                            IsAdmin = true,
                            Password = "P@ssw0rd"
                        });
                });

            modelBuilder.Entity("Oiski.School.Webshop_H3_2021.Datalayer.Entities.Customer", b =>
                {
                    b.HasOne("Oiski.School.Webshop_H3_2021.Datalayer.Entities.User", "User")
                        .WithOne("Customer")
                        .HasForeignKey("Oiski.School.Webshop_H3_2021.Datalayer.Entities.Customer", "UserID");

                    b.Navigation("User");
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
                    b.HasOne("Oiski.School.Webshop_H3_2021.Datalayer.Entities.Order", "Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Oiski.School.Webshop_H3_2021.Datalayer.Entities.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
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

            modelBuilder.Entity("Oiski.School.Webshop_H3_2021.Datalayer.Entities.User", b =>
                {
                    b.Navigation("Customer");
                });
#pragma warning restore 612, 618
        }
    }
}
