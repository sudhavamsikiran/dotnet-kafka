using dotnet_kafka_implementation.Kafka;

namespace dotnet_kafka_implementation.hostedservices
{
    public class BackgroundWorkerService: BackgroundService
    {
        public readonly ILogger<BackgroundWorkerService> _logger;
        private readonly KafkaConsumer _consumer;

        public BackgroundWorkerService(ILogger<BackgroundWorkerService> logger, KafkaConsumer consumer)
        {
            _logger = logger;
            _consumer = consumer;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    //_logger.LogInformation("Background Service is Runing at : {time}", DateTimeOffset.Now);

                    string orderRequest = await _consumer.Consume("OrderRequest"); //Consume the Kafka Message

                    //After Consume the Order Request Can process the order
                    if (!string.IsNullOrEmpty(orderRequest))
                        _logger.LogInformation("Order Request : {order}", orderRequest);


                    await Task.Delay(1000, stoppingToken);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"BackgroundWorkerService - Exception {ex}");
            }
        }

    }
}
