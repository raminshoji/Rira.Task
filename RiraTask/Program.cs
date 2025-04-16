using Application.Services.IService;
using Infrastructure.Repositories.IRepository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Application.Services.Service;
using Infrastructure.Repositories.Repository;


namespace RiraTask
{
    public class Program
    {      
        static void Main(string[] args)
        {
            using IHost host = RegisterServices(args);
            var service = host.Services.GetRequiredService<IProductService>();

            Console.WriteLine(" Category1 Products ");
            foreach (var product in service.GetAllCategory1Products())
            {
                Console.WriteLine($"{product.Name} - {product.Price}");
            }

            Console.WriteLine("\n Most Expensive Product ");
            var expensive = service.GetMostExpensiveProduct();
            Console.WriteLine($"{expensive.Name} - {expensive.Price}");

            Console.WriteLine("\n Total Price ");
            Console.WriteLine(service.GetTotalPrice());

            Console.WriteLine("\n Grouped By Category ");
            foreach (var group in service.GroupByCategory())
            {
                Console.WriteLine($"\n{group.Key}:");
                foreach (var product in group.Value)
                {
                    Console.WriteLine($"{product.Name} - {product.Price}");
                }
            }

            Console.WriteLine("\n Average Price ");
            Console.WriteLine(service.GetAveragePrice());
        }

        private static IHost RegisterServices(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
            {
                services.AddScoped<IProductRepository, ProductRepository>();
                services.AddScoped<IProductService, ProductService>();
            })
            .Build();
        }
    }
}

