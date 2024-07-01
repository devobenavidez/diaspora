# Diaspora Backend

## Descripción

Este proyecto constituye el backend de la solución web para la gestión de envíos de no-residentes (principalmente uruguayos viviendo en Europa) a sus familiares en Uruguay. La solución está desarrollada utilizando .NET 8 y se integra con una plataforma existente que maneja las operaciones y registros de envíos.

## Características

- Registro de usuarios no-residentes.
- Gestión de envíos y destinatarios.
- Notificaciones a los destinatarios.
- Integración con pasarelas de pago.
- Documentación y trámites aduaneros automatizados.

## Requisitos Previos

- .NET 8 SDK
- Docker (opcional, para contenedores)
- Un servidor de base de datos MySQL

## Instalación

### Clonar el Repositorio

```bash
git clone https://github.com/devobenavidez/diaspora.git
cd diaspora
```



## Configuración de Git Hooks

Este repositorio utiliza Git hooks para asegurar la calidad del código antes de que se realicen commits. Los hooks verifican automáticamente el cumplimiento de nuestras reglas de linting y ejecutan pruebas unitarias para asegurar que no se introduzcan regresiones en la base de código.

**Instalación de Git Hooks**
Para configurar los hooks de pre-commit en tu entorno de desarrollo local, sigue estos pasos:

**Para usuarios de Unix/Linux/MacOS:**

 1. Abrir la Terminal.
 2. Navegar al directorio raíz de tu repositorio clonado. Asegúrate de
    que estás en el directorio que contiene el .git subdirectorio.
 3. Ejecutar el script de instalación:

    ./githooks/install-hooks.sh

Este script configurará los hooks necesarios en tu repositorio local.


**Para usuarios de Windows:**

 1. Abrir el Command Prompt o PowerShell.
 2. Navegar al directorio raíz de tu repositorio clonado. Asegúrate de
    que estás en el directorio que contiene el .git subdirectorio.
 3. Ejecutar el script de instalación:

    .\githooks\install-hooks.bat

Este script configurará los hooks necesarios en tu repositorio local.

**Verificación de la Configuración del Hook**

Después de instalar los hooks, cualquier intento de commit ejecutará automáticamente las reglas de linting y las pruebas unitarias definidas. Si alguna de estas verificaciones falla, el commit será abortado, y se mostrará un mensaje de error explicando la razón del fallo.

**Solución de Problemas**

Si encuentras problemas durante la instalación de los hooks o durante los commits, verifica lo siguiente:

 - Permisos de Ejecución: Asegúrate de que los scripts de instalación
   tienen permisos de ejecución. En sistemas Unix/Linux/MacOS, puedes
   establecer estos permisos con chmod +x githooks/install-hooks.sh.
 - Mensajes de Error: Lee atentamente los mensajes de error que pueden
   indicar qué verificaciones fallaron.



## Gestión de Migraciones de Base de Datos


**Para realizar cambios en la estructura de la base de datos, sigue estos pasos:**

**Crear un Script de Migración:** Si deseas subir algún cambio a la base de datos de tablas o estructura, coloca el script en el directorio Migrations que se encuentra en la raíz del proyecto.

**Nombre del Archivo:** El nombre del archivo debe ser el número de la historia de usuario o work item seguido de una descripción breve de la acción a ejecutar y la fecha en formato AAAA-MM-DD. Por ejemplo:

1234_update_orders_table_2024-06-16.sql
1235_update_orders_table_2024-06-16-1.sql

Si hay múltiples archivos con la misma fecha, agrega un guión y un número consecutivo al final de la fecha.

**Formato Único:** Asegúrate de que el nombre del archivo sea único dentro del directorio Migrations.

**Actualizar el Estado de Migración:** Después de crear y colocar el script de migración, actualiza el archivo migration_status.txt para reflejar que la migración está pendiente. Usa el siguiente comando para cambiar su contenido a PENDING:

Para Unix/Linux/MacOS y Windows (cmd o PowerShell):

```bash
echo "PENDING" > migration_status.txt
```

Ejemplo de Nombres de Archivos de Migración:

123_create_customers_table_2024-06-16.sql
124_alter_orders_table_2024-06-16.sql
124_alter_orders_table_2024-06-16-1.sql



**Contacto**
Para preguntas o comentarios, por favor contacta a obenavidez@gmai.com
