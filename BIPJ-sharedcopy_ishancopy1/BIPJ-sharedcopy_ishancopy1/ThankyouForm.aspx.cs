using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIPJ_sharedcopy_ishancopy1
{
    public partial class ThankyouForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Extract data from session variables and save it to label
            ShippingToState.Text = (string)Session["ShippingToState"];
            FullName.Text = (string)Session["FullName"];
            DeliveryAddress.Text = (string)Session["DeliveryAddress"];
            PostalCode.Text = (string)Session["PostalCode"];
            OrderSummary.Text = (string)Session["OrderSummary"];

            //Additional codes	
            ShippingTo.Text = (string)Session["ShippingTo"];
            PaymentMethod.Text = (string)Session["PaymentMethod"];
        }
        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("CheckoutForm.aspx");
        }

        protected void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (OrderSummary.Text == "$32.00")
            {
                Response.Redirect("cards1.aspx");
                Response.Write("<script>alert('Your Card has been confirmed');</script>");
            }
            else if (OrderSummary.Text == "$41.50")
            {
                Response.Redirect("cards2.aspx");
                Response.Write("<script>alert('Your Card has been confirmed');</script>");
            }
            else if (OrderSummary.Text == "$56.00")
            {
                Response.Redirect("cards3.aspx");
                Response.Write("<script>alert('Your Card has been confirmed');</script>");
            }
            else
            {
                Response.Redirect("index.aspx");
                Response.Write("<script>alert('There has been an error in your confirmation, please try again');</script>");
            }
        }
    }
}