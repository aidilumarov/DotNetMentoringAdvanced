namespace CartService.Domain
{
    public class Cart
    {
        public string Id { get; set; }
        public List<Item> Items { get; set; }
    }
}