namespace SellGold.Products.Application.Interfaces.Messaging
{
    public interface IProductsProducerService
    {
        Task ProductsProducerAsync(string message);

    }
}
