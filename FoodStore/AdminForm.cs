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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop
{
    public partial class AdminForm : Form
    {
        BindingSource ListFood = new BindingSource();
        BindingSource ListAccount = new BindingSource();
        BindingSource ListCategory = new BindingSource();
        public AdminForm()
        {
            InitializeComponent();
            LoadAdmin();
        }
        void LoadAdmin()
        {
            dtgvfood.DataSource = ListFood;
            dtgvAccount.DataSource = ListAccount;
            dtgvCategory.DataSource = ListCategory;
            dtpkTo.Value = DateTime.Now;
            LoadBill();
            LoadFood();
            BidingFood();
            LoadAccount();
            BindingAccount();
            LoadCategoryAdmin();
            BindingCategory();
            LoadChiPhi();
            BindingChiPhi();
        }
        void LoadBill()
        {
            double TongDoanhThu = 0;
            dtgvBill.DataSource = BillDAO.Instance.GetListBillByDate(dtpkFrom.Value, dtpkTo.Value, ref TongDoanhThu);
            txtTongDoanhThu.Text = TongDoanhThu.ToString();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadBill();
        }
        void LoadFood()
        {
            ListFood.DataSource = FoodDAO.Instance.ShowAllListFood();
            cboxFoodGategory.DataSource = CategoryDAO.Instance.GetListCategory();
        }
        private void btnFoodSave_Click(object sender, EventArgs e)
        {
            string name = txtFoodName.Text;
            int idCategory = (cboxFoodGategory.SelectedItem as CategoryDTO).ID;
            float price = (float)numberFoodPrice.Value;
            bool result = FoodDAO.Instance.InsertFood(name, idCategory, price);
            {
                if (result)
                {
                    MessageBox.Show("Thêm món thành công!");
                    LoadFood();
                }
                else
                {
                    MessageBox.Show("Không thể thêm món!");
                }
            }
            btnFoodSave.Enabled = false;
        }
        
        void BidingFood()
        {
            cboxFoodGategory.DataSource = CategoryDAO.Instance.GetListCategory();
            cboxFoodGategory.DisplayMember = "Name";
            txtFoodName.DataBindings.Add(new Binding("Text", dtgvfood.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txtFoodID.DataBindings.Add(new Binding("Text", dtgvfood.DataSource, "ID", true, DataSourceUpdateMode.Never));
            numberFoodPrice.DataBindings.Add(new Binding("Value", dtgvfood.DataSource, "Price", true, DataSourceUpdateMode.Never));

        }

        private void txtFoodID_TextChanged(object sender, EventArgs e)
        {
            if (dtgvfood.SelectedCells.Count > 0)
            {
                int id = (int)dtgvfood.SelectedCells[0].OwningRow.Cells["IDCategory"].Value;

                CategoryDTO cateogory = CategoryDAO.Instance.GetCategoryByID(id);

                cboxFoodGategory.SelectedItem = cateogory;

                int index = -1;
                int i = 0;
                foreach (CategoryDTO item in cboxFoodGategory.Items)
                {
                    if (item.ID == cateogory.ID)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }

                cboxFoodGategory.SelectedIndex = index;
            }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            txtFoodID.Clear();
            txtFoodName.Clear();
            cboxFoodGategory.SelectedIndex = 0;
            numberFoodPrice.Value = 0;
            btnFoodSave.Enabled = true;
        }

        private void btnChangeFood_Click(object sender, EventArgs e)
        {
            string name = txtFoodName.Text;
            int idCategory = (cboxFoodGategory.SelectedItem as CategoryDTO).ID;
            float price = (float)numberFoodPrice.Value;
            int id = int.Parse(txtFoodID.Text);
            bool result = FoodDAO.Instance.UpdateFood(name, idCategory, price, id);
            {
                if (result)
                {
                    MessageBox.Show("Sửa món thành công!");
                    LoadFood();
                }
                else
                {
                    MessageBox.Show("Không thể sửa món!");
                }

            }
        }

        private void btnRemoveFood_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtFoodID.Text);
            bool result = FoodDAO.Instance.DeleteFood(id);
            {
                if (result)
                {
                    MessageBox.Show("Xóa món thành công!");
                    LoadFood();
                }
                else
                {
                    MessageBox.Show("Không thể xóa món!");
                }
            }
        }
        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }
        void LoadAccount()
        {
            ListAccount.DataSource = AccountDAO.Instace.GetListAccount();
        }
        void BindingAccount()
        {
            txtAccountUserName.DataBindings.Add(new Binding("Text",dtgvAccount.DataSource, "UserName",true,DataSourceUpdateMode.Never));
            txtAccountDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            numberTypeAccount.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "TypeOfAccount", true, DataSourceUpdateMode.Never));
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string username = txtAccountUserName.Text;
            string displayname = txtAccountDisplayName.Text;
            string password = txtAccountPassWord.Text;
            int typeofaccount = (int)numberTypeAccount.Value;
            bool result = AccountDAO.Instace.InsertAccount(username,displayname,password,typeofaccount);
            if(result)
            {
                MessageBox.Show("Thêm tài khoản thành công");
                LoadAccount();
            }    
            else
            {
                MessageBox.Show("Không thể thêm tài khoản!");
            }    
        }

        private void btnChangeAccount_Click(object sender, EventArgs e)
        {
            string username = txtAccountUserName.Text;
            string displayname = txtAccountDisplayName.Text;
            string password = txtAccountPassWord.Text;
            int typeofaccount = (int)numberTypeAccount.Value;
            bool result = AccountDAO.Instace.UpdateAccountAdmin(username, displayname, password, typeofaccount);
            if (result)
            {
                MessageBox.Show("Sửa tài khoản thành công");
                LoadAccount();
            }
            else
            {
                MessageBox.Show("Không thể sửa tài khoản!");
            }
        }

        private void btnRemoveAccount_Click(object sender, EventArgs e)
        {
            string username = txtAccountUserName.Text;
            bool result = AccountDAO.Instace.DeleteAccountAdmin(username);
            if (result)
            {
                MessageBox.Show("Xóa tài khoản thành công");
                LoadAccount();
            }
            else
            {
                MessageBox.Show("Không thể xóa tài khoản!");
            }
        }
        void LoadCategoryAdmin()
        {
            ListCategory.DataSource = CategoryDAO.Instance.GetListCategory();
        }

        private void btnShowCategory_Click(object sender, EventArgs e)
        {
            LoadCategoryAdmin();
        }
        void BindingCategory()
        {
            txtCategoryID.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txtCategoryName.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "Name", true, DataSourceUpdateMode.Never));
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string name = txtCategoryName.Text;
            bool result = CategoryDAO.Instance.InsertCategory(name);
            if (result)
            {
                MessageBox.Show("Thêm danh mục thành công");
                LoadCategoryAdmin();
                LoadFood();
                
            }
            else
            {
                MessageBox.Show("Không thể thêm danh mục!");
            }
        }

        private void btnChangeCetagory_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryID.Text);
            string name = txtCategoryName.Text;
            bool result = CategoryDAO.Instance.UpdateCategory(name,id);
            if (result)
            {
                MessageBox.Show("Sửa danh mục thành công");
                LoadCategoryAdmin();
                LoadFood();
            }
            else
            {
                MessageBox.Show("Không thể sửa danh mục!");
            }
        }

        private void btnRemoveCentagory_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryID.Text);
            bool result = CategoryDAO.Instance.DeleteCategory(id);
            if (result)
            {
                MessageBox.Show("Xóa danh mục thành công");
                LoadCategoryAdmin();
                LoadFood();
            }
            else
            {
                MessageBox.Show("Không thể xóa danh mục!");
            }
        }

        private void btnThongKeNV_Click(object sender, EventArgs e)
        {
            ThongKeNVForm tk = new ThongKeNVForm();
            tk.ShowDialog();
            tk.FormClosing += Tk_FormClosing;
        }

        private void Tk_FormClosing(object sender, FormClosingEventArgs e)
        {
            throw new NotImplementedException();
        }

        void LoadChiPhi()
        {
            dtgvChiPhi.DataSource = ChiPhiDAO.Instance.GetAllChiPhi();
        }

        void BindingChiPhi()
        {
            txtChiPhiID.DataBindings.Add(new Binding("Text", dtgvChiPhi.DataSource, "ID", true, DataSourceUpdateMode.Never));
            numberPriceChiPhi.DataBindings.Add(new Binding("Value", dtgvChiPhi.DataSource, "Price", true, DataSourceUpdateMode.Never));
            monthChiPhiEdit.DataBindings.Add(new Binding("Text", dtgvChiPhi.DataSource, "MonthChiPhi", true, DataSourceUpdateMode.Never));
        }

        private void btnAddChiPhi_Click(object sender, EventArgs e)
        {
            DateTime monthChiPhi = monthChiPhiEdit.DateTime;
            double price = double.Parse(numberPriceChiPhi.Text);
            bool result = ChiPhiDAO.Instance.InsertChiPhi(monthChiPhi, price);
            if (result)
            {
                MessageBox.Show("Thêm chi phí cho tháng " + monthChiPhi.Month +" thành công");
                LoadChiPhi();

            }
            else
            {
                MessageBox.Show("Không thể thêm chi phí!");
            }
        }

        private void btnRemoveChiPhi_Click(object sender, EventArgs e)
        {
            int idchiphi = int.Parse(txtChiPhiID.Text);
            DateTime monthChiPhi = monthChiPhiEdit.DateTime;
            bool result = ChiPhiDAO.Instance.DeleteChiPhi(idchiphi);
            if (result)
            {
                MessageBox.Show("Xóa chi phí " + monthChiPhi + " thành công");
                LoadChiPhi();

            }
            else
            {
                MessageBox.Show("Không thể xóa chi phí!");
            }
        }

        private void btnUpdateChiPhi_Click(object sender, EventArgs e)
        {
            int idchiphi = int.Parse(txtChiPhiID.Text);
            DateTime monthChiPhi = monthChiPhiEdit.DateTime;
            double price = double.Parse(numberPriceChiPhi.Text);
            bool result = ChiPhiDAO.Instance.UpdateChiPhi(monthChiPhi, price, idchiphi);
            if (result)
            {
                MessageBox.Show("Sửa chi phí cho tháng " + monthChiPhi + " thành công");
                LoadChiPhi();

            }
            else
            {
                MessageBox.Show("Không thể sửa chi phí!");
            }
        }

        private void btnThongKeLoiNhuan_Click(object sender, EventArgs e)
        {
            txtDoanhThuLoiNhuan.Text = (BillDAO.Instance.GetPriceBillByDate(dtpkFormLoiNhuan.Value, dtpkToLoiNhuan.Value)).ToString();
            txtChiPhiLoiNhuan.Text = (ChiPhiDAO.Instance.GetPriceChiPhiByDate(dtpkFormLoiNhuan.Value, dtpkToLoiNhuan.Value)).ToString();
            txtPriceLoiNhuan.Text = (double.Parse(txtDoanhThuLoiNhuan.Text) - double.Parse(txtChiPhiLoiNhuan.Text)).ToString();
        }
    }
}
