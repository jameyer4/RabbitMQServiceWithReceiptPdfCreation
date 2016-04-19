using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace RabbitConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            RabbitMqService rabbitMqService = new RabbitMqService();
            IConnection connection = rabbitMqService.GetRabbitMqConnection();
            IModel model = connection.CreateModel();
            SetupInitialTopicQueue(model);
            IBasicProperties basicProperties = model.CreateBasicProperties();
            basicProperties.Persistent=false;
            byte[] payload = Encoding.UTF8.GetBytes("This is a message from Visual Studio");
            PublicationAddress address = new PublicationAddress(ExchangeType.Topic, "ArnoExchange", "pdf");
            model.BasicPublish(address, basicProperties, payload);
        }
        private static void SetupInitialTopicQueue(IModel model)
        {
            model.QueueDeclare("PDFqueue", true, false, false, null);
            model.ExchangeDeclare("ArnoExchange", ExchangeType.Topic, true);
            model.QueueBind("PDFqueue", "ArnoExchange", "pdf");
        }

    }
}
