using ArdesStorageModule.Repository;
using ArdesStorageModule.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdesStorageModule.Reports
{
    public class ReportService
    {
        private readonly IProductService _productService;

        public ReportService(IProductService productService)
        {
            this._productService = productService;
        }

        public decimal GetTotalQuantity()
        {
            return _productService.GetAll().Sum(x => x.Quantity);
        }

        public decimal GetTotalPrice()
        {
            return _productService.GetAll().Sum(x => x.Price * x.Quantity);
        }

        public int GetLowStock(int limit)
        {
            return _productService.GetAll().Count(x => x.Quantity <= limit);
        }

        public int GetAllArticles()
        {
            return _productService.GetAll().Count;
        }
    }
}
