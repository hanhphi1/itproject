using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop_DBMS.DTO
{
    class ChiPhiDTO
    {
        private DateTime? monthChiPhi;
        double price;

        public DateTime? MonthChiPhi { get => monthChiPhi; set => monthChiPhi = value; }
        public double Price { get => price; set => price = value; }
        public ChiPhiDTO(DataRow row)
        {
            MonthChiPhi = (DateTime?)row["MonthChiPhi"];
            Price = (double)row["Price"];
        }
    }
}
