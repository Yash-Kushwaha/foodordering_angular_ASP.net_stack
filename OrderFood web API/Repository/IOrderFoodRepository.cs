using OrderFood_web_API.Models;
using System.Collections.Generic;

namespace OrderFood_web_API.Repository
{
    public interface IOrderFoodRepository
    {
        string AddOrderFood(OrderFood orderFood);
        List<OrderFood> GetOrderFoods();
        OrderFood GetOrderFoodById(string Id);
        string UpdateOrderFood(string Id, OrderFood orderFood);
        string DeleteOrderFood(string Id);
    }
}
