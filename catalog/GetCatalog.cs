using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace MyStore.Catalog
{
    public class CatalogItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }
    }

    public static class GetCatalog
    {
        [FunctionName("get-catalog")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "catalog")] HttpRequest req)
        {
            if (!int.TryParse(req.Query["index"].FirstOrDefault(), out var index) || index < 0)
            {
                index = 0;
            }

            var catalogItems = Enumerable.Range(index * 10, 10).Select(id => new CatalogItem
            {
                Id = id,
                Price = 0.99M,
                Name = $"Catalog Item {id}",
                ImageUrl = $"https://picsum.photos/id/{id}/200/300"
            });

            return new OkObjectResult(catalogItems);
        }
    }
}
