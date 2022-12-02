using CoffeeShop.DAO;
using CoffeeShop.DTO;
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
    public partial class AccountProfile : Form
    {
        private AccountDTO accountLogin;

        public AccountDTO AccountLogin { get { return accountLogin; } set { accountLogin = value; } }
        public AccountProfile(AccountDTO account)
        {
            InitializeComponent();
            AccountLogin = account;
            ChangeAccount(AccountLogin);
        }
        void ChangeAccount(AccountDTO account)
        {
            TxtUserName.Text = account.UserName;
            txtDisplayName.Text = account.DisplayName;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            string username = TxtUserName.Text;
            string displayname = txtDisplayName.Text;
            string password = txtPass.Text;
            string newpassword = txtNewPass.Text;
            string againpassword = txtAgainPass.Text;

            if(!newpassword.Equals(againpassword))
            {
                MessageBox.Show("Nhập lại mật khẩu đúng với mật khẩu mới!");
            }
            else
            {
                if(AccountDAO.Instace.UpdateAccount(username,displayname,password,newpassword))
                {
                    MessageBox.Show("Cập nhật thành công. Đăng nhập lại để cập nhật thông tin");
                    this.Close();
                }    
                else
                {
                    MessageBox.Show("Nhập sai mật khẩu");
                }    
            }
        }
    }
}
