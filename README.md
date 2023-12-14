## Prueba técnica integraciones
### José Alejandro Vargas
#### josealejandro.vargas@intcomex.com

Este proyecto tiene como objetivo brindar solución al requermiento planteado en el equipo de integraciones para el test de 
conocimientos.

El proyecto está desarrollado en **ASP NetCore 7** y hace uso de **Entity Framework Core** para la definición del modelo
de bases de datos bajo la metodología de programación ___Code First___.

El proyecto fue realizado bajo el modelo de arquitectura de software en capas, donde se hace clara distinción entre las capas de 
aplicación, servicios o de negocio y de acceso a datos, facilitando así su mantenimiento y escalabilidad.

Para su ejecución se debe de disponer de la capacidad de compilar el proyecto por ejemplo con _Visual Studio_ o bien
realizar el respectivo despliegue usando _Internet Information Services_, también llamado _IIS_.

**Importante** Configurar en el archivo appsettings.Development.json la cadena de conexión correspondiente a la base de datos a utilizar.

A continuación los pasos para ejecutar el proyecto correctamente desde Visual Studio como proyecto compilado.

1. Descargar el proyecto desde el repositorio
2. Abrir la solución en el entorno de desarrollo
3. De no estar incluidos instalar los paquetes Nugget Correspondientes a _MicrosoftEntityFrameworkCore.SqlServer_ en su versión 7.0
   y también el Nugget _MicrosoftEntityFrameworkCore.Tools_ en su versión 7.0
4. Realizar la migración del modelo de bases de datos definido en el código, para ello apoyarse de
   la consola __Package Manager Console__ incluida en Visual Studio, opción _view_
5. Abierta la consola ejecutar el comando `Add-Migration <nombre de la migración>` y esperar que se cree el archivo de clases correspondiente.
6. Hecha la migración ejecutar en la misma consola el comando `update-database`, esto asentará en la base de datos el modelo de datos creado previamente en el DBContext.
7. Validar en la db la existencia de las tablas definidas en la migración.
8. Ejecutar los scripts de la carpeta Query en el siguiente orden
- PopulateSuppliers.sql
- Create_SP_GetSuppliers.sql
- Create_Type_ProductBulk.sql
- Create_SP_BulkProducts.sql
9. Validar en la DB la existencia de los SP y tipos creados en el paso anterior.
10. Lanzar el proyecto y ejecutar las apis. Es necesario enviar la cabecera Authorization con valor "Intcomex" para permitir las peticiones.
11. Se recomienda inicialmente crear algunas categorías de productos.

Ejecución de pruebas
1. Se deben crear algunas categorías mediante el api
2. Ejecutar las pruebas unitarias de category test
3. Ejecutar las pruebas unitarias de Product test, en este caso para la ejecución de la última de las pruebas es necesario obtener de la db o mediante el api de paginación
un id de producto para validar que el api de obtención de producto por id funcione correctamente.

Los pasos anteriores deberían ser suficientes para la correcta ejecución del proyecto, para más facilidad es posible obtener 
el workspace de Postman de este proyecto desde el siguiente enlace 
[Link](https://www.postman.com/gold-flare-152783/workspace/test-intcomex/overview?ctx=settings "Test Intcomex Postman collection").
