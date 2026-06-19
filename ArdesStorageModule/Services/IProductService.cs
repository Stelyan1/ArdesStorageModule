using ArdesStorageModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdesStorageModule.Services
{
    public interface IProductService
    {
        void Add(Product product);

        bool Update(Guid Id, Product product);

        bool Delete(Guid Id);

        Product? GetById(Guid Id);

        List<Product> GetAll();

        List<Product> SearchByName(string name);

        List<Product> FilterByQuantity(int minQuantity);
    }
}
