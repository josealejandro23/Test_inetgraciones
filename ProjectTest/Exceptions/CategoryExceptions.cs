namespace Test_jvarg361.Exceptions
{
    //Se define un tipo particular de excepciones para operaciones relacionadas a errores de categorías
    public class CategoryException : Exception
    {
        public CategoryException()
        {
        }
        //Sobrecarga de constructor para mensajes de error
        public CategoryException(string message)
            : base(message) { }
    }
}
