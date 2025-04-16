using Application.Services.IService;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Product> GetAllCategory1Products()
        {
            return _repository.GetAllProducts().Where(p => p.Category == Categories.Category1);
        }

        public Product GetMostExpensiveProduct()
        {
            return _repository.GetAllProducts().OrderByDescending(p => p.Price).FirstOrDefault();
        }

        public decimal GetTotalPrice()
        {
            return _repository.GetAllProducts().Sum(p => p.Price);
        }

        public Dictionary<Categories, List<Product>> GroupByCategory()
        {
            return _repository.GetAllProducts()
                .GroupBy(p => p.Category)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        public decimal GetAveragePrice()
        {
            return _repository.GetAllProducts().Average(p => p.Price);
        }
    }
}
