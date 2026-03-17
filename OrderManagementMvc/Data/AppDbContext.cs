using Microsoft.EntityFrameworkCore;
using OrderManagementMvc.Models;


namespace OrderManagementMvc.Data
{
    public class AppDbContext : DbContext
    {

        // Construtor que recebe as opções de configuração do DbContext
        // (como string de conexão, tipo de banco, etc.)
        // Essas opções são configuradas no Program.cs
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {  }

        // Cada DbSet representa uma tabela no banco de dados
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        // Método responsável por configurar o modelo de dados do Entity Framework
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da entidade Product
            modelBuilder.Entity<Product>()
                // Define a propriedade Price (preço do produto)
                .Property(p => p.Price)
                // Configura o tipo decimal com precisão de 10 dígitos no total e 2 casas decimais
                .HasPrecision(10, 2);

            // Configuração da entidade OrderItem
            modelBuilder.Entity<OrderItem>()
                // Define a propriedade SalePrice (preço de venda do item)
                .Property(oi => oi.SalePrice)
                // Também define precisão decimal para evitar problemas de arredondamento
                .HasPrecision(10, 2);
        }
    }
}
