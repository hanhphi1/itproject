using CoffeeShop.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DAO
{
    public class AccountDAO
    {
        private static volatile AccountDAO instace;

        public static AccountDAO Instace
        { 
            get
            {
                if(instace == null)
                {
                    instace = new AccountDAO();
                }
                return AccountDAO.instace;
            }
        }

        private AccountDAO() { }
        public bool Login(string username, string password)
        {
            string query = "Select * from Account where UserName = @username and PassWord = @password";
            object[] para = new object[] { username, password };
            DataTable result = DataProvider.Instance.ShowAll(query, para);
            if (result.Rows.Count > 0) return true;

            return false;
        }

        public AccountDTO GetAccountByUsserName(string username)
        {
            string query = "Select * from Account where username = '" + @username + "'";
            //object[] para = new object[] { username };
            DataTable data = DataProvider.Instance.ShowAll(query);
            foreach (DataRow item in data.Rows)
            {
                return new AccountDTO(item);
            }

            return null;
        }
        public DataTable GetListAccount()
        {
            string query = "Select UserName, displayname,typeofaccount from Account";
            return DataProvider.Instance.ShowAll(query);
        }

        public bool UpdateAccount(string username, string displayname, string password, string newpassword)
        {
            string query = "exec USP_UpdateAccount @username , @displayname , @password , @newpassword ";
            object[] para = new object[] { username, displayname, password, newpassword };
            int result = DataProvider.Instance.AddDelteChange(query, para);

            return result > 0;
        }
        public bool InsertAccount(string username, string displayname, string password, int typeofaccount)
        {
            string query = "Insert into Account (UserName,DisplayName,PassWord,TypeofAccount) values ( @UserName , @Displayname , @PassWord , @TypeofAccount )";
            object[] para = new object[] { username, displayname, password, typeofaccount };
            int result = DataProvider.Instance.AddDelteChange(query, para);

            return result > 0;
        }
        public bool UpdateAccountAdmin(string username, string displayname, string password, int typeofaccount)
        {
            string query = "Update Account set displayname = @displayname , password = @password , typeofaccount = @typeofaccount where UserName = @username ";
            object[] para = new object[] { displayname, password, typeofaccount, username };
            int result = DataProvider.Instance.AddDelteChange(query, para);

            return result > 0;
        }
        public bool DeleteAccountAdmin(string username)
        {

            string query = "Delete Account where UserName = @username ";
            object[] para = new object[] { username };
            int result = DataProvider.Instance.AddDelteChange(query, para);

            return result > 0;
        }
    }
}
