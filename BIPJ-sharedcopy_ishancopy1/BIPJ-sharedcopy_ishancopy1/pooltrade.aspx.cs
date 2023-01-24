using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIPJ_sharedcopy_ishancopy1
{
    public partial class pooltrade : System.Web.UI.Page
    {
        HttpContext context = HttpContext.Current;
        pool pool = new pool();
        decimal tradevalue = 0;
        decimal tradevalue2 = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = (string)(context.Session["email"]);
            if (email == null)
            {
                Response.Redirect("login.aspx");
            }
            string poolid = Request.QueryString["id"];
            if (poolid == null)
            {
                Response.Redirect("poolslist.aspx");
            }
            lbl_poolid.Text = poolid;
            pool newpool = new pool();
            pool = newpool.getPool(poolid);
            lbl_assets.Text = pool.crypto + " , " + pool.crypto2;
            lbl_bal.Text = pool.crypto + ": " + pool.bal;
            lbl_bal2.Text = pool.crypto2 + ": " + pool.bal2;
            if (ddl_crypto.Items.Count == 0)
            {
                ddl_crypto.Items.Add(pool.crypto);
                ddl_crypto.Items.Add(pool.crypto2);
            }
            lbl_selectedcrypto.Text = ddl_crypto.SelectedValue;
            var crypto = ddl_crypto.SelectedValue;
            string queryStr = "SELECT * FROM Balances WHERE email = @email and crypto=@crypto";
            string _connStr = ConfigurationManager.ConnectionStrings["usersContext"].ConnectionString;
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@crypto", crypto);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            string balance = "";
            if (dr.Read())
            {

                balance = dr["balance"].ToString();
                if (balance == null)
                {
                    balance = "0";
                }
                lbl_userbal.Text = "You have: " + balance + " " + crypto;
            }
            else
            {
                lbl_userbal.Text = "error";
            }

            conn.Close();
            dr.Close();
            dr.Dispose();
            tb_tradeamt.Attributes.Add("max", balance);

        }

        protected void selectedcrypto()
        {

        }

        protected void ddl_crypto_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_selectedcrypto.Text = ddl_crypto.SelectedValue;
            var crypto = ddl_crypto.SelectedValue;
            string queryStr = "SELECT * FROM Balances WHERE email = @email and crypto=@crypto";
            string _connStr = ConfigurationManager.ConnectionStrings["usersContext"].ConnectionString;
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            string email = (string)(context.Session["email"]);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@crypto", crypto);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            string balance = "";
            if (dr.Read())
            {

                balance = dr["balance"].ToString();
                if (balance == null)
                {
                    balance = "0";
                }
                lbl_userbal.Text = "You have: " + balance + " " + crypto;
            }
            else
            {
                lbl_userbal.Text = "error";
            }

            conn.Close();
            dr.Close();
            dr.Dispose();
            tb_tradeamt.Attributes.Add("max", balance);
        }

        protected void tb_tradeamt_TextChanged(object sender, EventArgs e)
        {
            decimal pairvalue = 0;
            decimal holderdecimal = 0;
            decimal tbvalue = decimal.Parse(tb_tradeamt.Text);
            string selectedval = string.Empty;
            if (ddl_crypto.SelectedValue == pool.crypto)
            {
                holderdecimal = decimal.Parse(pool.bal.ToString());
                pairvalue = (tbvalue / holderdecimal) * decimal.Parse(pool.bal2.ToString());
                selectedval = pool.crypto2;
            }
            else
            {
                holderdecimal = decimal.Parse(pool.bal2.ToString());
                pairvalue = ((tbvalue / holderdecimal) * decimal.Parse(pool.bal.ToString()));
                selectedval = pool.crypto;
            }
            lbl_2ndcrypto.Text = pairvalue.ToString() + " " + selectedval;
        }


        protected void btn_convert_Click(object sender, EventArgs e)
        {
            decimal pairvalue = 0;
            decimal holderdecimal = 0;
            decimal tbvalue = decimal.Parse(tb_tradeamt.Text);
            string selectedval = string.Empty;
            if (ddl_crypto.SelectedValue == pool.crypto)
            {
                holderdecimal = decimal.Parse(pool.bal.ToString());
                pairvalue = (tbvalue / holderdecimal) * decimal.Parse(pool.bal2.ToString());
                selectedval = pool.crypto2;
                tradevalue = tbvalue;
                tradevalue2 = -pairvalue;
            }
            else
            {
                holderdecimal = decimal.Parse(pool.bal2.ToString());
                pairvalue = ((tbvalue / holderdecimal) * decimal.Parse(pool.bal.ToString()));
                selectedval = pool.crypto;
                tradevalue = -tbvalue;
                tradevalue2 = pairvalue;
            }
            lbl_2ndcrypto.Text = pairvalue.ToString() + " " + selectedval;
        }

        protected void btn_Confirm_Click(object sender, EventArgs e)
        {
            string poolid = Request.QueryString["id"];
            pool tradepool = new pool();
            int result = 0;
            decimal pairvalue = 0;
            decimal holderdecimal = 0;
            decimal tbvalue = decimal.Parse(tb_tradeamt.Text);
            string selectedval = string.Empty;
            if (ddl_crypto.SelectedValue == pool.crypto)
            {
                holderdecimal = decimal.Parse(pool.bal.ToString());
                pairvalue = (tbvalue / holderdecimal) * decimal.Parse(pool.bal2.ToString());
                selectedval = pool.crypto2;
                tradevalue = tbvalue;
                tradevalue2 = -pairvalue;
            }
            else
            {
                holderdecimal = decimal.Parse(pool.bal2.ToString());
                pairvalue = ((tbvalue / holderdecimal) * decimal.Parse(pool.bal.ToString()));
                selectedval = pool.crypto;
                tradevalue = -pairvalue;
                tradevalue2 = tbvalue;
            }
            result += tradepool.makeTrade(poolid, tradevalue, tradevalue2);
            balances bal = new balances();
            string email = (string)(context.Session["email"]);
            int result2 = 0;
            int result3 = 0;
            decimal subbal = Convert.ToDecimal(tb_tradeamt.Text);
            result2 = bal.subtractBalance(email, subbal, ddl_crypto.SelectedValue);
            result3 = bal.updateBalance(email, pairvalue, selectedval);
            if (result > 0 && result2 > 0 && result3 > 0)
            {
                lbl_status.Text = "Trade successful!";
                lbl_status.Attributes.Add("style", "color:green");
            }
            else
            {
                lbl_status.Text = "Trade unsuccessful";
                lbl_status.Attributes.Add("style", "color:red");

            }
        }
    }
}