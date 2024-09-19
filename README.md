# Servidor TCP - Autenticación y Eco

Este proyecto implementa un servidor TCP básico que acepta conexiones de un cliente, realiza autenticación y responde con un eco de los mensajes recibidos. También permite finalizar la conexión con el cliente mediante un comando.

## Requisitos

- .NET 6.0 o superior

## Funcionalidades

- **Escucha conexiones TCP** en el puerto `12345`.
- **Autenticación** del cliente con la clave predefinida `admin123`.
- **Responde a comandos de eco**: Repite cualquier mensaje recibido.
- **Permite cerrar la conexión**: Si recibe el comando `exit`, cierra la sesión con el cliente.

## Instalación

1. **Clonar el repositorio**:

    ```bash
    git clone https://github.com/AaronF11/Server.git
    cd Server
    ```

2. **Compilar y ejecutar el servidor**:
    - Abre el proyecto en Visual Studio.
    - Ejecuta el proyecto (es una aplicación de consola).

## Uso

1. Ejecuta el servidor desde la consola.
2. El servidor estará en espera de conexiones en el puerto `12345`.
3. Cuando un cliente se conecta, este debe autenticarse con la clave `admin123`.
4. Una vez autenticado, el servidor responderá con eco a los comandos enviados por el cliente.
5. Para cerrar la conexión, el cliente debe enviar el comando `exit`.

## Ejemplo

### Consola del servidor

```bash
Servidor iniciado en el puerto 12345
Esperando conexión...
Cliente conectado.
Intento de autenticación: admin123
Autenticación exitosa
Comando recibido: Hola servidor
Comando recibido: exit
Cliente desconectado.
