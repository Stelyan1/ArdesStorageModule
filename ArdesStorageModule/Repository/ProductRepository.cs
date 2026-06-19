using ArdesStorageModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ArdesStorageModule.Repository
{
    public class ProductRepository : IProductRepository
    {
        private const string FilePath = "C:\\Users\\Stelyan\\Desktop\\BI Soft Tasks\\II.Разработка\\ArdesStorageModule\\ArdesStorageModule\\Data\\products.json";

        public List<Product> GetAll()
        {
            if (!File.Exists(FilePath)) 
            {
                return new List<Product>();
            }

            var json = File.ReadAllText(FilePath);

            if (string.IsNullOrWhiteSpace(json)) 
            {
                return new List<Product>();
            }

            return JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
        }

        public void SaveAll(List<Product> products)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            var json = JsonSerializer.Serialize(products, options);

            File.WriteAllText(FilePath, json);
        }
    }
}
