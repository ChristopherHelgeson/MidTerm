using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PointOfSale
{
    class Product
    {
        private string name;
        private string category;
        private string description;
        private double price;
        

        public static List<Product> products = new List<Product>();

        public Product(string name, string category, string description, double price)
        {
            this.name = name;
            this.category = category;
            this.description = description;
            this.price = price;
        }

        public void outputProductList()
        {
            buildProduct();
            printProduct(products);
        }

        public List<Product> buildProduct()
        {
            Product a = new Product("Batman", "Produce", "Fruit", 100.00);
            products.Add(a);
            Product b = new Product("Banana", "Produce", "Fruit", 0.50);
            products.Add(b);
            Product c = new Product("Cherry", "Produce", "Fruit", 1.50);
            products.Add(c);
            Product d = new Product("Celery", "Produce", "Fruit", 1.75);
            products.Add(d);
            Product e = new Product("Oranges", "Produce", "Fruit", 3.50);
            products.Add(e);
            Product f = new Product("Corn", "Produce", "Veget", .99);
            products.Add(f);
            Product g = new Product("Advil", "Pharma", "Medic", 7.00);
            products.Add(g);
            Product h = new Product("NyQuil", "Pharma", "Medic", 9.50);
            products.Add(h);
            Product j = new Product("Beer", "Drink", "Alcohol", 9.75);
            products.Add(j);
            Product k = new Product("Water", "Drink", "Bever", 1.00);
            products.Add(k);
            Product l = new Product("Pizza", "Food", "Frozen", 8.50);
            products.Add(l);
            Product m = new Product("GR Beef", "Food", "Meat", 7.50);
            products.Add(m);

            return products;
        }

        public void printProductList()
        {
            printProduct(products);
        }

        public void printProduct(List<Product> products)
        {
            Console.WriteLine("#\tNAME\t\tCATEGORY\tDESC.\t\tPRICE\n");

            for (int i = 0; i < products.Count(); i++)
            {
                string currentItem = products[i].getName();
                string currentCategory = products[i].getCategory();
                string currentDescription = products[i].getDescription();
                double currentPrice = products[i].getPrice();
                Console.WriteLine(i + ")\t" + currentItem + "\t\t" + currentCategory + "\t\t" + currentDescription + "\t\t$ " + currentPrice.ToString("0.00"));
            }
            Console.WriteLine();
        }

        public string getName()
        {
            return name;
        }

        public string getCategory()
        {
            return category;
        }

        public string getDescription()
        {
            return description;
        }

        public double getPrice()
        {
            return price;
        }


        
    }
}
