using DataLayer.Entities;
using DataLayer.Repositories;

namespace DataLayer.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;
        private readonly CategoryService _categoryService;

        public ProductService(ProductRepository productRepository, CategoryService categoryService)
        {
            _productRepository = productRepository;
            _categoryService = categoryService;
        }



        public ProductEntity CreateProduct(string title, decimal price, string categoryName)
        {
            var categoryModel = _categoryService.CreateCategory(categoryName);

            var productModel = new ProductEntity
            {
                Title = title,
                Price = price,
                CategoryId = categoryModel.Id,
            };

            productModel = _productRepository.Create(productModel);
            return productModel;
        }

        public ProductEntity GetProductById(int id)
        {
            var ProductModel = _productRepository.Get(x => x.Id == id);
            return ProductModel;
        }

        public IEnumerable<ProductEntity> GetProducts()
        {
            var products = _productRepository.GetAll();
            return products;
        }

        public ProductEntity UpdateProduct(ProductEntity productModel)
        {
            var updatedProductModel = _productRepository.Update(x => x.Id == productModel.Id, productModel);
            return updatedProductModel;
        }

        public void DeleteProduct(int id)
        {
            _productRepository.Delete(x => x.Id == id);
        }
    }
}
