using CoffeeShop.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DAO
{
    class BillInfoDAO
    {
        private static volatile BillInfoDAO instance;

        internal static BillInfoDAO Instance
        { 
            get
            {
                if(instance == null)
                {
                    instance = new BillInfoDAO();
                }
                return BillInfoDAO.instance;
            }
        }
        private BillInfoDAO() { }
        public List<BillInfoDTO> GetListBillInfo(int id, string user)
        {
            
            List<BillInfoDTO> ListBillInfor = new List<BillInfoDTO>();
            string query = "Select * from BillInfo where idBill = @id ";
            object[] para = new object[] { id };
            DataTable data = DataProvider.Instance.ShowAll(query, para);
            foreach(DataRow item in data.Rows)
            {
                BillInfoDTO info = new BillInfoDTO(item);
                ListBillInfor.Add(info);
            }    
            return ListBillInfor;
        }
        public void InsertBillInfo(int idbill, int idfood, int count, string user)
        {
            
            string query = "exec USP_InsertBillInfo @idbill , @idtable , @count";
            object[] para = new object[] { idbill , idfood , count };
            DataProvider.Instance.AddDelteChange(query, para);
        }
        public bool DeleteBillInfo(int id)
        {
            
            string query = "Delete BillInfor where idfood = @id";
            object[] para = new object[] { id };
            int result = DataProvider.Instance.AddDelteChange(query, para);
            return result > 0;
        }
    }
}
