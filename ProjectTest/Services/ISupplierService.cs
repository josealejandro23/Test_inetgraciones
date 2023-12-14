namespace Test_jvarg361.Services
{
    //Se define una interfaz para separar la capa de aplicación de la capa de servicios y de acceso a datos
    public interface ISupplierService
    {
        Task<bool> checkSupplier(int supplierId);
        Task<IEnumerable<int>> getSuppliersIds();
    }
}
