using System;
using System.Linq;
using InterviewTest.Customers;
using InterviewTest.Orders;
using InterviewTest.Products;
using InterviewTest.Returns;

namespace InterviewTest
{
    public class Program
    {
        private static readonly OrderRepository orderRepo = new OrderRepository();
        private static readonly ReturnRepository returnRepo = new ReturnRepository();

        static void Main(string[] args)
        {
            //Matthew Luu
            //I used net8.0 for this project
            ProcessTruckAccessoriesExample();

            ProcessCarDealershipExample();

            Console.ReadKey();
        }

        private static void ProcessTruckAccessoriesExample()
        {
            //These three lines are used to solve the second bug
            var truckAccessoriesOrderRepo = new OrderRepository();
            var truckAccessoriesReturnRepo = new ReturnRepository();
            var customer = GetTruckAccessoriesCustomer(truckAccessoriesOrderRepo, truckAccessoriesReturnRepo);
            //This line is used for the second requirement
            DateTime orderDate = DateTime.Now;

            IOrder order = new Order("TruckAccessoriesOrder123", customer, orderDate);
            order.AddProduct(new HitchAdapter());
            order.AddProduct(new BedLiner());
            customer.CreateOrder(order);

            IReturn rga = new Return("TruckAccessoriesReturn123", order);
            rga.AddProduct(order.Products.First());
            //This line solves the first bug
            customer.CreateReturn(rga);

            ConsoleWriteLineResults(customer);
        }

        private static void ProcessCarDealershipExample()
        { 
            //These three lines are used to solve the second bug
            var carDealershipOrderRepo = new OrderRepository();
            var carDealershipReturnRepo = new ReturnRepository();
            var customer = GetCarDealershipCustomer(carDealershipOrderRepo, carDealershipReturnRepo);
            //This line is used for the second requirement
            DateTime orderDate = DateTime.Now;

            IOrder order = new Order("CarDealerShipOrder123", customer, orderDate);
            order.AddProduct(new ReplacementBumper());
            order.AddProduct(new SyntheticOil());
            customer.CreateOrder(order);

            IReturn rga = new Return("CarDealerShipReturn123", order);
            rga.AddProduct(order.Products.First());
            customer.CreateReturn(rga);

            ConsoleWriteLineResults(customer);
        }

        private static ICustomer GetTruckAccessoriesCustomer(OrderRepository orderRepo, ReturnRepository returnRepo)
        {
            return new TruckAccessoriesCustomer(orderRepo, returnRepo);
        }

        private static ICustomer GetCarDealershipCustomer(OrderRepository orderRepo, ReturnRepository returnRepo)
        {
            return new CarDealershipCustomer(orderRepo, returnRepo);
        }

        private static void ConsoleWriteLineResults(ICustomer customer)
        {
            Console.WriteLine(customer.GetName());
            //This block displays the items in the order, as well as the time of purchase
            foreach (var order in customer.GetOrders())
            {
                Console.WriteLine($"Order Date: {order.OrderDate}");
                Console.WriteLine("Items Purchased:");
                foreach (var orderedProduct in order.Products)
                {
                    Console.WriteLine($"- {orderedProduct.Product.GetProductNumber()}"); // Assuming GetProductNumber() exists in IProduct
                }
            }

            Console.WriteLine($"Total Sales: {customer.GetTotalSales().ToString("c")}");
            //This block displays the items in the return
            Console.WriteLine("Items Returned:");
            foreach (var returnItem in customer.GetReturns())
            {
                foreach (var returnedProduct in returnItem.ReturnedProducts)
                {
                    Console.WriteLine($"- {returnedProduct.OrderProduct.Product.GetProductNumber()}"); // Assuming GetProductNumber() exists in IProduct
                }
            }

            Console.WriteLine($"Total Returns: {customer.GetTotalReturns().ToString("c")}");

            Console.WriteLine($"Total Profit: {customer.GetTotalProfit().ToString("c")}");

            Console.WriteLine();
        }
    }
}
