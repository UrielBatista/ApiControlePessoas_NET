using Microsoft.Extensions.Configuration;
using PessoasDataApi.Models;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PessoasDataApi.Services.Support
{
    // define interface and service
    public interface IMessageService
    {
        string Enqueue(PessoasGermany data);
    }

    public class LogData : IMessageService
    {
        ConnectionFactory _factory;
        IConnection _conn;
        IModel _channel;
        public LogData()
        {
            Console.WriteLine("Abrindo conexao com RabbitMQ");

            _factory = new ConnectionFactory() { HostName = "rabbitmq", Port = 5672 };
            _factory.UserName = "guest";
            _factory.Password = "guest";
            _conn = _factory.CreateConnection();
            _channel = _conn.CreateModel();
            _channel.QueueDeclare(queue: "hello",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);
        }
        public string Enqueue(PessoasGermany data)
        {
            string message = JsonSerializer.Serialize(data);
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "",
                                routingKey: "hello",
                                basicProperties: null,
                                body: body);
            Console.WriteLine(" [x] Published {0} to RabbitMQ", message);
            return message;
        }

    }

}
