using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Data;
using Test_jvarg361.DBContext;
using Test_jvarg361.Entitys;

namespace Test_jvarg361.Commons
{
    public static class ToolBox
    {
        //función para validar si un supplier Id es válido
        public static bool checkSupplier(int id)
        {
            //se crea la conexión
            using (var db = new ApplicationDbContext())
            {
                //se ejecuta el sp para obtener todos los suppliers y se valida que no sea una lista vacía
                var suppliers = db.Suppliers.FromSqlRaw($"EXEC GetSuppliers").ToList();
                if(suppliers == null || suppliers.Count == 0)
                {
                    throw new Exception("No hay suppliers registrados, registre al menos uno primero.");
                }
                //se consulta por el id recibido y se retorna ok si existe
                var supplier = suppliers.Where(x => x.Id == id).FirstOrDefault();
                if(supplier == null)
                {
                    return false;
                }
                return true;
            }
        }
        
        /*-----------------------------------------------------------------------------------------------------------*/

        //función para obtener configuraciones de appsettings
        public static string getConfiguration(string name)
        {
            // Configurar el builder para leer el archivo appsettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

            // Construir la configuración
            IConfigurationRoot configuration = builder.Build();

            // Leer el valor desde la configuración
            string setting = configuration["ConnectionStrings:DefaultConnection"];
            return setting;
        }

        /*-----------------------------------------------------------------------------------------------------------*/

        //Función para validar que las categorias provistas sean correctas
        public static bool checkCategories(IEnumerable<string> categories)
        {
            using (var db = new ApplicationDbContext())
            {
                //se consultan las categorías por nombre
                var categoriesRegistered = db.Categories.Select(x => x.Name).ToList();
                if (categoriesRegistered == null || categoriesRegistered.Count == 0)
                {
                    throw new Exception("No hay categorías registradas, registre al menos una primero.");
                }
                //se pasan a minúscula los resultados para comparar sin ser caseSensitive
                categoriesRegistered = categoriesRegistered.Select(x => x.ToLower()).ToList();
                //se valida que TODAS las categorias provistas existan en la respuesta
                bool categoriasExisten = categories.All(x => categoriesRegistered.Contains(x.ToLower()));
                return categoriasExisten;
            }
        }

        /*-----------------------------------------------------------------------------------------------------------*/

        //función para validar el id de una única categoría
        public static bool checkCategorie(int categoriId)
        {
            using (var db = new ApplicationDbContext())
            {
                var categoriesRegistered = db.Categories.Where(x => x.Id == categoriId).ToList();
                if (categoriesRegistered == null || categoriesRegistered.Count == 0)
                {
                    return false;
                }
                return true;
            }
        }

        /*-----------------------------------------------------------------------------------------------------------*/

        //Función para generar aleatoriamente n productos
        public async static Task<IEnumerable<Product>> GenerateRandomProducts(int quantity, IEnumerable<int> categoriesIds, IEnumerable<int> suppliersIds)
        {
            {
                //cantidad de productos a generar por iteración de las funciones
                int cantidadPorIteracion = 5000;

                // Lista para almacenar los objetos
                List<Product> productos = new List<Product>();

                // iterar en paralelo tantas veces como se defina por iteracion
                for (int i = 0; i < quantity; i += cantidadPorIteracion)
                {
                    //se establecen los valores de inicio y fin para el ciclo que lanza las tareas
                    int inicio = i;
                    int fin = Math.Min(i + cantidadPorIteracion, quantity);
                    // Crear tareas en paralelo para obtener objetos
                    List<Task<Product>> tareas = new List<Task<Product>>();
                    for (int j = i; j < fin; j++)
                    {
                        //se lanza la tarea que crea cada producto
                        tareas.Add(Task.Run(() => GenerateProduct.GenerateRandomProduct(categoriesIds, suppliersIds)));
                    }

                    // Esperar a que todas las tareas finalicen
                    Task.WaitAll(tareas.ToArray());

                    //se anexan las tareas al response
                    foreach (var tarea in tareas)
                    {
                        productos.Add(tarea.Result);
                    }
                }
                return productos;
            }
        }

        /*-----------------------------------------------------------------------------------------------------------*/

        //función para convertir una lista a un dataset para ser enviado a la db
        public static DataTable FormatDataTable(IEnumerable<Product> products)
        {
            DataTable dt = new DataTable();
            // Obtener las propiedades del objeto y agregarlas como columnas a DataTable
            foreach (var propiedad in typeof(Product).GetProperties())
            {
                //Se excluye el id porque este es insertado por la db y no es necesario
                if(propiedad.Name.ToLower() == "id")
                {
                    continue;
                }
                dt.Columns.Add(propiedad.Name, propiedad.PropertyType);
            }
            // Agregar filas a DataTable
            foreach (var objeto in products)
            {
                DataRow fila = dt.NewRow();
                foreach (var propiedad in typeof(Product).GetProperties())
                {
                    if (propiedad.Name.ToLower() == "id")
                    {
                        continue;
                    }
                    fila[propiedad.Name] = propiedad.GetValue(objeto);
                }
                dt.Rows.Add(fila);
            }
            return dt;
        }
    }
}
