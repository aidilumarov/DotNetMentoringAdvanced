namespace CartService.Domain
{
    public class Cart
    {
        public Guid Id { get; set; }
        public List<Item> Items { get; set; }
    }
}