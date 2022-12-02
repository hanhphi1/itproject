using CoffeeShop.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DAO
{
    public class TableDAO
    {
        private static volatile TableDAO instance;
        public static TableDAO Instance
        { 
            get
            {
                if(instance == null)
                {
                    instance = new TableDAO();
                }
                return TableDAO.instance;
            }
        }
        private TableDAO() { }
        public static int BtnWidth = 90;
        public static int BtnHeight = 90;
        public List<TableDTO> LoadTableList(string user)
        {
            
            List<TableDTO> tablelist = new List<TableDTO>();
            string query = "Select * from TableFood";
            DataTable data = DataProvider.Instance.ShowAll(query);
            foreach (DataRow item in data.Rows) //Trong danh sách dòng của data(datatalbe) lấy ra từng dòng từng dòng để dùng
            {
                TableDTO tableDTO = new TableDTO(item);
                tablelist.Add(tableDTO);
            }

            return tablelist;
        }
        public void AddTable(string user, int number)
        {
            
            string query = "insert into tablefood(name) values (N'Bàn '+ cast( @number as nvarchar(50)))";
            object[] para = new object[] { number };
            DataProvider.Instance.AddDelteChange(query, para);
        }
        public void DeleteTable(string user, int idtable)
        {
            
            string query = "Delete TableFood where id = @idtable ";
            object[] para = new object[] { idtable };
            DataProvider.Instance.AddDelteChange(query, para);
        }
    }
}
