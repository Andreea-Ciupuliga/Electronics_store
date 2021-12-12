using Electronics_store.Models;
using Microsoft.EntityFrameworkCore;

namespace Electronics_store.Data
{
    public class ElectronicsStoreContext : DbContext
    {
        //Pentru a manipula baza de date avem nevoie de "context".
        //Aici o sa declaram toate tabelele noastre ca seturi

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }

        //many to many
        public DbSet<OrderProductRelation> OrderProductRelations { get; set; }

        public ElectronicsStoreContext(DbContextOptions<ElectronicsStoreContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //aici o sa ne punem relatiile la baza de date

            //ONE TO MANY
            
            //User(1)-(M)Order
            builder.Entity<User>() //aici zic ca User are mai multe Orders
                .HasMany(u => u.Orders)
                .WithOne(o => o.User);
            
            //Category(1)-(M)Product

            builder.Entity<Product>() //se pastreaza ideea de mai sus dar zic invers
                .HasOne(p => p.Category)
                .WithMany(c => c.Products);
            
            
            //ONE TO ONE
            //Order-DeliveryAddress
            builder.Entity<Order>()
                .HasOne(o => o.DeliveryAddress)
                .WithOne(d =>d.Order)
                .HasForeignKey<DeliveryAddress>(d => d.OrderId);



            //MANY TO MANY
            //Order-Product
            builder.Entity<OrderProductRelation>()
                .HasKey(op => new
                {
                    op.OrderId, op.ProductId
                }); //ii zicem ca clasa/tabela OrderProductRelation o sa aiba id ul de forma op.OrderId,op.ProductId adica o sa fie format din cele 2 id uri


            builder.Entity<OrderProductRelation>()
                .HasOne<Order>(op => op.Order)
                .WithMany(o => o.OrderProductRelations)
                .HasForeignKey(op => op.OrderId);

            builder.Entity<OrderProductRelation>()
                .HasOne<Product>(op => op.Product)
                .WithMany(p => p.OrderProductRelations)
                .HasForeignKey(op => op.ProductId);
          

            base.OnModelCreating(builder);
        }
    }
}