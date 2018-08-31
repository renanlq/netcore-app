using StoreOfBuild.Domain.Products;
using StoreOfBuild.Domain.VOs;

namespace StoreOfBuild.Domain
{
    public class CategoryStorer
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryStorer(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void  Store(CategoryVO categoryVO)
        {
            var category = _categoryRepository.GetById(categoryVO.Id);
            if (category == null)
            {
                category = new Category(category.Name);
                _categoryRepository.Save(category);
            }
            else
            {
                category.Update(category.Name);
            }
        }
    }
}