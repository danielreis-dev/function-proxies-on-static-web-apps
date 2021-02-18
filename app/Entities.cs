namespace MyStore.App
{
    public record CatalogItem(int Id, string Name, string ImageUrl, decimal Price);

    public record OrderItem(int Id, int Count, decimal IndividualPrice);
}
