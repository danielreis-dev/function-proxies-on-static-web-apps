using Refit;
using System.Threading.Tasks;

namespace MyStore.App
{
    public interface IBackendClient
    {
        [Get("/api/catalog")]
        Task<CatalogItem[]> GetCatalogAsync([Query] int index);

        [Post("/api/orders")]
        Task<OrderCreationResponse> CreateOrderAsync(OrderItem[] orderItems);
    }

    public record OrderCreationResponse(string OrderId, string Status);
}
