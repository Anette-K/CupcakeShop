﻿using CupcakeShop.Core.Contracts;
using CupcakeShop.Core.Models;
using CupcakeShop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CupcakeShop.Services
{
    public class OrderService : IOrderService
    {
        IRepository<Order> orderContext;
        public OrderService(IRepository<Order> OrderContext)
        {
            this.orderContext = OrderContext;
        }

        public void CreateOrder(Order baseOrder, List<BasketItemViewModel> basketItems)
        {
            //iterate through our basket item and then add it to the baseOrder
            foreach (var item in basketItems)
            {
                baseOrder.OrderItems.Add(new OrderItem()
                {
                    ProductId = item.Id,
                    image = item.Image,
                    Price = item.Price,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity
                });
            }
            //Insert our base order and the save the changes
            orderContext.Insert(baseOrder);
            orderContext.Commit();
        }
    }
}

