using ArdesStorageModule.Models;
using ArdesStorageModule.Repository;
using ArdesStorageModule.Services;
using ArdesStorageModule.Reports;

IProductRepository productRepository = new ProductRepository();
IProductService productService = new ProductService(productRepository);
ReportService reportService = new ReportService(productService);

Console.WriteLine("=== Storage Module Test ===");

// Get all
Console.WriteLine("\n1. All products:");
foreach (var product in productService.GetAll())
{
    Console.WriteLine($"{product.Id} | {product.Name} | Qty: {product.Quantity} | Price: {product.Price} | Supplier: {product.Supplier}");
}

// Add
var newProduct = new Product
{
    Name = "Intel Core i7-14700K",
    Quantity = 10,
    Price = 699.99m,
    Supplier = "Intel"
};

productService.Add(newProduct);
Console.WriteLine("\n2. Product added successfully.");

Console.WriteLine("\n1. All products:");
foreach (var product in productService.GetAll())
{
    Console.WriteLine($"{product.Id} | {product.Name} | Qty: {product.Quantity} | Price: {product.Price} | Supplier: {product.Supplier}");
}

// GetById
var foundById = productService.GetById(newProduct.Id);
Console.WriteLine($"\n3. Found by Id: {foundById?.Name}");

// Search by name
var searchedProducts = productService.SearchByName("intel");
Console.WriteLine("\n4. Search by name:");
foreach (var product in searchedProducts)
{
    Console.WriteLine($"{product.Name} | Qty: {product.Quantity}");
}

// Filter by quantity
var filteredProducts = productService.FilterByQuantity(10);
Console.WriteLine("\n5. Products with quantity >= 10:");
foreach (var product in filteredProducts)
{
    Console.WriteLine($"{product.Name} | Qty: {product.Quantity}");
}

// Update
newProduct.Name = "Intel Core i7-14700K Updated";
newProduct.Quantity = 15;
newProduct.Price = 729.99m;
newProduct.Supplier = "Intel Corporation";

bool updated = productService.Update(newProduct.Id, newProduct);
Console.WriteLine($"\n6. Product updated: {updated}");

// Reports
Console.WriteLine("\n7. Reports:");
Console.WriteLine($"Total quantity: {reportService.GetTotalQuantity()}");
Console.WriteLine($"Total stock value: {reportService.GetTotalPrice()}");
Console.WriteLine($"Low stock count: {reportService.GetLowStock(5)}");
Console.WriteLine($"All articles count: {reportService.GetAllArticles()}");

// Delete
bool deleted = productService.Delete(newProduct.Id);
Console.WriteLine($"\n8. Product deleted: {deleted}");

Console.WriteLine("\n=== Test Finished ===");
