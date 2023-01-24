using System.Configuration;
using System.Data.SqlClient;

namespace BIPJ_sharedcopy_ishancopy1
{
    public class user
    {
        string _connStr = ConfigurationManager.ConnectionStrings["usersContext"].ConnectionString;
        private string _email = string.Empty;
        private string _password = string.Empty;

        public user() { }
        public user(string email, string password)
        {
            _email = email;
            _password = password;
        }
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }
        public user getUser(string email)
        {
            user userDetail = null;
            string password;
            string queryStr = "SELECT * FROM Users where email = @email";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@email", email);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                email = dr["email"].ToString();
                password = dr["password"].ToString();
                userDetail = new user(email, password);
            }
            else
            {
                userDetail = null;
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return userDetail;

        }
        public int createUser(string email, string password)
        {
            int result = 0;
            string queryStr = "IF NOT EXISTS (SELECT * FROM Users WHERE email = @email) BEGIN INSERT INTO Users(email,password)" + "values (@email, @password) END";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);
            conn.Open();
            result += cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }
    }
}