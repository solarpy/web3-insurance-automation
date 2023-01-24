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
    public partial class createpool : System.Web.UI.Page
    {
        HttpContext context = HttpContext.Current;
        Boolean validpair = false;

        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btn_ConfirmPair_Click(object sender, EventArgs e)
        {
            if (ddl_cryptos.SelectedValue == ddl_cryptos2.SelectedValue)
            {
                lbl_ratio.Text = "Please select two different tokens for your pair";
                validpair = false;
            }
            else
            {
                lbl_ratio.Text = tb_withdrawamt.Text + " " + ddl_cryptos.SelectedValue + " Pool = " + tb_withdrawamt2.Text + " " + ddl_cryptos2.SelectedValue + " Pool";
                validpair = true;
            }
            lbl_fees.Text = tb_fees.Text;
        }

        protected void ddl_cryptos2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var crypto = ddl_cryptos2.SelectedValue;
            if (crypto == null)
            {
            }
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
                lbl_bal2.Text = "You have: " + balance + " " + crypto;
            }
            else
            {
                lbl_bal2.Text = "error";
            }

            conn.Close();
            dr.Close();
            dr.Dispose();
            tb_withdrawamt2.Attributes.Add("max", balance);

        }

        protected void ddl_cryptos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var crypto = ddl_cryptos.SelectedValue;
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
                lbl_bal.Text = "You have: " + balance + " " + crypto;
            }
            else
            {
                lbl_bal.Text = "error";
            }

            conn.Close();
            dr.Close();
            dr.Dispose();
            tb_withdrawamt.Attributes.Add("max", balance);
        }

        protected void btn_Confirm_Click(object sender, EventArgs e)
        {
            pool pool = new pool();
            int result = 0;
            result = pool.createPool(ddl_cryptos.SelectedValue, ddl_cryptos2.SelectedValue, decimal.Parse(tb_withdrawamt.Text), decimal.Parse(tb_withdrawamt2.Text), decimal.Parse(tb_fees.Text));
            if (result > 0)
            {
                Response.Redirect("wallet.aspx");
            }

            else
            {
                lbl_error.Text = "an error occured, please try again";
            }
        }
    }
}