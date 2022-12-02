using CoffeeShop.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DAO
{
    class FoodDAO
    {
        private static volatile FoodDAO instance;


        internal static FoodDAO Instance 
        { 
            get
            {
                if (instance == null) instance = new FoodDAO();
                return FoodDAO.instance;
            }
        }

        private FoodDAO() { }
        public List<FoodDTO> GetAllFoodByIDCategory(int id)
        {
            List<FoodDTO> listFood = new List<FoodDTO>();
            string query = "Select * from Food where idCategory = @id ";
            object[] para = new object[] { id };
            DataTable data = DataProvider.Instance.ShowAll(query, para);
            foreach(DataRow item in data.Rows)
            {
                FoodDTO food = new FoodDTO(item);
                listFood.Add(food);
            }    
            return listFood;
        }
        public List<FoodDTO> ShowAllListFood()
        {
            List<FoodDTO> listFood = new List<FoodDTO>();
            string query = "Select * from Food";
            DataTable data = DataProvider.Instance.ShowAll(query);
            foreach (DataRow item in data.Rows)
            {
                FoodDTO food = new FoodDTO(item);
                listFood.Add(food);
            }
            return listFood;
        }
        public bool InsertFood(string name, int idCategory, float price)
        {
            string query = "Insert into Food(name,idCategory,price) values ( @name , @idcategory , @price )";
            object[] para = new object[] { name,idCategory,price };
            int result = DataProvider.Instance.AddDelteChange(query,para);
            return result > 0;
        }
        public bool UpdateFood(string name, int idCategory, float price, int id)
        {
            string query = "Update Food set Name = @name , idCategory = @idCategory , Price = @price where id = @id";
            object[] para = new object[] { name, idCategory, price , id };
            int result = DataProvider.Instance.AddDelteChange(query, para);
            return result > 0;
        }
        public bool DeleteFood(int id)
        {
            BillInfoDAO.Instance.DeleteBillInfo(id);
            string query = "Delete food where id = @id";
            object[] para = new object[] { id };
            int result = DataProvider.Instance.AddDelteChange(query, para);
            return result > 0;
        }
        public bool DeleteFoodByCategory(int id)
        {

            int idfood = 0; // id của Food
            string queryy = "Select id from food where idcategory = "+id;
            SqlConnection connection = new SqlConnection();
            connection.Open();
            SqlCommand command = new SqlCommand(queryy,connection);
            SqlDataReader read = command.ExecuteReader();
            if(read.Read())
            {
                idfood = (int)read["ID"];
            }
            connection.Close();

            int idbill = 0; // id của bill
            string queryyy = "Select idBill from billinfor where idfood = " + idfood;
            SqlConnection connectionn = new SqlConnection();
            connectionn.Open();
            SqlCommand commandd = new SqlCommand(queryyy, connectionn);
            SqlDataReader readd = commandd.ExecuteReader();
            if (readd.Read())
            {
                idbill = (int)readd["IDbill"];
            }
            connectionn.Close();
            BillInfoDAO.Instance.DeleteBillInfo(idfood);
            BillDAO.Instance.DeleteBillByIDBill(idbill);
            string query = "Delete food where idCategory = @id";
            object[] para = new object[] { id };
            int result = DataProvider.Instance.AddDelteChange(query, para);
            return result > 0;
        }

    }

      
}
