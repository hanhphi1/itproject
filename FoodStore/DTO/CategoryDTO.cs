using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DTO
{
    public class CategoryDTO
    {
        private int iD;
        private string name;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public CategoryDTO(int id,string name)
        {
            ID = id;
            Name = name;
        }
        public CategoryDTO(DataRow row)
        {
            ID = (int)row["id"];
            Name = row["name"].ToString();
        }

    }
}
