using Confluent.Kafka;

namespace dotnet_kafka_implementation.Kafka
{
    public class KafkaProducer
    {
        private readonly IProducer<string, string> _producer;
        public KafkaProducer()
        {
            var producerConfig = new ProducerConfig
            {
                BootstrapServers = "localhost:9092" //Change the Kafka Bootstap Server URL
            };

            //Build the Producer
            _producer = new ProducerBuilder<string, string>(producerConfig).Build();
        }

        //Method for Produce the Message to Kafka Topic
        public async Task ProduceMessageAsync(string topic, string value)
        {
            var kafkaMessage = new Message<string, string>
            {
                Key = Guid.NewGuid().ToString(),
                Value = value
            };

            //Produce the Message
            await _producer.ProduceAsync(topic, kafkaMessage);
        }
    }
}
