![](openinvoiceperulogo.png)
# OpenInvoicePeru v4.0 #
OpenInvoicePeru es un API REST multiplataforma construido con C#, haciendo sencilla la Facturación Electrónica de SUNAT, este proyecto está orientado al desarrollador.
Permite la generacion de XML, empaquetado, envío y recepción de documentos electrónicos a través de una API REST.

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
- El proyecto se ha desarrollado con VS2019 Version 16.11.4, usando como base .NET 5.
- Se recomienda usar encarecidamente VS2019 o superior, la edición [Community Edition](https://www.visualstudio.com/downloads/download-visual-studio-vs), es gratis y mucho mejor que sus predecesores.
Puede usar la versión Professional o Enterprise si lo desea.

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