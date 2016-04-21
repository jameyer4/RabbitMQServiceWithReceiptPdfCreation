using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Timers;

namespace OneWayMessageSender
{
    class Program
    {
        static void Main(string[] args)
        {
            //AmqpMessagingService messagingService = new AmqpMessagingService();
            //IConnection connection = messagingService.GetRabbitMqConnection();
            //IModel model = connection.CreateModel();
            /////Setup queue
            ////messagingService.SetUpQueueForOneWayMessageDemo(model);
            /////Send message to queue
            ////RunOneWayMessageDemo(model, messagingService);
            /////Consume message
            //messagingService.ReceiveOneWayMessages(model);

            string message = "ICAgICAgICAgICAgICBUZXN0IEludm9pY2UgICAgICAgICAgICAgIA0KLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLQ0KUmVmOiAgICAgICAgICAgICAgICAgICAgNzJDSEVaQllNQjM3Qk1LUw0KV2FpdGVyOiAgICAgICAgICAgICAgICAgICAgICAgQm9iIE1hcmxleQ0KVGFibGU6ICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIDQyMA0KLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLQ0KSXRlbSAgICAgICAgICAgICAgICAgICAgICAgUXR5ICAgIEFtb3VudA0KLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLQ0KLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLQ0KVE9UQUw6ICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgMCwwMA0KLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLQ0K";
            new ConvertToEOPdf(message, 1);
            // Console.ReadKey();
        }
        private static void RunOneWayMessageDemo(IModel model, AmqpMessagingService messagingService)
        {
            Console.WriteLine("Enter your message and press Enter. Quit with 'q'.");
            //while (true)
            //{
            for (int i = 0; i < 50; i++)
            {
                string message = "ICAgICAgICAgICAgICBUZXN0IEludm9pY2UgICAgICAgICAgICAgIA0KLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLQ0KUmVmOiAgICAgICAgICAgICAgICAgICAgNzJDSEVaQllNQjM3Qk1LUw0KV2FpdGVyOiAgICAgICAgICAgICAgICAgICAgICAgQm9iIE1hcmxleQ0KVGFibGU6ICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIDQyMA0KLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLQ0KSXRlbSAgICAgICAgICAgICAgICAgICAgICAgUXR5ICAgIEFtb3VudA0KLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLQ0KLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLQ0KVE9UQUw6ICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgMCwwMA0KLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLQ0K";
                messagingService.SendOneWayMessage(message, model);
            }
             // if (message.ToLower() == "q") break;
                
            //}
        }
    }
    class AmqpMessagingService
    {
        private string _hostName = "localhost";
        private string _userName = "guest";
        private string _password = "guest";
        private string _exchangeName = "";
        private string _oneWayMessageQueueName = "OneWayMessageQueue";
        private bool _durable = true;

        public IConnection GetRabbitMqConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory();
            connectionFactory.HostName = _hostName;
            connectionFactory.UserName = _userName;
            connectionFactory.Password = _password;

            return connectionFactory.CreateConnection();
        }
        public void SetUpQueueForOneWayMessageDemo(IModel model)
        {
            model.QueueDeclare(_oneWayMessageQueueName, _durable, false, false, null);
        }
        public void SendOneWayMessage(string message, IModel model)
        {
            IBasicProperties basicProperties = model.CreateBasicProperties();
            basicProperties.Persistent = (_durable);
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            model.BasicPublish(_exchangeName, _oneWayMessageQueueName, basicProperties, messageBytes);
        }
        public void ReceiveOneWayMessages(IModel model)
        {
            Timer timer = new Timer(1000);
            model.BasicQos(0, 1, false); //basic quality of service
            QueueingBasicConsumer consumer = new QueueingBasicConsumer(model);
            model.BasicConsume(_oneWayMessageQueueName, false, consumer);
            int i = 1;
            List<Task> tasks = new List<Task>();
            timer.Start();
            while (true)
            {
                BasicDeliverEventArgs deliveryArguments = consumer.Queue.Dequeue() as BasicDeliverEventArgs;
                String message = Encoding.UTF8.GetString(deliveryArguments.Body);
                Console.WriteLine("Message "+i+" received: {0}", message);
                model.BasicAck(deliveryArguments.DeliveryTag, false);
                //tasks.Add(Task.Factory.StartNew(() => new ConvertToEOPdf(message, i)));
                Task.Factory.StartNew(() => new ConvertToEOPdf(message, i));
                //Task.WaitAll(tasks.ToArray());

                //ConvertToPdf ctp = new ConvertToPdf(message);
                i++;
            }
        }
    }
}

