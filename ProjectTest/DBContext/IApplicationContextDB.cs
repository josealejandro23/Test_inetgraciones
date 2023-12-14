using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Test_jvarg361.Entitys;

namespace Test_jvarg361.DBContext
{
    //Se define una interfaz para la conexión a la db lo que permitiría utilizar diferentes DBContext bajo un mismo set de
    //operaciones, tablas y funciones.
    public interface IApplicationContextDB
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Supplier> Suppliers { get; set; }

        SqlConnection getDBConnection();
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken));
    }
}
