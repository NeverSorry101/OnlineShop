using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using OnlineShop.API;
using OnlineShop.Classi;

namespace OnlineShop
{
    internal class Querys
    {
        private static List<string> RequestedProps = new List<string>()
            {
                "id",
                "title",
                "category",
                "price",
                "stock",
                "brand"
            };
        private const int offset = -40;

        public static void PrintHeader()
        {
            foreach (var i in RequestedProps) Console.Write($"{i.ToUpper(),offset}");
            Console.Write("\n");
        }
        public static void Print(List<Product> dati)
        {
            PrintHeader();
            foreach (var i in dati)
            {
                GetInfo(i);
                Console.Write("\n");

            }
        }
        public static List<string> UploadCategories(Root dati)
        {
            var category = dati.products.GroupBy(c => c.category).ToList();
            List<string> result = new List<string>();
            foreach (var item in category)
            {
                result.Add(item.Key);
            }
            return result;
        }
        public static void GetInfo(Product product)
        {

            foreach (PropertyInfo property in product.GetType().GetProperties())
            {
                if (RequestedProps.Contains(property.Name))
                {

                    Console.Write($"{property.GetValue(product),offset}");
                }

            }


        }
        public static List<Product> ShowPerCategory(List<Product> dati, Enumeratori.Categorie categoria)
        {
            return dati.Where(c => c.category == categoria.ToString()).ToList();

        }
        public static List<Product> SortByPrice(List<Product> dati, string search)
        {
            return dati.OrderBy(d => d.price).ThenBy(c => c.id).ToList();
        }
        public static double? AvgPricePerCategory(List<Product> dati, Enumeratori.Categorie categorie)
        {
            return dati.Where(c => c.category == categorie.ToString()).Average(n => n.price);
        }
        public static List<Product> DiscountedProducts(List<Product> dati, double? percentage)
        {
            return dati.Where(n => n.discountPercentage > percentage).ToList();
        }
        public static int? ItemsPerBrand(List<Product> dati, Enumeratori.Brands brand)
        {
            return dati.Where(x => x.brand == brand.ToString()).ToList().Count;
        }
        public static List<Review> NegativeReviews(List<Product> dati, int? rating)
        {
            return dati.SelectMany(s => s.reviews).ToList().Where(h => h.rating <= rating).ToList();
        }
        public static List<Product> SearchWithTags(List<Product> dati, string tag)
        {
            return dati.Where(x => x.tags.Contains(tag)).ToList();
        }
        public static List<Product> GroupByCategory(List<Product> dati)
        {
            return dati.GroupBy(x=>x.category).OrderBy(group => group.Key).SelectMany(group=>group).ToList();
        }
        public static List<Review> OrderReviewsByDate(List<Product> dati)
        {
            return dati.SelectMany(x=>x.reviews).OrderByDescending(c=>c.date).ToList();
        }
        public static Product? BestProduct(List<Product> dati, Enumeratori.Categorie categoria) { 
        return dati.OrderByDescending(x=>x.reviews.Average(n=>n.rating)).Where(c=>c.category == categoria.ToString()).FirstOrDefault();
        }
    }
}
