﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StorePay.Models;

namespace StorePay.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StorePay.Models.Aplicativo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preco")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Produtora")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tamanho")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Aplicativos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Fique sempre por dentro do que está acontecendo nas ruas com o Waze. Mesmo que você saiba o caminho, o Waze lhe informa instantaneamente sobre o trânsito, obras, polícia, acidentes e outras coisas. Se o trânsito está ruim na sua rota, o Waze irá alterá-la para economizar seu tempo.",
                            Nome = "Waze",
                            Preco = 25.90m,
                            Produtora = "Waze",
                            Tamanho = "86MB"
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "O WhatsApp Messenger é um app de mensagens GRATUITO para Android e outras plataformas. O WhatsApp usa a conexão à internet do seu celular (4G/3G/2G/EDGE ou Wi-Fi, conforme disponível) para que você possa enviar mensagens e fazer chamadas para seus amigos e familiares. Deixe o SMS de lado e comece a usar o WhatsApp para enviar e receber mensagens, chamadas, fotos, vídeos, documentos e mensagens de voz.",
                            Nome = "WhatsApp Messenger",
                            Preco = 9.50m,
                            Produtora = "WhatsApp LLC",
                            Tamanho = "120MB"
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "Conecte-se com amigos, compartilhe o que você está fazendo ou veja as novidades de outras pessoas no mundo todo. Explore nossa comunidade, um local onde você pode ser você mesmo(a) e compartilhar de tudo; da sua rotina a momentos importantes da sua vida.",
                            Nome = "Instagram",
                            Preco = 37.20m,
                            Produtora = "Instagram",
                            Tamanho = "300MB"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}