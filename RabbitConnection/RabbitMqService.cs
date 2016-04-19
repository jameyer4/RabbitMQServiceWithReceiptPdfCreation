using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitConnection
{
    class RabbitMqService
    {
        public IConnection GetRabbitMqConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory();
            connectionFactory.HostName = "localhost";
            connectionFactory.UserName = "guest";
            connectionFactory.Password = "guest";

            return connectionFactory.CreateConnection();
        }

    }
}
