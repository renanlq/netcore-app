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

        public void Store(ProductVO productVO)
        {
            var category = _categoryRepository.GetById(productVO.CategoryId);
            DomainException.When(category == null, "Categoria inválida.");

            var product = _productRepository.GetById(productVO.Id);
            if (product == null)
            {
                product = new Product(productVO.Name, category, productVO.Price, productVO.Stock);
                _productRepository.Save(product);
            }
            else
            {
                product.Update(productVO.Name, category, productVO.Price, productVO.Stock);
            }
        }
    }
}