using CoffeeShop.DTO;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeShop_DBMS
{
    public partial class formPrint : DevExpress.XtraEditors.XtraForm
    {
        public formPrint()
        {
            InitializeComponent();
        }

        public void PrintStore(string tablename, int discount, DateTime date, double firstprice, double finalprice, List<MenuDTO> listmenu)
        {
            Report report = new Report();
            foreach(DevExpress.XtraReports.Parameters.Parameter p in report.Parameters)
            {
                p.Visible = false;
            }
            report.InitData(tablename,discount,date,firstprice, finalprice,listmenu);
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }
    }
}