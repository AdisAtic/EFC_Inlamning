using DataLayer.Services;

namespace EFC_Inlamning;

public class ConsoleUI
{
    private readonly ProductService _productService;
    private readonly CustomerService _customerService;

    public ConsoleUI(ProductService productService, CustomerService customerService)
    {
        _productService = productService;
        _customerService = customerService;
    }

    public void CreateProduct_UI()
    {
        Console.Clear();
        Console.WriteLine("---- CREATE PRODUCT ----");

        Console.Write("Product Title: ");
        var title = Console.ReadLine()!;

        Console.Write("Product Price: ");
        var price = decimal.Parse(Console.ReadLine()!);

        Console.Write("Product Category: ");
        var categoryName = Console.ReadLine()!;

        var result = _productService.CreateProduct(title, price, categoryName);
        if (result != null)
        {
            Console.Clear();
            Console.WriteLine("Product was created.");
            Console.ReadKey();
        }
    }

    public void GetProducts_UI()
    {
        Console.Clear();

        var products = _productService.GetProducts();
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Title} - {product.Category.CategoryName} ({product.Price} SEK)");
        }

        Console.ReadKey();

    }


    public void UpdateProduct_UI()
    {
        Console.Clear();
        Console.Write("Enter Product Id:");
        var id  = int.Parse(Console.ReadLine()!);

        var product = _productService.GetProductById(id);
        if (product != null) 
        {
            Console.WriteLine($"{product.Title} - {product.Category.CategoryName} ({product.Price} SEK)");
            Console.WriteLine();

            Console.Write("New Prodcut Title");
            product.Title = Console.ReadLine()!;

            var newProduct = _productService.UpdateProduct(product);
            Console.WriteLine($"{newProduct.Title} - {newProduct.Category.CategoryName} ({newProduct.Price} SEK)");
        }

        else 
            Console.WriteLine("No product Found");

        Console.ReadKey();
        
    }

    public void CreateCustomer_UI()
    {
        Console.Clear();
        Console.WriteLine("---- CREATE CUSTOMER ----");

        Console.Write("Customer First Name: ");
        var firstName = Console.ReadLine()!;

        Console.Write("Customer Last Name: ");
        var lastName = Console.ReadLine()!;

        Console.Write("Customer Email: ");
        var email = Console.ReadLine()!;

        Console.Write("Customer Role Name: ");
        var roleName = Console.ReadLine()!;
       
        Console.Write("Customer Street Name: ");
        var streetName = Console.ReadLine()!;

        Console.Write("Customer Postal Code: ");
        var postalCode = Console.ReadLine()!;

        Console.Write("Customer City: ");
        var city = Console.ReadLine()!;

        var result = _customerService.CreateCustomer(firstName, lastName, email, roleName, streetName, postalCode, city);
        if (result != null)
        {
            Console.Clear();
            Console.WriteLine("customer was created.");
            Console.ReadKey();
        }
    }
}
