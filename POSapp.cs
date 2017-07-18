using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale
{
    class POSapp
    {
        Product P = new Product(" ", " ", " ", 0.00);
        Order O = new Order(0, 0);
        

        public POSapp()
        {
            //bool sale = true;
            bool again = true;

           
                Console.WriteLine("Welcome to the Shopping Center. Below are our products. Please select a item.\n");
                P.printProductList();

                while (again == true)
                {
                    addProduct();
                    again = anotherProduct();
                }
            
        }

        public bool anotherProduct()
        {
            bool again;

            Console.Write("\nWould you like to continue shopping? (Y/N): ");
            string answer = Console.ReadLine();

            if ((answer == "Y") || (answer == "y"))
            {
                Console.Clear();
                P.printProductList();
                again = true;
            }
            else if ((answer == "N") || (answer == "n"))
            {
                again = false;
                Console.Clear();
                Payment();
            }
            else
            {
                Console.WriteLine("I'm sorry I don't understand. Let's try again.");
                again = anotherProduct();
            }
            return again;
        }

        public void addProduct()
        {
            O.addToCustOrder();
            Console.Clear();
            Console.WriteLine("Your order so far . . .\n");
            O.outputCustOrder();
            
        }

        public void Payment()
        {
            O.getPayment();
            
        }
    }
}
