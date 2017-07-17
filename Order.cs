using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale
{
    class Order
    {
        private int quantity;
        private int index;
        private double orderSubtotal = 0;
        

        public static List<Order> currentOrder = new List<Order>();

        public Order(int index, int quantity)
        {
            this.index = index;
            this.quantity = quantity;
        }

        public void addToCustOrder()
        {
            int custChoice = getCustChoice();
            int choiceAmt = getChoiceAmt();
            Order a = new Order(custChoice, choiceAmt);
            currentOrder.Add(a);
        }

        public void outputCustOrder()
        {
            printCustOrder(currentOrder, Product.products);
        }

        public void printCustOrder(List<Order> order, List<Product> products)
        {
            Console.WriteLine("\nNAME\t\tQTY\t$/EA.\tSUBTOTAL\n");
            for (int i = 0; i < order.Count(); i++)
            {
                int currentIndex = order[i].getIndex();
                string currentName = products[currentIndex].getName();
                int currentQty = order[i].getQty();
                double currentPrice = products[currentIndex].getPrice();
                double itemSubtotal = currentPrice * currentQty;
                Console.WriteLine($"{currentName}\t\t{currentQty}\t{currentPrice.ToString("0.00")}\t{itemSubtotal.ToString("0.00")}");
                orderSubtotal = itemSubtotal;
                

                Console.WriteLine("\n\t\tPreTax Total:\t" + orderSubtotal.ToString("0.00"));
                Console.WriteLine("\t\tSales Tax (6%): " + (orderSubtotal * .06).ToString("0.00"));
                Console.WriteLine("\t\tGrand Total: \t" + (orderSubtotal * 1.06).ToString("0.00"));
            }
        }

        public int getCustChoice()
        {
            Console.Write("\nWhich item would you like to purchase?: ");
            int custChoice = int.Parse(Console.ReadLine());
            return custChoice;
        }

        public int getChoiceAmt()
        {
            Console.Write("\nHow many would you like?: ");
            int choiceAmt = int.Parse(Console.ReadLine());
            return choiceAmt;
        }

        public int getIndex()
        {
            return index;
        }

        public int getQty()
        {
            return quantity;
        }
        public void getPayment()
        {
            
            Console.WriteLine("Which payement would you like to use?");
            Console.WriteLine("Debit,Cash or Check?");
            string userPayment = Console.ReadLine();
            userPayment = userPayment.Trim();
            Console.WriteLine();
            


            if (userPayment == "Debit" || userPayment == "debit")
            {
                Console.WriteLine("Please enter your card number");
                string cardNumber = Console.ReadLine();
                Console.WriteLine("Please enter your Expiration date");
                string Expiration = Console.ReadLine();
                Console.WriteLine("Please enter your CVC number");
                string CVC = Console.ReadLine();

                outputCustOrder();
                Console.WriteLine();
                Console.WriteLine("Paid by Debit Card :");
                Console.WriteLine("/t/tChange : /t/t0.00");


            }
            else if (userPayment == "Check" || userPayment == "check")
            {
                Console.WriteLine("Please insert your check number");
                string checkNumber = Console.ReadLine();
                Console.WriteLine();
                outputCustOrder();
                Console.WriteLine("Paid by Check");
                Console.WriteLine("/t/tChange : \t\t0.00");

            }

            else if (userPayment == "Cash" || userPayment == "cash")
            {
                
                Console.WriteLine("Please insert the amount of cash you have");
                double customerWallet = Double.Parse(Console.ReadLine());
                             

                double grandTotal = orderSubtotal * 1.06;
                double exactChange = customerWallet - grandTotal;
                string change = exactChange.ToString("0.00");
                outputCustOrder();
                Console.WriteLine("\t\tChange: \t" + change);


                
            }
        }
    }
}
