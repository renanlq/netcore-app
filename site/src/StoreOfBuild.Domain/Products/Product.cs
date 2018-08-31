namespace StoreOfBuild.Domain.Products
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Category Category { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }

        public Product(string name, Category category, decimal price, int stock)
        {
            Validate(name, category, price, stock);
            SetProduct(name, category, price, stock);
        }

        public void Update(string name, Category category, decimal price, int stock)
        {
            Validate(name, category, price, stock);
            SetProduct(name, category, price, stock);
        }

        private void SetProduct(string name, Category category, decimal price, int stock)
        {
            Name = name;
            Category = category;
            Price = price;
            Stock = stock;
        }

        private static void Validate(string name, Category category, decimal price, int stock)
        {
            DomainException.When(string.IsNullOrEmpty(name), "Nome é obrigatório.");
            DomainException.When(category == null, "Categoria é obrigatória.");
            DomainException.When(price <= 0, "Preço é obrigatório.");
            DomainException.When(stock < 0, "Stoque é obrigatório.");
        }
    }
}