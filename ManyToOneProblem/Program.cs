using ManyToOneProblem.Entidades;
using ManyToOneProblem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManyToOneProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Recreating database...");
            NHibernateHelper.CreateDb();

            Console.WriteLine("Seeding Database");

            var categories = new List<Category>();
            var products = new List<Product>();
            for (int i = 0; i < 10; i++)
            {
                var cat = new Category { Description = "Category " + (i + 1) };
                categories.Add(cat);
                using var session = NHibernateHelper.OpenSession();
                using var transaction = session.BeginTransaction();
                session.Save(cat);
                transaction.Commit();
            }

            foreach (var category in categories)
            {
                var product = new Product { Category = category, Description = "Product from category " + category.Id, Price = 1 };
                var productTax = new ProductTax { Tax1 = 1.5, Tax2 = 2.5, Tax3 = 3.56 };
                products.Add(product);
                using var session = NHibernateHelper.OpenSession();
                using var transaction = session.BeginTransaction();
                productTax.Product = product;
                session.Save(productTax);
                transaction.Commit();
            }

            Console.WriteLine("====================== Starting query ======================");
            using var sessionQuery = NHibernateHelper.OpenSession();
            var queryProducts = sessionQuery.Query<ProductTax>().ToList(); // query all
            Console.WriteLine("====================== END of query ======================");

            foreach (var p in queryProducts)
            {
                Console.WriteLine("{0} - {1}", p.Id, p.Product.Description);
            }
            Console.WriteLine("Finishing!");
        }
    }
}
