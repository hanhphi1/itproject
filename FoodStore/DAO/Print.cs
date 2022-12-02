using CoffeeShop.DTO;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop_DBMS.DAO
{
    class Print : XtraForm
    {
        private static volatile Print instance;
        public static Print Instance
        {
            get
            {
                if (instance == null) instance = new Print();
                return Print.instance;
            }
        }
        public void printBill(string tablename, int discount, DateTime date, double firstprice, double finalprice, List<MenuDTO> listmenu)
        {
            using(formPrint print = new formPrint())
            {
                print.PrintStore(tablename, discount, date,firstprice, finalprice, listmenu);
                print.ShowDialog();
            }    
        }
    }
}
