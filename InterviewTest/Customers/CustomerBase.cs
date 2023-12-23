using System;
using System.Collections.Generic;
using InterviewTest.Orders;
using InterviewTest.Returns;

namespace InterviewTest.Customers
{
    public abstract class CustomerBase : ICustomer
    {
        private readonly OrderRepository _orderRepository;
        private readonly ReturnRepository _returnRepository;

        protected CustomerBase(OrderRepository orderRepo, ReturnRepository returnRepo)
        {
            _orderRepository = orderRepo;
            _returnRepository = returnRepo;
        }

        public abstract string GetName();
        
        public void CreateOrder(IOrder order)
        {
            _orderRepository.Add(order);
        }

        public List<IOrder> GetOrders()
        {
            return _orderRepository.Get();
        }

        public void CreateReturn(IReturn rga)
        {
            _returnRepository.Add(rga);
        }

        public List<IReturn> GetReturns()
        {
            return _returnRepository.Get();
        }

        public float GetTotalSales()
        {
            //Requirement 1
            float total = 0;
            foreach (var order in GetOrders())
            {
                foreach (var product in order.Products)
                {
                    total += product.Product.GetSellingPrice();
                }
            }
            return total;
        }

        public float GetTotalReturns()
        {
            //Requirement 1
            float total = 0;
            foreach (var returns in GetReturns())
            {
                foreach (var ReturnedProduct in returns.ReturnedProducts)
                {
                    total += ReturnedProduct.OrderProduct.Product.GetSellingPrice();
                }
            }
            return total;
        }

        public float GetTotalProfit()
        {
            //Requirement 1
            float total = GetTotalSales() - GetTotalReturns();
            return total;
        }
    }
}
