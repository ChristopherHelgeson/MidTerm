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
            Product a = new Product("Apple", "Produce", "Fruit", 1.00);
            products.Add(a);
            Product b = new Product("Banana", "Produce", "Fruit", 0.50);
            products.Add(b);
            Product c = new Product("Cherry", "Produce", "Fruit", 1.50);
            products.Add(c);
            Product d = new Product("Celery", "Produce", "Vegetable", 1.75);
            products.Add(d);
            Product e = new Product("Oranges", "Produce", "Fruit", 3.50);
            products.Add(e);
            Product f = new Product("Corn", "Produce", "Vegetable", .99);
            products.Add(f);
            Product g = new Product("Advil", "Pharmacy", "Medicine", 7.00);
            products.Add(g);
            Product h = new Product("NyQuil", "Pharmacy", "Medicine", 9.50);
            products.Add(h);
            Product j = new Product("Beer", "Beverage", "Alcohol", 9.75);
            products.Add(j);
            Product k = new Product("Water", "Beverage", "Non-Alcohol", 1.00);
            products.Add(k);
            Product l = new Product("Pizza", "Food", "Frozen", 8.50);
            products.Add(l);
            Product m = new Product("Gr. Beef", "Food", "Meat", 7.50);
            products.Add(m);

            return products;
        }

        public void printProductList()
        {
            printProduct(products);
        }

        public void printProduct(List<Product> products)
        {
            //Console.WriteLine("#\tNAME\t\tCATEGORY\tDESC.\t\tPRICE\n");
            Console.WriteLine("{0,3}{1,-3}{2,-15}{3,-15}{4,-12}{5,11}","#","","NAME","CATEGORY","DESCRIPTION","PRICE\n");

            for (int i = 0; i < products.Count(); i++)
            {
                string currentItem = products[i].getName();
                string currentCategory = products[i].getCategory();
                string currentDescription = products[i].getDescription();
                double currentPrice = products[i].getPrice();
                //Console.WriteLine(i + ")\t" + currentItem + "\t\t" + currentCategory + "\t\t" + currentDescription + "\t\t$ " + currentPrice.ToString("0.00"));
                Console.WriteLine("{0,3}{1,-3}{2,-15}{3,-15}{4,-12}{5,10}", i,")", currentItem, currentCategory, currentDescription, "$"+ currentPrice.ToString("0.00"));
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
