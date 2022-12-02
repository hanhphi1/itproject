using CoffeeShop.DAO;
using CoffeeShop.DTO;
using CoffeShop_DBMS;
using CoffeShop_DBMS.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop
{
    public partial class MainForm : Form
    {
        private AccountDTO accountLogin;


        public AccountDTO AccountLogin { get { return accountLogin; } set { accountLogin = value;} }
        public MainForm(AccountDTO account)
        {
            InitializeComponent();
            this.AccountLogin = account;
            ChangeAdmin(AccountLogin.TypeOfAccount);
            LoadTable();
            LoadCateGory();
        }
        void ChangeAdmin(int type)
        {
            if (type == 0) adminToolStripMenuItem.Enabled = false;
            thôngTinTàiKhoảnToolStripMenuItem.Text += " ( " + AccountLogin.DisplayName + " )";
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn thật sự muốn thoát không?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountProfile account = new AccountProfile(AccountLogin);
            account.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminForm admin = new AdminForm();
            admin.ShowDialog();
            admin.FormClosing += Admin_FormClosing;
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadTable();
        }

        void LoadTable()
        {
            flowLayoutPanel1.Controls.Clear();
            List<TableDTO> tablelist =  TableDAO.Instance.LoadTableList(this.accountLogin.UserName);
            foreach(TableDTO item in tablelist)
            {
                Button btn = new Button() {Width=TableDAO.BtnWidth,Height=TableDAO.BtnHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += Btn_Click;
                btn.Tag = item;
                if (item.Status == "Trống")
                {
                    btn.BackColor = Color.LightGreen;
                }
                else btn.BackColor = Color.LightSkyBlue;
                flowLayoutPanel1.Controls.Add(btn);
            }    
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as TableDTO).ID;
            listBill.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }

        void ShowBill(int id)
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            listBill.Items.Clear();
            List<MenuDTO> ListBillInfo = MenuDAO.Instance.GetListMenuTable(id);
            float total = 0;
            foreach (MenuDTO item in ListBillInfo)
            {
                ListViewItem lvItem = new ListViewItem(item.Name);
                lvItem.SubItems.Add(item.Count.ToString());
                lvItem.SubItems.Add(item.Price.ToString("c", culture));
                lvItem.SubItems.Add(item.TotalPrice.ToString("c", culture));
                total += item.TotalPrice;
                listBill.Items.Add(lvItem);
            }
            txtTotal.Text = total.ToString("c", culture);
        }
        void LoadCateGory()
        {
            List<CategoryDTO> listCategory = CategoryDAO.Instance.GetListCategory();
            cboxCategory.DataSource = listCategory;
            cboxCategory.DisplayMember = "Name";
        }
        void LoadFoodListByCategory(int id)
        {
            List<FoodDTO> ListFood = FoodDAO.Instance.GetAllFoodByIDCategory(id);
            cboxFood.DataSource = ListFood;
            cboxFood.DisplayMember = "Name";
        }

        private void cboxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null) return;
            CategoryDTO selected = cb.SelectedItem as CategoryDTO;
            id = selected.ID;
            LoadFoodListByCategory(id);
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            
            TableDTO table = listBill.Tag as TableDTO;
            if (table != null)
            {
                int idBill = BillDAO.Instance.GetUnCheckBillByTableID(table.ID);
                int idFood = (cboxFood.SelectedItem as FoodDTO).ID;
                int count = (int)numberFoodCount.Value;
                if (idBill == -1) //Chưa có bill thì thêm bill
                {
                    BillDAO.Instance.InsertBill(table.ID, this.accountLogin.DisplayName);
                    BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetBillMax(), idFood, count, this.accountLogin.UserName);
                }
                else
                {
                    BillInfoDAO.Instance.InsertBillInfo(idBill, idFood, count, this.accountLogin.UserName);
                }
                ShowBill(table.ID);
                LoadTable();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn bàn!","Thông báo",MessageBoxButtons.OK);
                return;
            }
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            TableDTO table = listBill.Tag as TableDTO;

            if (table != null)
            {
                int idBill = BillDAO.Instance.GetUnCheckBillByTableID(table.ID);
                int discount = (int)numberDiscount.Value;

                double ToTalPrice = Convert.ToDouble(txtTotal.Text.Split(',')[0].Replace(".", ""));
                //double ToTalPrice = Convert.ToDouble(txtTotal.Text.Split(',')[0]);
                double NewTotalPrice = ToTalPrice - (ToTalPrice / 100) * discount;
                if (idBill != -1)
                {
                    if (MessageBox.Show("Bạn có chắc thanh toán hóa đơn cho bàn " + table.Name, "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        MessageBox.Show("Hóa đơn của khách hàng là: " + NewTotalPrice + " (Đã giảm " + discount + "%)");
                        if (MessageBox.Show("Bạn có muốn in ra hóa đơn không ?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                        {
                            List<MenuDTO> ListBillInfo = MenuDAO.Instance.GetListMenuTable(table.ID);
                            Print.Instance.printBill(table.Name, discount, DateTime.Now, ToTalPrice, NewTotalPrice, ListBillInfo);
                        }    
                        BillDAO.Instance.CheckOut(idBill, discount, (float)NewTotalPrice);
                        ShowBill(table.ID);
                        LoadTable();
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn bàn!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            int idtable = (int)numbTableID.Value;
            List<TableDTO> tablelist = TableDAO.Instance.LoadTableList(this.accountLogin.UserName);
            foreach (TableDTO item in tablelist)
            {
                if(idtable == item.ID)
                {
                    MessageBox.Show("Bàn trùng. Vui lòng tạo bàn mới!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }    
            }
            TableDAO.Instance.AddTable(this.accountLogin.UserName, idtable);
            LoadTable();
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            TableDTO table = listBill.Tag as TableDTO;
            if (table != null)
            {
                int idBill = BillDAO.Instance.GetUnCheckBillByTableID(table.ID);
                if (idBill == -1) //Chưa có bill thì thêm bill
                {
                    TableDAO.Instance.DeleteTable(this.accountLogin.UserName, table.ID);
                }
                else
                {
                    MessageBox.Show("Bạn chưa thanh toán. Không được hủy bàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                ShowBill(table.ID);
                LoadTable();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn bàn!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
        }

    }
}
