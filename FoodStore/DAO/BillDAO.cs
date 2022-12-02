using CoffeeShop.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.DAO
{
    class BillDAO
    {
        private static volatile BillDAO instance;

        internal static BillDAO Instance
        {
            get
            {
                if(instance==null)
                {
                    instance = new BillDAO();
                }
                return BillDAO.instance;
            }
        }
        private BillDAO() { }

        public int GetUnCheckBillByTableID(int id)
        {
            string query = "Select * from Bill where idtable = @id and status = 0";
            object[] para = new object[] { id };
            DataTable data = DataProvider.Instance.ShowAll(query, para);
            if (data.Rows.Count > 0)
            {
                BillDTO bill = new BillDTO(data.Rows[0]);
                return bill.ID;
            }

            return -1;
        }
        public void InsertBill(int idtable, string staff)
        {
            string query = "exec USP_InsertBill " + @idtable + ", N'" + staff + "'";
            DataProvider.Instance.AddDelteChange(query);
        }
        public int GetBillMax()
        {
            try
            {
                string query = "Select MAX(id) from Bill";
                return (int)DataProvider.Instance.Count(query);
            }
            catch
            {
                return 1;
            }

        }
        public void CheckOut(int id, int discount, float totalPrice)
        {
            string query = "UPDATE dbo.Bill SET status = 1, DateCheckOut = Getdate(), Discount = @discount , TotalPrice = @totalPrice WHERE id = @id ";
            object[] para = new object[] { discount, totalPrice, id };
            DataProvider.Instance.AddDelteChange(query, para);
        }
        //public void CheckOut(int id, int discount, float totalPrice)
        //{
        //    string ConnectionString = "";
        //    if(user == "admin")
        //    {
        //        ConnectionString = connectiongStrAdmin;
        //    }
        //    if (user == "nhanvien1")
        //    {
        //        ConnectionString = connectiongStrNhanVien1;
        //    }
        //    if (user == "nhanvien2")
        //    {
        //        ConnectionString = connectiongStrNhanVien2;
        //    }
        //    SqlConnection cnn = new SqlConnection(ConnectionString);
        //    cnn.Open(); //mở kết nối
        //    //tạo đối tượng cmd mới
        //    SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
        //    //loại lệnh: câu lệnh SQL
        //    cmd.CommandType = CommandType.Text;
        //    //gán câu lệnh SQL
        //    cmd.CommandText = "UPDATE dbo.Bill SET status = 1, DateCheckOut = Getdate(), Discount = " + discount + " , TotalPrice = " + totalPrice + " WHERE id = " + id ;
        //    //ấn định kết nối CSDL cho đối tượng cmd
        //    cmd.Connection = cnn;
        //    //khai báo một transaction
        //    SqlTransaction transaction;
        //    //bắt đầu quá trình quản lý transaction
        //    transaction = cnn.BeginTransaction();
        //    //gắn transaction với đối tượng cmd
        //    cmd.Transaction = transaction;
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        //cam kết thực hiện thành công
        //        transaction.Commit();
        //    }
        //    catch
        //    {
        //        //hiển thị thông báo lỗi tại đây
        //        MessageBox.Show("Lỗi . Vui lòng kiểm tra dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        transaction.Rollback(); //quay lùi
        //    }
        //    cnn.Close();
        //}

        public DataTable GetListBillByDate(DateTime Checkin, DateTime CheckOut, ref double TongDoanhThu)
        {
            
            string query = "exec USP_GetListBillByDate @Checkin , @CheckOut";
            object[] para = new object[] { Checkin , CheckOut };
            DataTable data = DataProvider.Instance.ShowAll(query,para);
            foreach (DataRow item in data.Rows)
            {
                TongDoanhThu += double.Parse(item["Tổng tiền"].ToString());
            }
            return DataProvider.Instance.ShowAll(query, para);
        }
        public DataTable GetListBillByDateNV(DateTime Checkin, DateTime CheckOut, ref double TongDoanhThu, string tennhanvien)
        {

            string query = "exec USP_GetListBillByDateNV @Checkin , @CheckOut , @TenNV";
            object[] para = new object[] { Checkin, CheckOut, tennhanvien };
            DataTable data = DataProvider.Instance.ShowAll(query, para);
            foreach (DataRow item in data.Rows)
            {
                TongDoanhThu += double.Parse(item["Tổng tiền"].ToString());
            }
            return DataProvider.Instance.ShowAll(query, para);
        }
        public double GetPriceBillByDate(DateTime Checkin, DateTime CheckOut)
        {
            double TongDoanhThu = 0;
            string query = "exec USP_GetListBillByDate @Checkin , @CheckOut";
            object[] para = new object[] { Checkin, CheckOut };
            DataTable data = DataProvider.Instance.ShowAll(query, para);
            foreach (DataRow item in data.Rows)
            {
                TongDoanhThu += double.Parse(item["Tổng tiền"].ToString());
            }
            return TongDoanhThu;
        }
        public bool DeleteBillByIDBill(int idbill)
        {
            
            string query = "Delete Bill where id = @idbill";
            object[] para = new object[] { idbill };
            int result = DataProvider.Instance.AddDelteChange(query, para);
            return result > 0;
        }
    }
}
