using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatClient
{
    class Program
    {
        private static ClientWebSocket _clientWebSocket = new ClientWebSocket();

        static async Task Main(string[] args)
        {
            Console.Write("Введите имя пользователя: ");
            string username = Console.ReadLine();

            Uri serverUri = new Uri($"ws://localhost:5132/ws?username={username}");
            await _clientWebSocket.ConnectAsync(serverUri, CancellationToken.None);

            var receiveTask = ReceiveMessages();

            Console.WriteLine("Для выхода введите /exit");
            while (true)
            {
                string message = Console.ReadLine();
                if (message.ToLower() == "/exit")
                {
                    await _clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Client disconnecting", CancellationToken.None);
                    break;
                }
                await SendMessage(message);
            }

            await receiveTask;
        }

        private static async Task SendMessage(string message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            await _clientWebSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        private static async Task ReceiveMessages()
        {
            var buffer = new byte[1024 * 4];
            while (_clientWebSocket.State == WebSocketState.Open)
            {
                var result = await _clientWebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, result.Count));
            }
        }
    }
}