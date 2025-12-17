using SellGold.Contracts.DTOs.Stock.Requests;
using SellGold.PageModels.Stock;

namespace SellGold.Mappings.Stock
{
    public static class StockMapping
    {
        public static CreateStockRequest ToRequest(StockPageModel model) =>
            new CreateStockRequest
            {
                StockProductId = Guid.NewGuid(),         // obrigatório
                ProductId = model.ProductId,             // obrigatório
                CurrentQuantity = model.CurrentQuantity, // obrigatório
                DateMovement = model.DateMovement,       // obrigatório
                AmountMovement = model.AmountMovement,   // obrigatório
                MovementType = model.MovementType,       // obrigatório

                // opcionais
                Observation = model.Observation,
                StockLocationName = model.StockLocationName,
                Street = model.Street,
                Number = model.Number,
                Complement = model.Complement,
                District = model.District,
                City = model.City,
                State = model.State,
                ZipCode = model.ZipCode,
                Country = model.Country
            };
    }
}
