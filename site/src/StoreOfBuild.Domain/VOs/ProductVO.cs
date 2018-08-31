namespace StoreOfBuild.Domain.VOs
{
    public class ProductVO
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int CategoryId { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
    }
}