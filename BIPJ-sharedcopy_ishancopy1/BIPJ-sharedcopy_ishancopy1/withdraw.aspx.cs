using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIPJ_sharedcopy_ishancopy1
{
    public partial class withdraw : System.Web.UI.Page
    {
        HttpContext context = HttpContext.Current;
        string[] availArray = new string[] { "BTC", "DASH", "DOGE", "LTC" };
        Dictionary<string, string> mapcrypto = new Dictionary<string, string>()
        {
            {"BTC","bitcoin" },
            {"LTC","litecoin" },
            {"DOGE","dogecoin" },
            {"DASH","dash" }
        };

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Data
        {
            public Item item { get; set; }
        }

        public class Item
        {
            public string feePriority { get; set; }
            public string note { get; set; }
            public string prepareStrategy { get; set; }
            public List<Recipient> recipients { get; set; }
        }

        public class Recipient
        {
            public string address { get; set; }
            public string amount { get; set; }
        }

        public class Root
        {
            public string context { get; set; }
            public Data data { get; set; }
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


            balance = dr["balance"].ToString();
            lbl_bal.Text = balance + " " + crypto;


            conn.Close();
            dr.Close();
            dr.Dispose();
            Boolean valid = false;
            foreach (string i in availArray)
            {
                if (crypto == i)
                {
                    valid = true;
                    break;
                }

            }
            if (valid == false)
            {
                lbl_availerror.Text = "Sorry, this cryptocurrency is not supported for withdrawals right now";
            }
            else
            {
                lbl_availerror.Text = "Sorry, this cryptocurrency is not supported for withdrawals right now";

            }



        }



        protected void ddl_cryptos_SelectedIndexChanged1(object sender, EventArgs e)
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
            Boolean valid = false;
            foreach (string i in availArray)
            {
                if (crypto == i)
                {
                    valid = true;
                    break;
                }

            }
            if (valid == false)
            {
                lbl_availerror.Text = "Sorry, this cryptocurrency is not supported for withdrawals right now";
            }
            else
            {
                lbl_availerror.Text = "";
            }

        }
        public string createTransaction(string crypto)
        {
            Root root = new Root();
            var waddress = string.Empty;
            var APIkey = "ae57c39bb8e962e6843a0f671a1244a4682e208a";
            var result = "";
            try
            {
                var url = "https://rest.cryptoapis.io/wallet-as-a-service/wallets/62cf854e5f15ac0007749f4d/bitcoin/testnet/transaction-requests?context=yourExampleString";

                var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                httpRequest.Method = "POST";

                httpRequest.ContentType = "application/json";
                httpRequest.Headers["X-API-Key"] = "ae57c39bb8e962e6843a0f671a1244a4682e208a";
                waddress = tb_address.Text.ToString();
                Root dataroot = new Root();
                dataroot.context = "yourExampleString";
                Data data = new Data();
                Item item = new Item();
                item.feePriority = "standard";
                item.prepareStrategy = "minimize-dust";
                item.note = "yourAdditionalInformationhere";
                Recipient rec = new Recipient();
                rec.address = waddress;
                rec.amount = tb_withdrawamt.Text.ToString();
                rec.address = tb_address.Text.ToString();
                item.recipients = new List<Recipient>();
                item.recipients.Add(rec);
                data.item = item;
                dataroot.data = data;
                var json = JsonConvert.SerializeObject(dataroot);
                var idata = json;
                System.Diagnostics.Debug.WriteLine("testing");
                System.Diagnostics.Debug.WriteLine(json);
                System.Diagnostics.Debug.WriteLine(idata);
                var sdata = @"{""context"":""yourExampleString"",""data"":{""item"":{""feePriority"":""standard"",""note"":""yourAdditionalInformationhere"",""prepareStrategy"":""minimize-dust"",""recipients"":[{""address"":""2MtzNEqm2D9jcbPJ5mW7Z3AUNwqt3afZH66"",""amount"":""0.000567""}]}}}";
                System.Diagnostics.Debug.WriteLine(sdata);

                using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                {
                    streamWriter.Write(idata);
                }


                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }

                Console.WriteLine(httpResponse.StatusCode);

            }
            catch (WebException ex)
            {
                waddress = ex.Message;
            }
            return result;
        }


        protected void btn_withdraw_Click(object sender, EventArgs e)
        {
            var crypto = ddl_cryptos.SelectedValue;
            var pair = mapcrypto.First(p => p.Key == crypto);
            string returned = String.Empty;
            Root root = null;
            returned = createTransaction(pair.Value);
            System.Diagnostics.Debug.WriteLine("yea?");
            System.Diagnostics.Debug.WriteLine(returned);
            root = JsonConvert.DeserializeObject<Root>(returned);
            if (returned != "")
            {
                lbl_success.Text = "Withdrawal successful!";
                balances withdrawbal = new balances();
                int result = 0;
                string email = (string)(context.Session["email"]);
                result += withdrawbal.subtractBalance(email, Convert.ToDecimal(tb_withdrawamt.Text.ToString()), ddl_cryptos.SelectedValue.ToString());
                Transaction tx = new Transaction();
                tx.createTransaction(DateTime.Now, "Withdrawal", ddl_cryptos.SelectedValue, Convert.ToDecimal(tb_withdrawamt.Text.ToString()), "complete", email);
            }
        }
    }
}