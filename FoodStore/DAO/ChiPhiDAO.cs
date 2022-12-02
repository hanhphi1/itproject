using CoffeeShop.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop_DBMS.DAO
{
    class ChiPhiDAO
    {
        private static volatile ChiPhiDAO instance;

        internal static ChiPhiDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ChiPhiDAO();
                }
                return ChiPhiDAO.instance;
            }
        }
        private ChiPhiDAO() { }

        public DataTable GetAllChiPhi()
        {
            string query = "Select * from ChiPhi";
            return DataProvider.Instance.ShowAll(query);
        }
        public bool InsertChiPhi(DateTime monthchiphi, double price)
        {
            string query = "Insert into ChiPhi(MonthChiPhi,Price) Values( '" + monthchiphi + "', " + price + ")";
            int result = DataProvider.Instance.AddDelteChange(query);
            return result > 0;
        }
        public bool UpdateChiPhi(DateTime monthchiphi, double price, int id)
        {

            string query = "Update ChiPhi set MonthChiPhi = '" + @monthchiphi + "', Price = @price where id = @idchiphi";
            object[] para = new object[] { price, id };
            int result = DataProvider.Instance.AddDelteChange(query, para);
            return result > 0;
        }
        public bool DeleteChiPhi(int id)
        {

            string query = "Delete ChiPhi where ID = @idchiphi";
            object[] para = new object[] { id };
            int result = DataProvider.Instance.AddDelteChange(query, para);
            return result > 0;
        }
        public double GetPriceChiPhiByDate(DateTime dateFrom, DateTime dateTo)
        {
            double TongChiPhi = 0;
            string query = "exec USP_GetChiPhiByDate @Checkin , @CheckOut";
            object[] para = new object[] { dateFrom, dateTo };
            DataTable data = DataProvider.Instance.ShowAll(query, para);
            foreach (DataRow item in data.Rows)
            {
                TongChiPhi += double.Parse(item["Price"].ToString());
            }
            return TongChiPhi;
        }
    }
}
