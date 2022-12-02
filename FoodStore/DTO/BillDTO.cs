using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DTO
{
    class BillDTO
    {
        private int iD;
        private DateTime? dayCheckIn;
        private DateTime? dayCheckOut;
        private int iDTable;
        private string staff;
        private int status;
        private int disCount;

        public int ID { get => iD; set => iD = value; }
        public DateTime? DayCheckIn { get => dayCheckIn; set => dayCheckIn = value; }
        public DateTime? DayCheckOut { get => dayCheckOut; set => dayCheckOut = value; }
        public int IDTable { get => iDTable; set => iDTable = value; }
        public int Status { get => status; set => status = value; }
        public int DisCount { get => disCount; set => disCount = value; }
        public string Staff { get => staff; set => staff = value; }

        public BillDTO(int id, DateTime dayCheckin, DateTime? dayCheckout, int idtable, string staff, int status, int discount =0)
        {
            ID = id;
            DayCheckIn = dayCheckin;
            DayCheckOut = dayCheckOut;
            IDTable = idtable;
            Status = status;
            DisCount = discount;
            Staff = staff;
        }
        public BillDTO(DataRow row)
        {
            ID = (int)row["id"];
            DayCheckIn = (DateTime?)row["Datecheckin"];
            var dayCheckOutTemp = row["datecheckout"];
            if (dayCheckOutTemp.ToString() != "")
                DayCheckOut = (DateTime?)dayCheckOutTemp;
            IDTable = (int)row["idtable"];
            Staff = row["Staff"].ToString();
            Status = (int)row["status"];
            DisCount = (int)row["Discount"];
        }
    }
}
