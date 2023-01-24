using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace BIPJ_sharedcopy_ishancopy1
{
    public partial class wallet : System.Web.UI.Page
    {
        HttpContext context = HttpContext.Current;
        decimal BTCbal = 0;
        DateTime origindate = new DateTime(1970, 1, 1, 0, 0, 0);

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("crypto");
                dt.Columns.Add("logo");
                dt.Columns.Add("tokenamt");
                dt.Columns.Add("total");
                //session email for testing
                string email = (string)(context.Session["email"]);
                List<balances> balList = new List<balances>();
                balances balobj = new balances();
                balList = balobj.getBalancesAll(email);
                foreach (balances bal in balList)
                {
                    DataRow dr = dt.NewRow();
                    dr["crypto"] = bal.crypto;
                    dr["logo"] = bal.crypto.ToLower();
                    dr["tokenamt"] = bal.balance.ToString("G29");
                    BTCbal = bal.balance;
                    cryptoprices dc = this.Prices(bal.crypto);
                    dr["total"] = (bal.balance * Convert.ToDecimal(dc.USD)).ToString("F");
                    dt.Rows.Add(dr);
                }
                DataList1.DataSource = dt;
                DataList1.DataBind();
                DataTable txdt = new DataTable();
                txdt.Clear();
                txdt.Columns.Add("txID");
                txdt.Columns.Add("amount");
                txdt.Columns.Add("time");
                txdt.Columns.Add("type");
                txdt.Columns.Add("asset");
                txdt.Columns.Add("status");
                List<Transaction> txlist = new List<Transaction>();
                Transaction txobj = new Transaction();
                txlist = txobj.getTxAll(email);
                foreach (Transaction tx in txlist)
                {
                    DataRow dr = txdt.NewRow();
                    dr["txID"] = tx.txID;
                    dr["amount"] = tx.amount.ToString("G29");
                    dr["time"] = tx.time.ToString();
                    dr["type"] = tx.type;
                    dr["asset"] = tx.asset;
                    dr["status"] = tx.status;
                    txdt.Rows.Add(dr);

                }
            }
            catch
            {
                Response.Redirect("login.aspx");
            }



            if (!IsPostBack)
            {
                changeText();
            }
        }

        public static Control FindControlRecursive(Control rootControl, string id)
        {
            if (rootControl != null)
            {
                if (rootControl.ID == id)
                {
                    return rootControl;
                }

                for (int i = 0; i < rootControl.Controls.Count; i++)
                {
                    Control child;

                    if ((child = FindControlRecursive(rootControl.Controls[i], id)) != null)
                    {
                        return child;
                    }
                }
            }

            return null;
        }
        protected void changeText()
        {
            //cryptoprices placeh = this.Prices();
            //decimal BTCpricebal = Convert.ToDecimal(placeh.USD) * BTCbal;
            //string hprice = this.hPrices();
            //var jsonprice = new historicalprice();
            //jsonprice = JsonConvert.DeserializeObject<historicalprice>(hprice);


        }
        public class cryptoprices
        {
            public string USD { get; set; }
            public string JPY { get; set; }
            public string EUR { get; set; }

        }

        public class historicalprice
        {

            public BTC BTC { get; set; }


        }
        public class BTC
        {
            public string USD { get; set; }
        }
        public class data
        {
            public item item { get; set; }
        }
        public class item
        {
            public string address { get; set; }
            public int createdTimestamp { get; set; }
            public string label { get; set; }

        }


        public cryptoprices Prices(string cryptoname)
        {
            var crypto = new cryptoprices();
            var result = string.Empty;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://min-api.cryptocompare.com/data/price?fsym=" + cryptoname + "&tsyms=USD,JPY,EUR");
                httpWebRequest.Method = "Get";
                httpWebRequest.KeepAlive = false;
                httpWebRequest.Accept = "text/json";

                httpWebRequest.ContentType = "application/json";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))

                {

                    result = streamReader.ReadToEnd();
                    crypto = JsonConvert.DeserializeObject<cryptoprices>(result);

                }

            }

            catch (WebException ex)

            {

                result = ex.Message;

            }

            return crypto;
        }
        public data depositAddress()
        {
            var address = string.Empty;
            data addressdata = null;
            var APIkey = "ae57c39bb8e962e6843a0f671a1244a4682e208a";
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(" https://rest.cryptoapis.io/v2/wallet-as-a-service/wallets/" + APIkey + "/bitcoin/testnet/addresses?context=yourExampleString");
                httpWebRequest.Method = "Get";
                httpWebRequest.KeepAlive = false;
                httpWebRequest.Accept = "text/json";

                httpWebRequest.ContentType = "application/json";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))

                {

                    address = streamReader.ReadToEnd();
                    addressdata = JsonConvert.DeserializeObject<data>(address);

                }
            }
            catch (WebException ex)
            {
                address = ex.Message;
            }
            return addressdata;
        }
        public string hPrices()
        {
            var hcrypto = new historicalprice();
            var hresult = string.Empty;
            var now = DateTime.Now;
            try
            {
                TimeSpan diff = now.ToUniversalTime() - origindate;
                var histdiff = (long)Math.Floor(diff.TotalSeconds);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://min-api.cryptocompare.com/data/pricehistorical?fsym=BTC&tsyms=USD&ts=" + histdiff);
                httpWebRequest.Method = "Get";
                httpWebRequest.KeepAlive = false;
                httpWebRequest.Accept = "text/json";

                httpWebRequest.ContentType = "application/json";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))

                {

                    hresult = streamReader.ReadToEnd();

                }

            }

            catch (WebException ex)

            {

                hresult = ex.Message;

            }

            return hresult;
        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btn_Deposit_Click(object sender, EventArgs e)
        {
            Response.Redirect("deposit.aspx");
        }

        protected void lb_txid_Click(object sender, EventArgs e)
        {
            string email = (string)(context.Session["email"]);

            txDS.SelectCommand = "SELECT * FROM Transactions WHERE email='" + email + "' ORDER BY txID DESC";
        }
        protected void lb_txid_asc_Click(object sender, EventArgs e)
        {
            string email = (string)(context.Session["email"]);

            txDS.SelectCommand = "SELECT * FROM Transactions WHERE email='" + email + "' ORDER BY txID ASC";
        }

        protected void lb_amount_Click(object sender, EventArgs e)
        {
            string email = (string)(context.Session["email"]);

            txDS.SelectCommand = "SELECT * FROM Transactions WHERE email='" + email + "' ORDER BY amount DESC";
        }
        protected void lb_amount_asc_Click(object sender, EventArgs e)
        {
            string email = (string)(context.Session["email"]);

            txDS.SelectCommand = "SELECT * FROM Transactions WHERE email='" + email + "' ORDER BY amount ASC";
        }
        protected void lb_time_Click(object sender, EventArgs e)
        {
            string email = (string)(context.Session["email"]);

            txDS.SelectCommand = "SELECT * FROM Transactions WHERE email='" + email + "' ORDER BY txID ASC";
        }

        protected void lb_type_Click(object sender, EventArgs e)
        {
            string email = (string)(context.Session["email"]);

            txDS.SelectCommand = "SELECT * FROM Transactions WHERE email='" + email + "' ORDER BY txID ASC";
        }

        protected void lb_asset_Click(object sender, EventArgs e)
        {
            string email = (string)(context.Session["email"]);

            txDS.SelectCommand = "SELECT * FROM Transactions WHERE email='" + email + "' ORDER BY asset DESC";
        }
        protected void lb_asset_asc_Click(object sender, EventArgs e)
        {
            string email = (string)(context.Session["email"]);

            txDS.SelectCommand = "SELECT * FROM Transactions WHERE email='" + email + "' ORDER BY asset ASC";
        }

        protected void btn_Withdraw_Click(object sender, EventArgs e)
        {
            Response.Redirect("withdraw.aspx");
        }
    }

}

