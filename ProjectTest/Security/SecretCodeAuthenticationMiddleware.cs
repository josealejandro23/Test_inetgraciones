using Newtonsoft.Json;
using System.Net;

namespace Test_jvarg361.Security
{
    //Middleware personalizado para validar la cabecera de autorización en las peticiones
    public class SecretCodeAuthenticationMiddleware
    {
        //definición del objeto que contiene el siguiente middleware
        private readonly RequestDelegate _next;

        public SecretCodeAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //función que se lanza cuando se invoca un api
        public async Task Invoke(HttpContext context)
        {
            //Se obtiene el token enviado por el cliente
            var token = context.Request.Headers["Authorization"].FirstOrDefault();

            //se valida que sea correcto
            if (validateAuthorizationCode(token))
            {
                // Si es válido se continúa con la solicitud
                await _next(context);
            }
            else
            {
                // Si no es válido se devuelve un código de estado no autorizado
                context.Response.StatusCode = StatusCodes.Status401Unauthorized; 
                await context.Response.WriteAsJsonAsync(new { message = "No autorizado" });
                return;
            }
        }

        /*-----------------------------------------------------------------------------------------------------------*/

        //Función para validar el token recibido
        private bool validateAuthorizationCode(string token)
        {
            return token == "Intcomex";
        }
    }

    /*-----------------------------------------------------------------------------------------------------------*/

    //Se agrega una extensión para registrar el middleware en el constructor de la aplicación
    public static class SecretCodeAuthenticationExtensions
    {
        //Esta función recibirá el objeto servidor y le indica que debe agregar el middleware como uno más de la lista de pasos a ejecutar
        public static IApplicationBuilder UseSecretCodeAuthentication(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SecretCodeAuthenticationMiddleware>();
        }
    }

}
