using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Test_jvarg361.Commons;
using Test_jvarg361.Entitys;

namespace Test_jvarg361.DBContext
{
    public class ApplicationDbContext : DbContext, IApplicationContextDB
    {
        //Se define un constructor que recibirá la cadena de conexión desde la definición del servicio en program.cs
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //se define un contructor vacío para generar conexiones a la db mediante el connection String
        public ApplicationDbContext() : base()
        {
        }

        //Se definen las tablas bajo la estrategia code First
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }

        //Se define el método necesario para conexiones mediante el connection string de la base de datos
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = ToolBox.getConfiguration("ConnectionStrings:DefaultConnection");
            // Configura la cadena de conexión a tu base de datos
            optionsBuilder.UseSqlServer(connectionString);
        }

        //Función para retornar un objeto de conexión a la db
        public SqlConnection getDBConnection()
        {
            return (SqlConnection)this.Database.GetDbConnection();
        }
    }
}
