# EventLoggerFrontend

Este proyecto fue generado con [Angular CLI](https://github.com/angular/angular-cli) version 17.2.0.

Esta aplicación aplica la estructura de estilo recomendada por Angular (core, shared, feature). Solo se realizo la implementación de las capas de feature y shared ya que lo recomendado es solo usar las capas que sean necesarias para la aplicación.

## Linea de estilos 

### core
Esta carpeta contiene los estilos globales que se aplican a toda la aplicación. Aquí se pueden definir estilos para elementos comunes como el cuerpo (`body`), la barra de navegación, el pie de página, entre otros. Estos estilos son compartidos por todos los componentes de la aplicación y son independientes de cualquier funcionalidad específica.

### shared
En la carpeta `shared`, se encuentran los estilos compartidos entre múltiples componentes, pero que no son globales en toda la aplicación como los de la carpeta `core`. Aquí se pueden definir estilos para componentes reutilizables, directivas, pipes, o cualquier otro elemento que necesite estilos compartidos entre diferentes partes de la aplicación.

### feature
Por último, la carpeta `feature` contiene estilos específicos para cada funcionalidad o característica de la aplicación. Cada característica o módulo de la aplicación puede tener su propia carpeta dentro de `feature`, donde se definen los estilos específicos para los componentes y elementos relacionados con esa funcionalidad en particular. Esto ayuda a mantener los estilos organizados y separados por contexto, lo que facilita el mantenimiento y la escalabilidad de la aplicación.

## Development server

Corre el comando `ng serve -o` para levantar el servidor local en la url `http://localhost:4200/`, este se abrira en el navegador por defecto automanticamente y se cargara la aplicación

