using Newtonsoft.Json;
using OrderFood_web_API.Exceptions;
using OrderFood_web_API.Models;
using OrderFood_web_API.Repository;
using shortid;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrderFood_web_API.Services
{
    public class OrderFoodService : IOrderFoodService
    {
        private readonly IOrderFoodRepository repo;

        public OrderFoodService(IOrderFoodRepository repo)
        {
            this.repo = repo;
        }
        public async Task<PromotionCode> GetPromotionCodeAsync(string Id, string token)
        {
            PromotionCode PromotionCode = null;
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                HttpResponseMessage response = await httpClient.GetAsync($"http://food-promotioncode:80/api/Promotion/{Id}");
                if (response.IsSuccessStatusCode)
                {
                    string resbody = await response.Content.ReadAsStringAsync();
                    PromotionCode = JsonConvert.DeserializeObject<PromotionCode>(resbody);
                }
                else
                {
                    throw new PromotionException(response.ReasonPhrase);
                }
            }
            return PromotionCode;
        }

        public async Task<string> UpdatePromotionCode(string Id, string token)
        {
            string resbody = "";
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                HttpResponseMessage response = await httpClient.GetAsync($"http://food-promotioncode:80/api/Promotion/use/{Id}");
                if (response.IsSuccessStatusCode)
                {
                    resbody = await response.Content.ReadAsStringAsync();
                }
            }
            return resbody;
        }

        [Obsolete]
        public string AddOrderFood(OrderFood orderFood, string token)
        {
            Task<PromotionCode> promotionCode = null;
            Task<string> updationresult = null;
            float discount = 0;
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
            try
            {
                if (orderFood.PromotionCode != "")
                {
                    promotionCode = GetPromotionCodeAsync(orderFood.PromotionCode, token);
                    discount = promotionCode.Result.Discount;
                    totalprice -= (discount / 100) * totalprice;
                    updationresult = UpdatePromotionCode(orderFood.PromotionCode, token);
                }
                orderFood.TotalPrice = totalprice;
                orderFood.OrderId = ShortId.Generate();
                return repo.AddOrderFood(orderFood);
            }
            catch (Exception)
            {
                return "Promotion Code Not exist";
            }

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
