using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace BIPJ_sharedcopy_ishancopy1
{
    public class balances
    {
        string _connStr = ConfigurationManager.ConnectionStrings["usersContext"].ConnectionString;
        private string _email = string.Empty;
        private decimal _balance = 0;
        private string _crypto = string.Empty;

        public balances() { }
        public balances(string email, decimal balance, string crypto)
        {
            _email = email;
            _balance = balance;
            _crypto = crypto;
        }
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }
        public decimal balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        public string crypto
        {
            get { return _crypto; }
            set { _crypto = value; }
        }
        public int updateBalance(string email, decimal balance, string crypto)
        {
            string logo = crypto.ToLower();
            int result = 0;
            balances updateBal = new balances(email, balance, crypto);
            string queryStr = "IF EXISTS(SELECT * From Balances where email = @email and crypto = @crypto) begin UPDATE Balances SET balance = balance + @balance where email = @email and crypto = @crypto end else begin INSERT into Balances(email,balance,crypto,logo) values (@email,@balance,@crypto,@logo) end";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@balance", balance);
            cmd.Parameters.AddWithValue("@crypto", crypto);
            cmd.Parameters.AddWithValue("@logo", logo);
            conn.Open();
            result += cmd.ExecuteNonQuery();
            conn.Close();
            return result;

        }
        public int subtractBalance(string email, decimal amount, string crypto)
        {
            int result = 0;
            balances updateBal = new balances(email, amount, crypto);
            string queryStr = "UPDATE Balances set balance = balance - @amount where email = @email and crypto = @crypto";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@crypto", crypto);
            conn.Open();
            result += cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }
        public List<balances> getBalancesAll(string email)
        {
            List<balances> balList = new List<balances>();
            string crypto;
            decimal balance;
            string queryStr = "SELECT * FROM Balances where email = @email";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@email", email);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                crypto = dr["crypto"].ToString();
                balance = Convert.ToDecimal(dr["balance"]);
                balances bal = new balances(email, balance, crypto);
                balList.Add(bal);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return balList;
        }
    }
}