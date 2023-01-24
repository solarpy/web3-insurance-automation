using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BIPJ_sharedcopy_ishancopy1
{
    public class pool
    {
        string _connStr = ConfigurationManager.ConnectionStrings["usersContext"].ConnectionString;
        private string _crypto = string.Empty;
        private string _crypto2 = string.Empty;
        private decimal _bal = 0;
        private decimal _bal2 = 0;
        private decimal _fees = 0;
        private decimal _ratio = 0;
        private decimal _ratio2 = 0;


        public pool() { }
        public pool(string crypto, string crypto2, decimal bal, decimal bal2, decimal fees, decimal ratio, decimal ratio2)
        {
            _crypto = crypto;
            _crypto2 = crypto2;
            _bal = bal;
            _bal2 = bal2;
            _fees = fees;
            _ratio = ratio;
            _ratio2 = ratio2;
        }
        public string crypto
        {
            get { return _crypto; }
            set { _crypto = value; }
        }
        public string crypto2
        {
            get { return _crypto2; }
            set { _crypto2 = value; }
        }
        public decimal bal
        {
            get { return _bal; }
            set { _bal = value; }
        }
        public decimal bal2
        {
            get { return _bal2; }
            set { _bal2 = value; }
        }
        public decimal fees
        {
            get { return _fees; }
            set
            {
                _fees = value;
            }
        }
        public decimal ratio
        {
            get { return _ratio; }
            set
            {
                _ratio = value;
            }
        }
        public decimal ratio2
        {
            get { return _ratio2; }
            set { _ratio2 = value; }
        }
        public int makeTrade(string id, decimal bal, decimal bal2)
        {
            string queryStr = "UPDATE pools set bal = bal + @bal, bal2 = bal2 + @bal2 where id = @id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@bal", bal);
            cmd.Parameters.AddWithValue("@bal2", bal2);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            int result = 0;
            result += cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }
        public int createPool(string crypto, string crypto2, decimal bal, decimal bal2, decimal fees)
        {
            string queryStr = "INSERT into pools(crypto,crypto2,bal,bal2,fees,ratio,ratio2) values (@crypto,@crypto2,@bal,@bal2,@fees,@bal,@bal2)";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@bal", bal);
            cmd.Parameters.AddWithValue("@bal2", bal2);
            cmd.Parameters.AddWithValue("@crypto", crypto);
            cmd.Parameters.AddWithValue("@crypto2", crypto2);
            cmd.Parameters.AddWithValue("fees", fees);

            conn.Open();
            int result = 0;
            result += cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }
        public pool getPool(string id)
        {
            pool pool = new pool();
            string crypto, crypto2;
            decimal bal, bal2, fees, ratio, ratio2;
            string queryStr = "SELECT * From pools where id=@id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                crypto = dr["crypto"].ToString();
                crypto2 = dr["crypto2"].ToString();
                bal = decimal.Parse(dr["bal"].ToString());
                bal2 = decimal.Parse(dr["bal2"].ToString());
                fees = decimal.Parse(dr["fees"].ToString());
                ratio = decimal.Parse(dr["ratio"].ToString());
                ratio2 = decimal.Parse(dr["ratio2"].ToString());
                pool datapool = new pool(crypto, crypto2, bal, bal2, fees, ratio, ratio2);
                pool = datapool;
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return pool;

        }
    }
}