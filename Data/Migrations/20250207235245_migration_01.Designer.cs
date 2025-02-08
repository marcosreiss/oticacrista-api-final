﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OticaCrista.Data;

#nullable disable

namespace OticaCrista.Migrations
{
    [DbContext(typeof(OticaCristaContext))]
    [Migration("20250207235245_migration_01")]
    partial class migration_01
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("OticaCrista.Models.Client.ClientModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AddressComplement")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("BornDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Cep")
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("Company")
                        .HasColumnType("longtext");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("longtext");

                    b.Property<string>("FatherName")
                        .HasColumnType("longtext");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("MotherName")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Negativated")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Neighborhood")
                        .HasColumnType("longtext");

                    b.Property<string>("Observation")
                        .HasColumnType("longtext");

                    b.Property<string>("Ocupation")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber2")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber3")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ReferenceName1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ReferenceName2")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ReferenceName3")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ReferencePhone1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ReferencePhone2")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ReferencePhone3")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Rg")
                        .HasColumnType("longtext");

                    b.Property<string>("SpouseName")
                        .HasColumnType("longtext");

                    b.Property<string>("Street")
                        .HasColumnType("longtext");

                    b.Property<string>("Uf")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("OticaCrista.Models.Product.BrandModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("OticaCrista.Models.Product.ProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Addition")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<decimal>("BuyPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("OticaCrista.Models.Sale.PaymentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Discount")
                        .HasColumnType("double");

                    b.Property<double>("DownPayment")
                        .HasColumnType("double");

                    b.Property<DateOnly>("DueDate")
                        .HasColumnType("date");

                    b.Property<int>("Installments")
                        .HasColumnType("int");

                    b.Property<int>("Method")
                        .HasColumnType("int");

                    b.Property<int>("SaleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SaleId")
                        .IsUnique();

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("OticaCrista.Models.Sale.SaleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Adicao")
                        .HasColumnType("double");

                    b.Property<string>("Book")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("CentroOtico")
                        .HasColumnType("double");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Crm")
                        .HasColumnType("longtext");

                    b.Property<string>("DoctorName")
                        .HasColumnType("longtext");

                    b.Property<double>("OdCilindrico")
                        .HasColumnType("double");

                    b.Property<double>("OdDnp")
                        .HasColumnType("double");

                    b.Property<double>("OdEixo")
                        .HasColumnType("double");

                    b.Property<double>("OdEsferico")
                        .HasColumnType("double");

                    b.Property<double>("OeCilindrico")
                        .HasColumnType("double");

                    b.Property<double>("OeDnp")
                        .HasColumnType("double");

                    b.Property<double>("OeEixo")
                        .HasColumnType("double");

                    b.Property<double>("OeEsferico")
                        .HasColumnType("double");

                    b.Property<string>("Page")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Ref")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ServiceOrder")
                        .HasColumnType("int");

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("OticaCrista.Models.Sale.SaleProductItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<double>("Discount")
                        .HasColumnType("double");

                    b.Property<double>("FinalPrice")
                        .HasColumnType("double");

                    b.Property<string>("Observation")
                        .HasColumnType("longtext");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("SaleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SaleId");

                    b.ToTable("SalesProducts");
                });

            modelBuilder.Entity("OticaCrista.Models.Sale.SaleServiceItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<double>("Discount")
                        .HasColumnType("double");

                    b.Property<double>("FinalPrice")
                        .HasColumnType("double");

                    b.Property<string>("Observation")
                        .HasColumnType("longtext");

                    b.Property<int>("SaleId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SaleId");

                    b.HasIndex("ServiceId");

                    b.ToTable("SalesServices");
                });

            modelBuilder.Entity("OticaCrista.Models.Service.ServiceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("OticaCrista.Models.Product.ProductModel", b =>
                {
                    b.HasOne("OticaCrista.Models.Product.BrandModel", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("OticaCrista.Models.Sale.PaymentModel", b =>
                {
                    b.HasOne("OticaCrista.Models.Sale.SaleModel", "Sale")
                        .WithOne("Payment")
                        .HasForeignKey("OticaCrista.Models.Sale.PaymentModel", "SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("OticaCrista.Models.Sale.SaleModel", b =>
                {
                    b.HasOne("OticaCrista.Models.Client.ClientModel", "Client")
                        .WithMany("Sales")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("OticaCrista.Models.Sale.SaleProductItem", b =>
                {
                    b.HasOne("OticaCrista.Models.Product.ProductModel", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OticaCrista.Models.Sale.SaleModel", "Sale")
                        .WithMany("Products")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("OticaCrista.Models.Sale.SaleServiceItem", b =>
                {
                    b.HasOne("OticaCrista.Models.Sale.SaleModel", "Sale")
                        .WithMany("Services")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OticaCrista.Models.Service.ServiceModel", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sale");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("OticaCrista.Models.Client.ClientModel", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("OticaCrista.Models.Product.BrandModel", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("OticaCrista.Models.Sale.SaleModel", b =>
                {
                    b.Navigation("Payment")
                        .IsRequired();

                    b.Navigation("Products");

                    b.Navigation("Services");
                });
#pragma warning restore 612, 618
        }
    }
}
