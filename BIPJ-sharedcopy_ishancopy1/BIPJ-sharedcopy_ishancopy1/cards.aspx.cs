using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIPJ_sharedcopy_ishancopy1
{
    public partial class cards : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            if (int.Parse(Deposit.Text) == 56)
            {
                int f = int.Parse(Deposit.Text);

                lbl_balance.Text = "$" + f.ToString();
                lbl_btc.Text = "$389";
                lbl_btc2.Text = "$389";
            }

            else
            {
                Response.Write("<script>alert('Please enter a valid deposit amount');</script>");
                Response.Redirect("cards.aspx");
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            lbl_balance.Text = "$24";
            lbl_eth.Text = "$268";
            lbl_ethlol.Text = "$268";
        }

        protected void whatanicebutton_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://test.bitpay.com/m/47558/checkout");
        }
    }
}