﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechStore.Vendas.Data;

namespace TechStore.Vendas.Data.Migrations
{
    [DbContext(typeof(VendasContext))]
    [Migration("20210301210050_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:.MinhaSequencia", "'MinhaSequencia', '', '1000', '1', '', '', 'Int32', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TechStore.Venda.Domain.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ClienteId");

                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEXT VALUE FOR MinhaSequencia");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<decimal>("Desconto");

                    b.Property<int>("PedidoStatus");

                    b.Property<decimal>("ValorTotal");

                    b.Property<Guid?>("VoucherId");

                    b.Property<bool>("VoucherUtilizado");

                    b.HasKey("Id");

                    b.HasIndex("VoucherId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("TechStore.Venda.Domain.PedidoItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("PedidoId");

                    b.Property<Guid>("ProdutoId");

                    b.Property<string>("ProdutoNome")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<int>("Quantidade");

                    b.Property<decimal>("ValorUnitario");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.ToTable("PedidoItems");
                });

            modelBuilder.Entity("TechStore.Venda.Domain.Voucher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("DataCriacao");

                    b.Property<DateTime?>("DataUtilizacao");

                    b.Property<DateTime>("DataValidade");

                    b.Property<decimal?>("Percentual");

                    b.Property<int>("Quantidade");

                    b.Property<int>("TipoDescontoVoucher");

                    b.Property<bool>("Utilizado");

                    b.Property<decimal?>("ValorDesconto");

                    b.HasKey("Id");

                    b.ToTable("Vouchers");
                });

            modelBuilder.Entity("TechStore.Venda.Domain.Pedido", b =>
                {
                    b.HasOne("TechStore.Venda.Domain.Voucher", "Voucher")
                        .WithMany("Pedidos")
                        .HasForeignKey("VoucherId");
                });

            modelBuilder.Entity("TechStore.Venda.Domain.PedidoItem", b =>
                {
                    b.HasOne("TechStore.Venda.Domain.Pedido", "Pedido")
                        .WithMany("PedidoItems")
                        .HasForeignKey("PedidoId");
                });
#pragma warning restore 612, 618
        }
    }
}