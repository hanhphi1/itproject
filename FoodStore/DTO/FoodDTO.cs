using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DTO
{
    public class FoodDTO
    {
        private int iD;
        private string name;
        private int iDCategory;
        private float price;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public int IDCategory { get => iDCategory; set => iDCategory = value; }
        public float Price { get => price; set => price = value; }

        public FoodDTO(int id, string name, int idCategory, float price)
        {
            ID = id;
            Name = name;
            IDCategory = idCategory;
            Price = price;
        }
        public FoodDTO(DataRow row)
        {
            ID = (int)row["id"];
            Name = row["name"].ToString();
            IDCategory = (int)row["idCategory"];
            Price = (float)Convert.ToDouble(row["price"].ToString());
        }
    }
}
