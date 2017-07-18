using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Product P = new Product(" ", " ", " ", 0.00);
            bool sale = true;
            P.buildProduct();
            while (sale == true)
            {
                POSapp pos = new POSapp();
                sale = newSale();
            }
            
        }
        
        public static Boolean newSale()
        {
            bool sale;
            Console.Write("\nWould you like to start a new sale? (Y/N): ");
            string answer = Console.ReadLine();

            if ((answer == "Y") || (answer == "y"))
            {
                sale = true;
                Console.Clear();
                //O = null;

            }
            else if ((answer == "N") || (answer == "n"))
            {
                Console.WriteLine("Ok, thank you see you next shift!");
                sale = false;
            }
            else
            {
                Console.WriteLine("I'm sorry I don't understand. Let's try again.");
                sale = newSale();
            }
            return sale;
        }
    }
}

