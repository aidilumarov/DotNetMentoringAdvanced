namespace CartService.Application.MessageHandlers.Messages
{
    public class ItemUpdatedMessage
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
