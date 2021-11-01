using OrderFood_web_API.Exceptions;
using OrderFood_web_API.Models;
using OrderFood_web_API.Repository;
using shortid;
using System;
using System.Collections.Generic;

namespace OrderFood_web_API.Services
{
    public class OrderFoodService : IOrderFoodService
    {
        private readonly IOrderFoodRepository repo;

        public OrderFoodService(IOrderFoodRepository repo)
        {
            this.repo = repo;
        }

        [Obsolete]
        public string AddOrderFood(OrderFood orderFood)
        {
            OrderFood res = repo.GetOrderFoodById(orderFood.OrderId);
            if (res != null)
            {
                throw new OrderFoodAlreadyExistsException("Order Already exist");
            }
            float totalprice = 0;
            var obj = orderFood.FoodItems;
            foreach (var item in obj)
            {
                totalprice += item.Price;
            }
            orderFood.TotalPrice = totalprice;
            orderFood.OrderId = ShortId.Generate();
            return repo.AddOrderFood(orderFood);
        }

        public string DeleteOrderFood(string Id)
        {
            OrderFood res = repo.GetOrderFoodById(Id);
            if (res == null)
            {
                throw new OrderFoodNotFoundException("Order does not exist");
            }
            return repo.DeleteOrderFood(Id);
        }

        public OrderFood GetOrderFoodById(string Id)
        {
            OrderFood res = repo.GetOrderFoodById(Id);
            if (res == null)
            {
                throw new OrderFoodNotFoundException("Order does not exist");
            }
            return res;
        }

        public List<OrderFood> GetOrderFoods()
        {
            List<OrderFood> obj = repo.GetOrderFoods();
            if (obj == null && obj.Count == 0)
            {
                throw new OrderFoodNotFoundException("Order does not exist");
            }
            return obj;
        }

        public string UpdateOrderFood(string Id, OrderFood orderFood)
        {
            OrderFood res = repo.GetOrderFoodById(Id);
            if (res == null)
            {
                throw new OrderFoodNotFoundException("Order does not exist");
            }
            return repo.UpdateOrderFood(Id, orderFood);
        }
    }
}
