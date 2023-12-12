# Online Role Playing Game con Semantic Kernel y OpenAI

Este es el repositorio con el proyecto que sirve de demostración para la Tech Talk en al que se verá como construir un motor de un juego de rol online usando IA.

## Estructura

Es un proyecto web con el cliente desarrollado con React y la librería Mantine y como servidor se usa ASP.NET versión 8.0

- **Client**. Contiene todo el código del cliente web react. Está construido usando Vite.
- **Intelligence**. Aquí se encuntra toda la parte relacionada con el framework Semantic Kernel.
- **Server**. Es el servidor ASP.NET 

## Arrancando la aplicación

Para arrancanr el servidor siga estas instrucciones

1. Sitúese en la carpeta `Server`
2. Ejecute el comando `dotnet build`
3. Ejecute el comando `dotnet run`

Para iniciar el cliente las instrucciones está a continuación

1. Vaya a la carpera `Client`
2. Ejecutar `npm run buil`
3. Si todo va bien ejecute el comando `npm run dev`