using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeShop_DBMS.DTO
{
    public class DataProviderDTO
    {
        public string connectionString;
        private string connectStrAdmin = @"Data Source=.\SQLEXPRESS;Initial Catalog=CoffeeShopDBMS;Persist Security Info=True;User ID=admin";
        private string connectStrNhanVien1 = @"Data Source=.\SQLEXPRESS;Initial Catalog=CoffeeShopDBMS;User ID=nhanvien1";
        private string connectStrNhanVien2 = @"Data Source=.\SQLEXPRESS;Initial Catalog=CoffeeShopDBMS;User ID=nhanvien2";

        public string ConnectStrAdmin { get => connectStrAdmin; set => connectStrAdmin = value; }
        public string ConnectStrNhanVien1 { get => connectStrNhanVien1; set => connectStrNhanVien1 = value; }
        public string ConnectStrNhanVien2 { get => connectStrNhanVien2; set => connectStrNhanVien2 = value; }
        public string ConnectionString { get => connectionString; set => connectionString = value; }

        public string user;

        public DataProviderDTO() 
        {
            GetConnectionString();
        }
        public DataProviderDTO (string user)
        {
            this.user = user;
        }
        public void GetConnectionString()
        {
            if (user == "admin")
            {
                ConnectionString = connectStrAdmin;
            }
            if (user == "nhanvien1")
            {
                ConnectionString = connectStrNhanVien1;
            }
            if (user == "nhanvien2")
            {
                ConnectionString = connectStrNhanVien2;
            }
        }
    }
}
