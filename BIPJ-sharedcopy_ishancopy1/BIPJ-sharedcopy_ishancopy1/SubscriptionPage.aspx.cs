using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIPJ_sharedcopy_ishancopy1
{
    public partial class SubscriptionPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_Tier.SelectedValue = Request.QueryString["Tier"];
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string queryString = "?Tier=" + ddl_Tier;

            Response.Redirect("Subscribe.aspx" + queryString);
        }
    }
}