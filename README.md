![](openinvoiceperulogo.png)
# OpenInvoicePeru v5.0 #
OpenInvoicePeru es un API REST multiplataforma construido con C#, actualizado a .NET 9, que simplifica la Facturación Electrónica de SUNAT. Este proyecto está orientado al desarrollador y facilita la generación de XML, empaquetado, envío y recepción de documentos electrónicos a través de una API REST.

Si encuentra algún bug por favor reportarlo a la zona de [Issues](https://github.com/erickorlando/openinvoiceperucore/issues).

Para consultar las novedades y cambios del proyecto revise el [Control de Cambios](CHANGELOG.md)

# Características #
- Generación de XML los siguientes documentos electrónicos:
  - Facturas (UBL 2.1)
  - Boletas  (UBL 2.1)
  - Notas de Crédito (UBL 2.1)
  - Notas de Débito (UBL 2.1)
  - Resumen Diario de Boletas
  - Comunicaciones de Baja
  - Retenciones
  - Percepciones
  - Guías de Remisión (UBL 2.1)
 
- Firmado del XML con un certificado digital elegido por el usuario.
- Envío al servicio Web de SUNAT de los documentos electrónicos generados (Beta y Producción).
- Envío de Resumen Diario y Comunicación de Baja.
- Desempaquetado y Lectura del contenido del CDR de SUNAT.
- Consulta de Tickets de los Resúmenes y Bajas.

### Cliente API REST de Ejemplo ###
- Ejemplos en C# para el consumo de la API REST con PostSharp.

## Consideraciones ##
- El proyecto ha sido actualizado a .NET 9 y se ha desarrollado utilizando Visual Studio 2022.
- Se recomienda encarecidamente usar VS2022 o superior. La [Community Edition](https://visualstudio.microsoft.com/vs/community/) es gratuita.
- El proyecto `OpenInvoicePeru.WebApi` ha sido actualizado para utilizar el modelo de hosting minimalista introducido en .NET 6, consolidando la configuración de `Startup.cs` en `Program.cs`.
- Se ha migrado la serialización JSON de `Newtonsoft.Json` a `System.Text.Json` como parte de la modernización y para mejorar el rendimiento.
- La documentación de la API ahora está disponible no solo a través de SwaggerUI sino también mediante Scalar, accesible en la ruta `/scalar` de la WebApi.

## Descargo de Responsabilidad ##

Este software se entrega como tal y es libre de modificarlo a su gusto, copiarlo en su totalidad 
o de manera parcial, un agradecimiento público no cuesta nada.

Así mismo no hay garantía expresa de este producto, cualquier inconveniente que se presente con SUNAT 
es enteramente responsabilidad del usuario al usar este Software. 

Si tiene errores con SUNAT fíjese en el código devuelto:

- Del 0100 al 1999 Excepciones (Usuarios mal escritos, RUCs no validos, etc.).
- Del 2000 al 3999 Errores que generan rechazo (Se envia pero rebota).
- Del 4000 en adelante Observaciones (Correcciones menores).

Si tiene mas dudas con SUNAT comuníquese con ellos al [+51 1 3150730](tel:+5113150730).

## Aportes de la Comunidad ##

Si consideras que este proyecto vale la pena, puedes convertirte en sponsor o aportar código haciendo un fork y posteriormente enviando tus Pull Request, todo aporte como siempre es bienvenido.