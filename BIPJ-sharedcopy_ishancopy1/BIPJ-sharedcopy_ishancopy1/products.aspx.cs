using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIPJ_sharedcopy_ishancopy1
{
    public partial class products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DataList1_ItemCommand1(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "viewdetails")
            {
                Response.Redirect("productDetails.aspx?ProdID=" + e.CommandArgument.ToString());

            }

        }
        protected void Button3_Click1(object sender, EventArgs e)
        {
            DataList1.Visible = true;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
            {
                DataList1.DataSourceID = null;
                DataList1.DataSource = SqlDataSource2;
                DataList1.DataBind();



            }
        }
    }
}