using System;
using System.Web;

namespace BIPJ_sharedcopy_ishancopy1
{
    public partial class loggedinnavbar : System.Web.UI.MasterPage
    {
        HttpContext context = HttpContext.Current;

        protected void Page_Load(object sender, EventArgs e)
        {
            string email = (string)(context.Session["email"]);
            if (email == null)
            {
                Response.Redirect("login.aspx");
            }

        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Session.Remove("email");
            Response.Redirect("login.aspx");
        }
    }
}