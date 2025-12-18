namespace SellGold.Customers.Application.Commons
{
    public sealed class NotFoundException : ExceptionBase
    {
        public NotFoundException(string entity, object key)
        : base($"{entity} com identificador '{key}' não foi encontrado.")
        {
        }
    }
}
