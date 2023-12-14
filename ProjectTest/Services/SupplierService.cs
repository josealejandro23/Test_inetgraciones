using Microsoft.EntityFrameworkCore;
using Test_jvarg361.DBContext;

namespace Test_jvarg361.Services
{
    public class SupplierService:ISupplierService
    {
        private IApplicationContextDB _ContextDB;

        //Se recibe por inyección de dependencias el objeto de base de datos
        public SupplierService(IApplicationContextDB applicationContextDB)
        {
            _ContextDB = applicationContextDB;
        }

        /*-----------------------------------------------------------------------------------------------------------*/
        //función para validar que el id de un supplier exista
        public async Task<bool>checkSupplier(int supplierId)
        {
            var supplier = await _ContextDB.Suppliers.Where(x => x.Id == supplierId).FirstOrDefaultAsync();
            if(supplier == null)
            {
                return false;
            }
            return true;
        }

        /*-----------------------------------------------------------------------------------------------------------*/

        //Función para obtener los ids de todos los suppliers
        public async Task<IEnumerable<int>> getSuppliersIds()
        {
            var ids = await _ContextDB.Suppliers.Select(x => x.Id).ToListAsync();
            return ids;
        }
    }
}
