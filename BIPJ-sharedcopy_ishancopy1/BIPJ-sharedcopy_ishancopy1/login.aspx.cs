using System;
using System.Configuration;
using System.Data.SqlClient;

namespace BIPJ_sharedcopy_ishancopy1
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["usersContext"].ToString());
            user userobj = new user();
            string queryStr = "select * from users where email = @email and password = @password";
            SqlCommand cmd = new SqlCommand(queryStr, con);
            cmd.Parameters.AddWithValue("@email", tb_email.Text);
            cmd.Parameters.AddWithValue("@password", tb_password.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Response.Write("<script>alert('Log in successful');</script>");
                userobj = userobj.getUser(tb_email.Text);
                Session["email"] = userobj.email;
                Response.Redirect("index.aspx");
            }
            else
            {
                Response.Write("<script>alert('Invalid Username or password! Please try again.');</script>");
            }
            con.Close();


        }
    }
}