using Confluent.Kafka;
using dotnet_kafka_implementation.Kafka;
using dotnet_kafka_implementation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static Confluent.Kafka.ConfigPropertyNames;

namespace dotnet_kafka_implementation.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly KafkaProducer _kafkaProducer;
        public OrderController(KafkaProducer kafkaProducer)
        {
            _kafkaProducer = kafkaProducer;
        }
        [HttpPost]
        public async Task<ActionResult> PostAsync(OrderRequest request)
        {
            //Validate the Model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //TO DO : Produce the Order Request to the Kafka Topic
            await _kafkaProducer.ProduceMessageAsync("OrderRequest", JsonSerializer.Serialize(request));

            return Ok("Order request is Processing!");
        }
    }
}
