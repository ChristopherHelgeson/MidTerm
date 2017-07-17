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
            bool sale = true;
            bool again = true;

            while (sale == true)
            {
                Console.WriteLine("Welome to the Shopping Center, below is our products please select a item");
                P.outputProductList();

                while (again == true)
                {
                    addProduct();
                }
            }
        }

        public Boolean newSale()
        {
            Boolean sale;
            Console.WriteLine("Would you like to start a new sale? Y/N");
            String answer = Console.ReadLine();

            if ((answer == "Y") || (answer == "y"))
            {
                sale = true;
                P.printProductList();
            }
            else if ((answer == "N") || (answer == "n"))
            {
                
                Console.WriteLine("Ok, thank you see you next shift!");
                sale = false;
            }
            else
            {
                Console.WriteLine("I'm sorry I don't understand. Let's try again");
                sale = newSale();
            }
            return sale;
        }

        public Boolean anotherProduct()
        {
            Boolean again;

            Console.WriteLine("Would you like to continue shopping? Y/N");
            String answer = Console.ReadLine();

            if ((answer == "Y") || (answer == "y"))
            {
                Console.Clear();
                P.printProductList();
                again = true;
            }
            else if ((answer == "N") || (answer == "n"))
            {
                again = false;
                Payment();
            }
            else
            {
                Console.WriteLine("I'm sorry I don't understand. Let's try again");
                again = anotherProduct();
            }
            return again;
        }

        public void addProduct()
        {
            O.addToCustOrder();
            O.outputCustOrder();
            anotherProduct();
        }

        public void Payment()
        {
            
            O.getPayment();
            newSale();
            
        }
    }
}
