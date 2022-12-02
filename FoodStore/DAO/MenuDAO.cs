using CoffeeShop.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DAO
{
    public class MenuDAO
    {
        private static volatile MenuDAO instance;
        public static MenuDAO Instance 
        { 
            get
            {
                if (instance == null) instance = new MenuDAO();
                return MenuDAO.instance;
            }
        }
        private MenuDAO() { }
        public List<MenuDTO> GetListMenuTable(int id)
        {
            List<MenuDTO> listMenu = new List<MenuDTO>();
            string query = "Select f.name, bi.count,f.price,f.price*bi.count as TotalPrice from Billinfor as bi,bill as b,food as f where bi.idbill = b.id and bi.idfood = f.id and b.idtable = @id and b.status = 0";
            object[] para = new object[] { id };
            DataTable data = DataProvider.Instance.ShowAll(query, para);
            foreach(DataRow item in data.Rows)
            {
                MenuDTO menu = new MenuDTO(item);
                listMenu.Add(menu);
            }    
            return listMenu;
        }
    }
}
