using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DTO
{
    class BillInfoDTO
    {
        private int iD;
        private int iDBill;
        private int iDFood;
        private int count;

        public int ID { get => iD; set => iD = value; }
        public int IDBill { get => iDBill; set => iDBill = value; }
        public int IDFood { get => iDFood; set => iDFood = value; }
        public int Count { get => count; set => count = value; }
        public BillInfoDTO(int id, int idBill, int idFood, int count)
        {
            ID = id;
            iDBill = idBill;
            IDFood = idFood;
            Count = count;
        }
        public BillInfoDTO(DataRow row)
        {
            ID = (int)row["id"];
            iDBill = (int)row["idBill"];
            IDFood = (int)row["idFoodd"];
            Count = (int)row["count"];
        }
    }
}
