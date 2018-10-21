using System.ComponentModel.DataAnnotations;

namespace StoreOfBuild.Web.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; private set; }
        [Required]
        public string Name { get; private set; }
        public int CategoryId { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
    }
}