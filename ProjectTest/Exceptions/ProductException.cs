namespace Test_jvarg361.Exceptions
{
    //Se define un tipo particular de excepciones para operaciones relacionadas a errores de productos
    public class ProductException:Exception
    {
        public ProductException()
        {
        }
        //Sobrecarga de constructor para mensajes de error
        public ProductException(string message)
            : base(message) { }
    }
}
