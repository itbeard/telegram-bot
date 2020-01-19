using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace MyTelegram.Bot
{
    class Program
    {
        static public ITelegramBotClient botClient;
        static void Main(string[] args)
        {
            botClient = new TelegramBotClient("990278792:AAEAXEiFS85MtmkJ0FM7gTqI48YHOqUdHEo");
            var me = botClient.GetMeAsync().Result;
            Console.WriteLine(
              $"Hello, World! I am user {me.Id} and my name is {me.FirstName} username {me.Username}.");

            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            Thread.Sleep(int.MaxValue);
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id} an user name { e.Message.Chat.Username}.");

                switch(e.Message.Text)
                {
                    case string message when message == "/help":
                        await SendMessage(e.Message.Chat, "Сейчас помогу...");
                        break;
                    case string message when message == "/hello":
                        await SendMessage(e.Message.Chat, "ку!");
                        break;
                }
            }
        }

        static async Task SendMessage(Chat chatId, string message)
        {
            await botClient.SendTextMessageAsync(
              chatId: chatId,
              text: message
            );
        }
    }
}
