using System;
using System.Web;

namespace BIPJ_sharedcopy_ishancopy1
{
    public partial class index : System.Web.UI.Page
    {
        HttpContext context = HttpContext.Current;

        protected void Page_Load(object sender, EventArgs e)
        {
            string email = (string)(context.Session["email"]);
            lbl_test.Text = email;


        }
    }
}