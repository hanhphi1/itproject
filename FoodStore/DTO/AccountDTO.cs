using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DTO
{
    public class AccountDTO
    {
        private string userName;
        private string displayName;
        private string passWord;
        private int typeOfAccount;

        public string UserName { get => userName; set => userName = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public int TypeOfAccount { get => typeOfAccount; set => typeOfAccount = value; }
        public AccountDTO(string username, string displayname, string password, int typeofaccount)
        {
            UserName = username;
            DisplayName = displayname;
            PassWord = password;
            TypeOfAccount = typeofaccount;
        }
        public AccountDTO(DataRow row)
        {
            UserName = row["username"].ToString();
            DisplayName = row["displayname"].ToString();
            PassWord = row["password"].ToString();
            TypeOfAccount = (int)row["typeofaccount"];
        }
    }
}
