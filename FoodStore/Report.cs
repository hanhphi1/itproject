using CoffeeShop.DTO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace CoffeShop_DBMS
{
    public partial class Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Report()
        {
            InitializeComponent();
        }
        public void InitData(string tablename, int discount, DateTime date,double firstprice, double finalprice, List<MenuDTO> listmenu)
        {
            pTableName.Value = tablename;
            pDiscount.Value = discount;
            pDate.Value = date;
            FirstPrice.Value = firstprice;
            FinalPrice.Value = finalprice;
            objectDataSource1.DataSource = listmenu;
        }
    }
}
