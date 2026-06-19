using ArdesStorageModule.Models;
using ArdesStorageModule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdesStorageModule.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public void Add(Product product)
        {
            var products = _productRepository.GetAll();

            products.Add(product);

            _productRepository.SaveAll(products);
        }

        public bool Delete(Guid Id)
        {
            var products = _productRepository.GetAll();

            var ForDelete = products.FirstOrDefault(x => x.Id == Id);

            if (ForDelete == null) 
            {
                return false;
            }
            
            products.Remove(ForDelete);

            _productRepository.SaveAll(products);

            return true;
        }

        public List<Product> FilterByQuantity(int minQuantity)
        {
            var product = _productRepository.GetAll();

            return product.Where(x => x.Quantity >= minQuantity).ToList();
        }

        public List<Product> GetAll()
        {
            var products = _productRepository.GetAll();

            return products.ToList();
        }

        public Product? GetById(Guid Id)
        {
            var product = _productRepository.GetAll();

            return product.FirstOrDefault(x => x.Id == Id);
        }

        public List<Product> SearchByName(string name)
        {
            var products = _productRepository.GetAll();

            var product = products.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();

            return product;
        }

        public bool Update(Guid Id, Product product)
        {
            var products = _productRepository.GetAll();

            var productEdit = products.FirstOrDefault(x => x.Id == Id);

            if (productEdit == null) 
            {
                return false;
            }

            productEdit.Name = product.Name;
            productEdit.Supplier = product.Supplier;
            productEdit.Price = product.Price;
            productEdit.Quantity = product.Quantity;
            productEdit.UpdatedOn = DateTime.UtcNow;

            _productRepository.SaveAll(products);

            return true;
        }
    }
}
