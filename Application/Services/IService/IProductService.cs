using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.IService
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllCategory1Products();
        Product GetMostExpensiveProduct();
        decimal GetTotalPrice();
        Dictionary<Categories, List<Product>> GroupByCategory();
        decimal GetAveragePrice();
    }
}
