using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace BIPJ_sharedcopy_ishancopy1
{
    public class Transaction
    {
        string _connStr = ConfigurationManager.ConnectionStrings["usersContext"].ConnectionString;
        private int _txID = 0;
        private DateTime _time = DateTime.MinValue;
        private string _type = string.Empty;
        private string _asset = string.Empty;
        private decimal _amount = 0;
        private string _status = string.Empty;
        private string _email = string.Empty;
        public Transaction() { }

        public Transaction(DateTime time, string type, string asset, decimal amount, string status, string email)
        {
            _time = time;
            _type = type;
            _asset = asset;
            _amount = amount;
            _status = status;
            _email = email;
        }
        public Transaction(int txID, DateTime time, string type, string asset, decimal amount, string status, string email)
        {
            _txID = txID;
            _time = time;
            _type = type;
            _asset = asset;
            _amount = amount;
            _status = status;
            _email = email;
        }
        public int txID { get { return _txID; } set { _txID = value; } }
        public DateTime time { get => _time; set => _time = value; }
        public string type { get => _type; set => _type = value; }
        public string asset { get => _asset; set => _asset = value; }
        public decimal amount { get => _amount; set => _amount = value; }
        public string status { get => _status; set => _status = value; }
        public string email { get => _email; set => _email = value; }
        public int createTransaction(DateTime time, string type, string asset, decimal amount, string status, string email)
        {
            int result = 0;
            string queryStr = "INSERT INTO Transactions(time,type,asset,amount,status,email) values(@time,@type,@asset,@amount,@status,@email)";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            cmd.Parameters.AddWithValue("time", time);
            cmd.Parameters.AddWithValue("type", type);
            cmd.Parameters.AddWithValue("asset", asset);
            cmd.Parameters.AddWithValue("amount", amount);
            cmd.Parameters.AddWithValue("status", status);
            cmd.Parameters.AddWithValue("@email", email);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                result = cmd.ExecuteNonQuery();
            }
            else
            {
            }
            conn.Close();
            return result;

        }
        public List<Transaction> getTxAll(string email)
        {
            List<Transaction> txList = new List<Transaction>();
            int txID;
            decimal amount;
            DateTime time;
            string type, asset, status;
            string queryStr = "SELECT * FROM Transactions where email = @email";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@email", email);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txID = int.Parse(dr["txID"].ToString());
                type = dr["type"].ToString();
                asset = dr["asset"].ToString();
                status = dr["status"].ToString();
                time = Convert.ToDateTime(dr["time"]);

                amount = Convert.ToDecimal(dr["amount"]);
                Transaction tx = new Transaction(time, type, asset, amount, status, email);
                txList.Add(tx);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return txList;
        }

    }
}