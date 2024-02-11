using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DataLayer.Contexts;
using DataLayer.Repositories;
using DataLayer.Services;

namespace EFC_Inlamning
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {

                services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\adisa\source\repos\EFC_Inlamning\DataLayer\Data\Local_Database.mdf;Integrated Security=True;Connect Timeout=30"));

                services.AddScoped<AddressRepository>();
                services.AddScoped<CategoryRepository>();
                services.AddScoped<RoleRepository>();
                services.AddScoped<ProductRepository>();
                services.AddScoped<CustomerRepository>();

                services.AddScoped<AddressService>();
                services.AddScoped<CategoryService>();
                services.AddScoped<RoleService>();
                services.AddScoped<ProductService>();
                services.AddScoped<CustomerService>();

                services.AddSingleton<ConsoleUI>();

            }).Build();


            var consoleUI = builder.Services.GetRequiredService<ConsoleUI>();
            
            consoleUI.CreateCustomer_UI();
            consoleUI.CreateProduct_UI();

        }
    }
}
