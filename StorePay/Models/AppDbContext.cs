using Microsoft.EntityFrameworkCore;

namespace StorePay.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Aplicativo> Aplicativos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Aplicativo>()
                .Property(a => a.Preco)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Aplicativo>()
                .HasData(
                    new Aplicativo
                    {
                        Id = 1,
                        Nome = "Waze",
                        Descricao = "Fique sempre por dentro do que está acontecendo nas ruas com o Waze. Mesmo que você saiba o caminho, o Waze lhe informa instantaneamente sobre o trânsito, obras, polícia, acidentes e outras coisas. Se o trânsito está ruim na sua rota, o Waze irá alterá-la para economizar seu tempo.",
                        Preco = 25.90M,
                        Produtora = "Waze",
                        Tamanho = "86MB"
                    },
                    new Aplicativo
                    {
                        Id = 2,
                        Nome = "WhatsApp Messenger",
                        Descricao = "O WhatsApp Messenger é um app de mensagens GRATUITO para Android e outras plataformas. O WhatsApp usa a conexão à internet do seu celular (4G/3G/2G/EDGE ou Wi-Fi, conforme disponível) para que você possa enviar mensagens e fazer chamadas para seus amigos e familiares. Deixe o SMS de lado e comece a usar o WhatsApp para enviar e receber mensagens, chamadas, fotos, vídeos, documentos e mensagens de voz.",
                        Preco = 9.50M,
                        Produtora = "WhatsApp LLC",
                        Tamanho = "120MB"
                    },
                    new Aplicativo
                    {
                        Id = 3,
                        Nome = "Instagram",
                        Descricao = "Conecte-se com amigos, compartilhe o que você está fazendo ou veja as novidades de outras pessoas no mundo todo. Explore nossa comunidade, um local onde você pode ser você mesmo(a) e compartilhar de tudo; da sua rotina a momentos importantes da sua vida.",
                        Preco = 37.20M,
                        Produtora = "Instagram",
                        Tamanho = "300MB"
                    }
                );
        }
    }
}
