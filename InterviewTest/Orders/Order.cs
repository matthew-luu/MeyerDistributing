using System;
using System.Collections.Generic;
using InterviewTest.Customers;
using InterviewTest.Products;

namespace InterviewTest.Orders
{
    public class Order : IOrder
    {
        public Order(string orderNumber, ICustomer customer, DateTime orderDate)
        {
            OrderNumber = orderNumber;
            Customer = customer;
            //Requirement 2
            OrderDate = orderDate;
            Products = new List<OrderedProduct>();
        }

        public string OrderNumber { get; }
        public ICustomer Customer { get; }
        public DateTime OrderDate { get; }
        public List<OrderedProduct> Products { get; }

        public void AddProduct(IProduct product)
        {
            Products.Add(new OrderedProduct(product));
        }
    }
}
