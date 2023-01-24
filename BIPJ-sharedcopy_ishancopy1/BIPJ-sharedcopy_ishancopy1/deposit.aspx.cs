using iTextSharp.text.pdf.qrcode;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Timers;
using System.Web;


namespace BIPJ_sharedcopy_ishancopy1
{
    public partial class deposit : System.Web.UI.Page
    {
        HttpContext context = HttpContext.Current;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Root initdata = new Root();
            //var stringaddress = string.Empty;
            //initdata = this.depositAddress();
            //foreach (Item i in initdata.data.items)
            //{
            //    lbl_Address.Text = i.address.ToString();
            //}
            //timer = new System.Timers.Timer(2000);

            //timer.Interval = 3600000;
            //timer.Enabled = true;
        }
        private static System.Timers.Timer timer;


        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("wallet.aspx");
        }
        public class Data
        {
            public int limit { get; set; }
            public int offset { get; set; }
            public int total { get; set; }
            public List<Item> items { get; set; }
            public Item item { get; set; }
        }
        public class ConfirmedBalance
        {
            public string amount { get; set; }
            public string unit { get; set; }
        }
        public class Item
        {
            public string address { get; set; }
            public ConfirmedBalance confirmedBalance { get; set; }
            public int createdTimestamp { get; set; }
            public List<object> fungibleTokens { get; set; }
            public string index { get; set; }
            public string label { get; set; }
            public List<object> nonFungibleTokens { get; set; }
        }
        public class Root
        {
            public string apiVersion { get; set; }
            public string requestId { get; set; }
            public string context { get; set; }
            public Data data { get; set; }
        }


        public Root depositAddress()
        {

            var address = string.Empty;
            Root addressdata = null;
            var walletaddress = "62cf854e5f15ac0007749f4d";
            var APIkey = "ae57c39bb8e962e6843a0f671a1244a4682e208a";
            try
            {

                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://rest.cryptoapis.io/v2/wallet-as-a-service/wallets/" + walletaddress + "/bitcoin/testnet/addresses?context=newwwallet");
                httpWebRequest.Method = "Get";
                httpWebRequest.KeepAlive = false;
                httpWebRequest.Accept = "text/json";
                httpWebRequest.Headers.Add("X-API-Key", "ae57c39bb8e962e6843a0f671a1244a4682e208a");
                httpWebRequest.ContentType = "application/json";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))

                {

                    address = streamReader.ReadToEnd();
                    addressdata = JsonConvert.DeserializeObject<Root>(address);

                }
            }
            catch (WebException ex)
            {
                address = ex.Message;
            }
            return addressdata;
        }

        protected void ddl_cryptos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public Root getBalance(string crypto, string address)
        {
            Root addressdata = null;
            var walletaddress = "62cf854e5f15ac0007749f4d";
            var APIkey = "ae57c39bb8e962e6843a0f671a1244a4682e208a";
            try
            {

                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://rest.cryptoapis.io/v2/blockchain-data/" + crypto + "/testnet/addresses/" + address + "?context=yourExampleString");
                httpWebRequest.Method = "Get";
                httpWebRequest.KeepAlive = false;
                httpWebRequest.Accept = "text/json";
                httpWebRequest.Headers.Add("X-API-Key", "ae57c39bb8e962e6843a0f671a1244a4682e208a");


                httpWebRequest.ContentType = "application/json";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))

                {

                    address = streamReader.ReadToEnd();
                    addressdata = JsonConvert.DeserializeObject<Root>(address);

                }
            }
            catch (WebException ex)
            {
                address = ex.Message;
            }
            return addressdata;
        }

        protected void btn_Refresh_Click(object sender, EventArgs e)
        {
            Root balanceRoot = this.getBalance(ddl_cryptos.SelectedValue, lbl_Address.Text);
            lbl_Received.Text = balanceRoot.data.item.confirmedBalance.amount + " " + balanceRoot.data.item.confirmedBalance.unit;
        }

        protected void btn_Confirm_Click(object sender, EventArgs e)
        {
            int result = 0;
            Transaction transaction = new Transaction();
            try
            {
                Root balanceRoot = this.getBalance(ddl_cryptos.SelectedValue, lbl_Address.Text);
                balances updateBal = new balances();
                string email = (string)(context.Session["email"]);
                updateBal.updateBalance(email, Convert.ToDecimal(balanceRoot.data.item.confirmedBalance.amount), balanceRoot.data.item.confirmedBalance.unit);
                if (balanceRoot.data.item.confirmedBalance.amount != "0")
                {
                    result = transaction.createTransaction(DateTime.Now, "deposit", balanceRoot.data.item.confirmedBalance.unit, Convert.ToDecimal(balanceRoot.data.item.confirmedBalance.amount), "approved", email);
                    balanceRoot.data.item.confirmedBalance.amount = "0";
                    Response.Redirect("wallet.aspx");
                }
            }
            catch (Exception ex)
            {
                lbl_Received.Text = ex.ToString();
            }
        }

        protected void btn_Generate_Click(object sender, EventArgs e)
        {
            var crypto = ddl_cryptos.SelectedValue;
            var walletaddress = "62cf854e5f15ac0007749f4d";
            var postRequest = (HttpWebRequest)WebRequest.Create("https://rest.cryptoapis.io/v2/wallet-as-a-service/wallets/" + walletaddress + "/" + crypto + "/testnet/addresses?context=newwwallet");
            postRequest.Method = "Post";
            postRequest.ContentType = "application/json";
            postRequest.Headers.Add("X-API-Key", "ae57c39bb8e962e6843a0f671a1244a4682e208a");
            postRequest.KeepAlive = false;
            postRequest.Credentials = CredentialCache.DefaultCredentials;
            string postData = "{\"context\":\"yourExampleString\",\"data\":{\"item\":{\"label\":\"yourLabelStringHere\"}}}";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            postRequest.ContentLength = byteArray.Length;
            Stream dataStream = postRequest.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length); ;
            dataStream.Close();
            WebResponse response = postRequest.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            reader.Close();
            dataStream.Close();
            response.Close();
            Root newAddress = new Root();
            newAddress = JsonConvert.DeserializeObject<Root>(responseFromServer);
            lbl_Address.Text = newAddress.data.item.address;
            Root balanceRoot = this.getBalance(ddl_cryptos.SelectedValue, newAddress.data.item.address);
            lbl_Received.Text = balanceRoot.data.item.confirmedBalance.amount + " " + balanceRoot.data.item.confirmedBalance.unit;

        }

    }
}


