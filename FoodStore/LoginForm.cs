using CoffeeShop.DAO;
using CoffeeShop.DTO;
using CoffeShop_DBMS.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop
{
    public partial class LoginForm : Form
    {



        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
                Application.Exit();
        }

        

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string user = txtUserName.Text;
            string password = txtPassWord.Text;
            if (Login(user, password) == true)
            {
                AccountDTO account = AccountDAO.Instace.GetAccountByUsserName(user);
                MainForm main = new MainForm(account);
                this.Hide();
                main.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Bạn đã nhập sai. Vui lòng thử lại", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        bool Login(string user, string password)
        {
            return AccountDAO.Instace.Login(user,password);
        }
       

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn thật sự muốn thoát không?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            
        }
    }
}
