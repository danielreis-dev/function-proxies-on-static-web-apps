using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System;
using System.Linq;

namespace MyStore.Orders
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int Count { get; set; }

        public decimal IndividualPrice { get; set; }
    }

    public class OrderCreationResponse
    {
        public Guid OrderId { get; set; } = Guid.NewGuid();

        public string Status { get; set; } = "Processing";
    }

    public static class CreateOrder
    {
        [FunctionName("create-order")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "orders")] OrderItem[] orderItems)
        {
            return orderItems?.Any() is true
                ? (IActionResult) new OkObjectResult(new OrderCreationResponse())
                : new BadRequestResult();
        }
    }
}
