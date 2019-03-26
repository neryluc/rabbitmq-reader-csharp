using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.IO;
using System.Text;

public class MessageReceiver
{
    public static IConfigurationRoot Configuration { get; set; }

    private static void ConfigureApp(){
        var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .AddEnvironmentVariables();

        Configuration = builder.Build();
    }

    public static void Main()
    {
        ConfigureApp();

        var rabbitMqHostName = Configuration["RabbitMQ:host"];
        var rabbitMqQueueName = Configuration["RabbitMQ:queue"];

        var factory = new ConnectionFactory() { HostName = rabbitMqHostName };
        using(var connection = factory.CreateConnection())
        using(var channel = connection.CreateModel())
        {
            Console.WriteLine($"Connect to {rabbitMqHostName}");

            channel.QueueDeclare(queue: rabbitMqQueueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            var consumer = new EventingBasicConsumer(channel);
            
            Console.WriteLine($"Started consuming events from queue {rabbitMqQueueName}.");
            
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] Received {0}", message);
            };

            channel.BasicConsume(queue: rabbitMqQueueName, autoAck: true, consumer: consumer);

            while(true);
        }
    }
}