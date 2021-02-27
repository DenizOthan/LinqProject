using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Category> categories = new List<Category>
            {
                new Category{CategoryId=1, CategoryName="bilgisayar"},
                new Category{CategoryId=2, CategoryName="telefon"},
            };
            List<Product> products = new List<Product>
            {
                new Product{ProductId=1 , CategoryId=1, ProductName="acer laptop", QuantityPerUnit="32GB RAM", UnitPrice=10000, UnitInStock=5 },
                new Product{ProductId=2 , CategoryId=1, ProductName="asus laptop", QuantityPerUnit="16GB RAM", UnitPrice=18000, UnitInStock=3 },
                new Product{ProductId=3 , CategoryId=1, ProductName="hp laptop", QuantityPerUnit="8GB RAM", UnitPrice=6/18000, UnitInStock=2 },
                new Product{ProductId=4 , CategoryId=2, ProductName="samsung", QuantityPerUnit="4GB RAM", UnitPrice=5000, UnitInStock=15 },
                new Product{ProductId=5 , CategoryId=2, ProductName="apple", QuantityPerUnit="4GB RAM", UnitPrice=8000, UnitInStock=0},
            };
            //Test(products);

            //GetProducts(products);

            // AnyTest(products);
            //FindTest(products);


            //FindAllTest(products);
            //AscDescTest(products);

            // ClassicLinqTest(products);

            var result = from p in products
                         join c in categories
                         on p.CategoryId equals c.CategoryId
                      

                         select new ProductDto {PrductId=p.ProductId, CategoryName=c.CategoryName, ProductName=p.ProductName, UnitPrice=p.UnitPrice };
            foreach (var productDto in result)
            {
                Console.WriteLine(productDto.ProductName +" " + productDto.CategoryName);
            }

        }

        private static void ClassicLinqTest(List<Product> products)
        {
            var result = from p in products
                         where p.UnitPrice > 6000
                         orderby p.UnitPrice descending, p.ProductName ascending
                         select new ProductDto { PrductId = p.ProductId, ProductName = p.ProductName, UnitPrice = p.UnitPrice };
            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void AscDescTest(List<Product> products)
        {   //Single Line Quaery
            var result = products.Where(p => p.ProductName.Contains("top")).OrderByDescending(p => p.UnitPrice).ThenByDescending(p => p.ProductName);
            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void FindAllTest(List<Product> products)
        {
            var result = products.FindAll(p => p.ProductName.Contains("top"));
            Console.WriteLine(result);
        }

        private static void FindTest(List<Product> products)
        {
            var result = products.Find(p => p.ProductId == 3);
            Console.WriteLine(result.ProductName);
        }

        private static void AnyTest(List<Product> products)
        {
            var result = products.Any(p => p.ProductName == "acer laptop");
            Console.WriteLine(result);
        }

        private static void Test(List<Product> products)
        {
            Console.WriteLine("Algoritmik-----------------");
            foreach (var product in products)
            {
                if (product.UnitPrice > 5000 && product.UnitInStock > 3)
                {
                    Console.WriteLine(product.ProductName);
                }

            }

            Console.WriteLine("Linq---------------------");
            var result = products.Where(p => p.UnitPrice > 5000 && p.UnitInStock > 3);
            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        static List<Product> GetProducts(List<Product> products)
        {
            List<Product> filtereProducts = new List<Product>();
            foreach (var product in products)
            {
                if (product.UnitPrice > 5000 && product.UnitInStock > 3)
                {
                    filtereProducts.Add(product);
                }

            }
            return filtereProducts;
        }

        static List<Product> GetProductsLinq(List<Product> products)
        {
            return (List<Product>)products.Where(p => p.UnitPrice > 5000 && p.UnitInStock > 3).ToList();
        }
        
        


    }
    class ProductDto
    {
        public int PrductId { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
    }
    class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }
    }
    class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
