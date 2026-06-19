using ArdesStorageModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdesStorageModule.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        void SaveAll(List<Product> products);
    }
}
