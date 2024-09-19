using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    /// <summary>
    /// Este programa implementa un servidor TCP simple que espera la conexión de un cliente,
    /// realiza una autenticación básica, responde a comandos de eco y permite cerrar la conexión.
    /// El servidor escucha en el puerto especificado y maneja un cliente a la vez.
    /// </summary>
    /// <param name="args">Argumentos de línea de comando (no utilizados).</param>
    public static void Main(string[] args)
    {
        TcpListener? server = null;

        try
        {
            int port = 12345;
            server = new TcpListener(IPAddress.Any, port);
            server.Start();

            Console.WriteLine($"Servidor iniciado en el puerto {port}");

            while (true)
            {
                Console.WriteLine("Esperando conexion...");
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Cliente conectado.");

                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int bytesRead;

                bytesRead = stream.Read(buffer, 0, buffer.Length);
                string receivedData = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Intento de autenticacion: {receivedData.Trim()}");

                if (receivedData.Trim() == "admin123")
                {
                    string response = "Autenticacion exitosa";
                    stream.Write(Encoding.ASCII.GetBytes(response), 0, response.Length);
                }
                else
                {
                    string response = "Autenticacion fallida";
                    stream.Write(Encoding.ASCII.GetBytes(response), 0, response.Length);
                    client.Close();
                    continue;
                }

                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    receivedData = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"Comando recibido: {receivedData}");

                    if (receivedData.Trim().ToLower() == "exit")
                    {
                        string closeMessage = "Conexion cerrada.";
                        stream.Write(Encoding.ASCII.GetBytes(closeMessage), 0, closeMessage.Length);
                        break;
                    }
                    else
                    {
                        string echoResponse = $"Echo: {receivedData}";
                        stream.Write(Encoding.ASCII.GetBytes(echoResponse), 0, echoResponse.Length);
                    }
                }

                client.Close();
                Console.WriteLine("Cliente desconectado.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
        finally
        {
            if (server != null)
            {
                server.Stop();
            }
        }
    }
}
