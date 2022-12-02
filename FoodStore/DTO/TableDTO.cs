using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DTO
{
    public class TableDTO
    {
        private int iD;
        private string name;
        private string status;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }
        public TableDTO(int id, string name, string status)
        {
            ID = id;
            Name = name;
            Status = status;
        }
        public TableDTO(DataRow row)
        {
            ID = (int)row["ID"];
            Name = row["name"].ToString();
            Status = row["status"].ToString();
        }
    }
}
