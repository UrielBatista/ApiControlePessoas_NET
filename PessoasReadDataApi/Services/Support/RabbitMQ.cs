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
        string Enqueue(Bot data);
    }

    public class LogData : IMessageService
    {
        ConnectionFactory _factory;
        IConnection _conn;
        IModel _channel;
        public LogData()
        {
            //Open connection RabbitMQ
            try
            {
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
            } catch
            {
                Console.WriteLine("Pass Message user not logged!!");
            }
            
        }
        public string Enqueue(Bot data)
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
