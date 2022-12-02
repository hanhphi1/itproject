using CoffeeShop.DAO;
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
    public partial class ThongKeNVForm : Form
    {
        public ThongKeNVForm()
        {
            InitializeComponent();
        }

        private void btnThongKeNV_Click(object sender, EventArgs e)
        {
            string tennhanvien = txtThongKeNVName.Text;
            double TongDoanhThu = 0;
            dtgvThongKeNV.DataSource = BillDAO.Instance.GetListBillByDateNV(dtpkFromNV.Value, dtpkToNV.Value, ref TongDoanhThu, tennhanvien);
            txtTongDoanhThuNV.Text = TongDoanhThu.ToString();
        }
    }
}
