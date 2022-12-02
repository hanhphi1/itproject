using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DTO
{
    public class MenuDTO
    {
        private string name;
        private int count;
        private float price;
        private float totalPrice;

        public string Name { get => name; set => name = value; }
        public int Count { get => count; set => count = value; }
        public float Price { get => price; set => price = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
        public MenuDTO(string name, int count, float price, float total) 
        {
            Name = name;
            Count = count;
            Price = price;
            TotalPrice = total;
        }
        public MenuDTO(DataRow row)
        {
            Name = row["name"].ToString();
            Count = (int)row["count"];
            Price = (float)Convert.ToDouble(row["price"].ToString());
            TotalPrice = (float)Convert.ToDouble(row["TotalPrice"].ToString());
        }
    }
}
