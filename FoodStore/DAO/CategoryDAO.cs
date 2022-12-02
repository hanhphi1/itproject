using CoffeeShop.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DAO
{
    public class CategoryDAO
    {
        private static volatile CategoryDAO instance;

        public static CategoryDAO Instance 
        {
            get 
            {
                if (instance == null) instance = new CategoryDAO();
                return CategoryDAO.instance; 
            }
        }
        private CategoryDAO() { }
        public List<CategoryDTO> GetListCategory()
        {
            List<CategoryDTO> ListCategory = new List<CategoryDTO>();
            string query = "Select * from FoodCategory";
            DataTable data = DataProvider.Instance.ShowAll(query);
            foreach(DataRow item in data.Rows)
            {
                CategoryDTO cata = new CategoryDTO(item);
                ListCategory.Add(cata);
            }    
            return ListCategory;
        }
        public CategoryDTO GetCategoryByID(int id)
        {
            CategoryDTO category = null;

            string query = "select * from FoodCategory where id = " + id;

            DataTable data = DataProvider.Instance.ShowAll(query);

            foreach (DataRow item in data.Rows)
            {
                category = new CategoryDTO(item);
                return category;
            }

            return category;
        }
        public bool InsertCategory(string name)
        {
            string query = "Insert into FoodCategory(name) values ( @Name )";
            object[] para = new object[] { name };
            int result = DataProvider.Instance.AddDelteChange(query, para);
            return result > 0;
        }
        public bool UpdateCategory(string name, int id)
        {
            string query = "Update FoodCategory set Name = @name where id= @id ";
            object[] para = new object[] { name, id };
            int result = DataProvider.Instance.AddDelteChange(query, para);
            return result > 0;
        }
        public bool DeleteCategory(int id)
        {
            FoodDAO.Instance.DeleteFoodByCategory(id);
            string query = "Delete FoodCategory where id = @id";
            object[] para = new object[] { id };
            int result = DataProvider.Instance.AddDelteChange(query,  para);
            return result > 0;
        }
    }
}
