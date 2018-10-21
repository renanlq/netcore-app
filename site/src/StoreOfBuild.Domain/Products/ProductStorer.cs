using StoreOfBuild.Domain.Products;
using StoreOfBuild.Domain.VOs;

namespace StoreOfBuild.Domain
{
    public class ProductStorer
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;
        
        public ProductStorer(IRepository<Product> productRepository, IRepository<Category> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public void Store(int id, string name, decimal price, int stock, int categoryId)
        {
            var category = _categoryRepository.GetById(categoryId);
            DomainException.When(category == null, "Categoria inválida.");

            var product = _productRepository.GetById(id);
            if (product == null)
            {
                product = new Product(name, category, price, stock);
                _productRepository.Save(product);
            }
            else
            {
                product.Update(name, category, price, stock);
            }
        }
    }
}