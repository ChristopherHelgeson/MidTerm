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
        //private double itemSubtotal = 0;
        private int custChoice;

        public static List<Order> currentOrder = new List<Order>();

        public Order(int index, int quantity)
        {
            this.index = index;
            this.quantity = quantity;
        }

        public void addToCustOrder()
        {
            int custChoice = getCustChoice(Product.products.Count);
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
            double itemSubtotal = 0;
            //Console.WriteLine("\nNAME\t\tQTY\t$/EA.\tSUBTOTAL\n");
            Console.WriteLine("{0,-10}{1,10}{2,10}{3,16}", "NAME","QTY","$/EA","SUBTOTAL\n");
            for (int i = 0; i < order.Count(); i++)
            {
                int currentIndex = order[i].getIndex();
                string currentName = products[currentIndex].getName();
                int currentQty = order[i].getQty();
                double currentPrice = products[currentIndex].getPrice();
                itemSubtotal = currentPrice * currentQty;
                //Console.WriteLine($"{currentName}\t\t{currentQty}\t{currentPrice.ToString("0.00")}\t{itemSubtotal.ToString("0.00")}");
                Console.WriteLine("{0,-10}{1,10}{2,10:N1}{3,15:N1}",currentName,currentQty,currentPrice.ToString("0.00"),itemSubtotal.ToString("0.00"));
            }
            orderSubtotal = orderSubtotal + itemSubtotal;
            Console.WriteLine("\n{0,35}{1,10}", "PreTax Total:", orderSubtotal.ToString("0.00"));
            Console.WriteLine("{0,35}{1,10}", "Sales Tax (6%):", (orderSubtotal * .06).ToString("0.00"));
            Console.WriteLine("{0,35}{1,10}", "Grand Total:", (orderSubtotal * 1.06).ToString("0.00"));
            //Console.WriteLine("\n\t\tPreTax Total:\t" + orderSubtotal.ToString("0.00"));
            //Console.WriteLine("\t\tSales Tax (6%): " + (orderSubtotal * .06).ToString("0.00"));
            //Console.WriteLine("\t\tGrand Total: \t" + (orderSubtotal * 1.06).ToString("0.00"));
        }

        public void outputReceipt(double orderSubtotal)
        {
            printReceipt(currentOrder, Product.products, orderSubtotal);
        }

        public void printReceipt(List<Order> order, List<Product> products, double orderSubtotal)
        {
            Console.WriteLine("{0,-10}{1,10}{2,10}{3,16}", "NAME", "QTY", "$/EA", "SUBTOTAL\n");
            for (int i = 0; i < order.Count(); i++)
            {
                double itemSubtotal = 0;
                int currentIndex = order[i].getIndex();
                string currentName = products[currentIndex].getName();
                int currentQty = order[i].getQty();
                double currentPrice = products[currentIndex].getPrice();
                itemSubtotal = currentPrice * currentQty;
                Console.WriteLine("{0,-10}{1,10}{2,10:N1}{3,15:N1}", currentName, currentQty, currentPrice.ToString("0.00"), itemSubtotal.ToString("0.00"));
            }
            Console.WriteLine("\n{0,35}{1,10}", "PreTax Total:", orderSubtotal.ToString("0.00"));
            Console.WriteLine("{0,35}{1,10}", "Sales Tax (6%):", (orderSubtotal * .06).ToString("0.00"));
            Console.WriteLine("{0,35}{1,10}", "Grand Total:", (orderSubtotal * 1.06).ToString("0.00"));
        }

        //public void printSubtotal(List<Order> order, List<Product> products)
        //{
        //    for (int i = 0; i < order.Count(); i++)
        //    {
        //        int currentIndex = order[i].getIndex();
        //        string currentName = products[currentIndex].getName();
        //        int currentQty = order[i].getQty();
        //        double currentPrice = products[currentIndex].getPrice();
        //        orderSubtotal = currentQty * currentPrice;
        //    }
        //    Console.WriteLine("\n\t\tPreTax Total:\t" + orderSubtotal.ToString("0.00"));
        //    Console.WriteLine("\t\tSales Tax (6%): " + (orderSubtotal * .06).ToString("0.00"));
        //    Console.WriteLine("\t\tGrand Total: \t" + (orderSubtotal * 1.06).ToString("0.00"));
        //}

        public int getCustChoice(int itemsInList)
        {
            int itemIndex = -1;
            Console.Write("Which item would you like to purchase? (0-" + (itemsInList -1) + "): ");
            string userInput = Console.ReadLine();
            itemIndex = insureInt(userInput);
            while (itemIndex < 0 || itemIndex > (itemsInList - 1))
            {
                Console.Write("Please enter an integer from 0 to " + (itemsInList - 1) + " only: ");
                userInput = Console.ReadLine();
                itemIndex = insureInt(userInput);
            }
            return itemIndex;
        }

        public int getChoiceAmt()
        {
            int choiceAmt = 0;
            Console.Write("\nHow many would you like?: ");
            string userInput = Console.ReadLine();
            choiceAmt = insureInt(userInput);
            while (choiceAmt < 1 )
            {
                Console.Write("Please enter a positive integer only: ");
                userInput = Console.ReadLine();
                choiceAmt = insureInt(userInput);
            }
            return choiceAmt;
        }

        public int insureInt(string userInput)
        {
            try
            {
                custChoice = int.Parse(userInput);
                return custChoice;
            }
            catch (SystemException)
            {
                return -1;
            }
        }

        public int getIndex()
        {
            return index;
        }

        public int getQty()
        {
            return quantity;
        }



//-------------Ariana's code below------------------------------------------

        public void getPayment()
        {
            double x = orderSubtotal * 1.06;
            string totalDue = x.ToString("0.00");
            Console.WriteLine("Total amount due is $" + totalDue);
            Console.WriteLine("\nWhich payment method would you like to use?");
            Console.Write("Please type 'Debit' or 'Cash' or 'Check': ");
            string userPayment = Console.ReadLine();
            userPayment = userPayment.Trim();
            Console.WriteLine();

            if (userPayment == "Debit" || userPayment == "debit")
            {
                Console.Write("Please enter your card number: ");
                string cardNumber = Console.ReadLine();
                Console.Write("Please enter your expiration date: ");
                string Expiration = Console.ReadLine();
                Console.Write("Please enter your CVV number: ");
                string CVV = Console.ReadLine();

                outputReceipt(orderSubtotal);
                Console.WriteLine();
                Console.WriteLine("Paid by Debit Card :");
                Console.WriteLine("Change: \t\t0.00");
                Console.WriteLine("Paid with card#: " + cardNumber + ", " + Expiration + ", " + CVV);
            }
            else if (userPayment == "Check" || userPayment == "check")
            {
                Console.Write("Please insert your check number: ");
                string checkNumber = Console.ReadLine();
                Console.WriteLine();
                outputReceipt(orderSubtotal);
                Console.WriteLine("Paid in full by Check# : " + checkNumber);
                Console.WriteLine("\t\tChange : \t\t0.00");
            }
            else if (userPayment == "Cash" || userPayment == "cash")
            {
                Console.Write("Please insert the amount of cash you have: ");
                double customerWallet = double.Parse(Console.ReadLine());

                double grandTotal = orderSubtotal * 1.06;
                double exactChange = customerWallet - grandTotal;
                string change = exactChange.ToString("0.00");
                outputReceipt(orderSubtotal);
                Console.WriteLine("\t\tTendered: \t" + customerWallet);
                Console.WriteLine("\t\tChange: \t" + change);
            }
        }
    }
}
