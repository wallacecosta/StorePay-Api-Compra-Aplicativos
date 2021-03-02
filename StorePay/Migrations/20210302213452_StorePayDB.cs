using Microsoft.EntityFrameworkCore.Migrations;

namespace StorePay.Api.Migrations
{
    public partial class StorePayDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aplicativos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Produtora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tamanho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplicativos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Aplicativos",
                columns: new[] { "Id", "Descricao", "Nome", "Preco", "Produtora", "Tamanho" },
                values: new object[] { 1, "Fique sempre por dentro do que está acontecendo nas ruas com o Waze. Mesmo que você saiba o caminho, o Waze lhe informa instantaneamente sobre o trânsito, obras, polícia, acidentes e outras coisas. Se o trânsito está ruim na sua rota, o Waze irá alterá-la para economizar seu tempo.", "Waze", 25.90m, "Waze", "86MB" });

            migrationBuilder.InsertData(
                table: "Aplicativos",
                columns: new[] { "Id", "Descricao", "Nome", "Preco", "Produtora", "Tamanho" },
                values: new object[] { 2, "O WhatsApp Messenger é um app de mensagens GRATUITO para Android e outras plataformas. O WhatsApp usa a conexão à internet do seu celular (4G/3G/2G/EDGE ou Wi-Fi, conforme disponível) para que você possa enviar mensagens e fazer chamadas para seus amigos e familiares. Deixe o SMS de lado e comece a usar o WhatsApp para enviar e receber mensagens, chamadas, fotos, vídeos, documentos e mensagens de voz.", "WhatsApp Messenger", 9.50m, "WhatsApp LLC", "120MB" });

            migrationBuilder.InsertData(
                table: "Aplicativos",
                columns: new[] { "Id", "Descricao", "Nome", "Preco", "Produtora", "Tamanho" },
                values: new object[] { 3, "Conecte-se com amigos, compartilhe o que você está fazendo ou veja as novidades de outras pessoas no mundo todo. Explore nossa comunidade, um local onde você pode ser você mesmo(a) e compartilhar de tudo; da sua rotina a momentos importantes da sua vida.", "Instagram", 37.20m, "Instagram", "300MB" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aplicativos");
        }
    }
}
