namespace dotnet_kafka_implementation.Models
{
    public class OrderRequest
    {
         
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<string> Products { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
