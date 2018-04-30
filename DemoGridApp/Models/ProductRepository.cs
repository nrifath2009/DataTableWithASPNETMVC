using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoGridApp.Models
{
    public class ProductRepository:IPagination<Product>
    {
        public static List<Product> GetAllProducts()
        {
            string[] rows = new[] {"IPhone","Smart TV","Laptop","Echo Plus","Android Phone","Digital Piano","Tablet"};
            List<Product> products = new List<Product>();
            for (int i = 1; i < 70; i++)
            {
                Product product = new Product();
                product.Id = i;
                product.ProductName = rows[i / 10]+" - "+i;
                product.Price = i * 20;
                product.Category = "Digital Product";
                products.Add(product);
            }
            return products;
        }

        public IQueryable<Product> GetPaginated(string filter, int initialPage, int pageSize, out int totalRecords, out int recordsFiltered)
        {
            var data = GetAllProducts().AsQueryable();
            totalRecords = data.Count();

            if (!string.IsNullOrEmpty(filter))
            {
                data = data.Where(c => c.ProductName.ToUpper().Contains(filter.ToUpper()));
            }
            recordsFiltered = data.Count();
            data = data
                .OrderBy(c => c.Id)
                .Skip((initialPage * pageSize))
                .Take(pageSize);
            return data;
        }
    }
}