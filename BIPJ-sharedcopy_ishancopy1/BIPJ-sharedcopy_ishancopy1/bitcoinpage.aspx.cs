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
    public partial class bitcoinpage : System.Web.UI.Page
    {
        HttpContext context = HttpContext.Current;
        decimal BTCbal = 0;

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
        }

        public class cryptoprices
        {
            public string USD { get; set; }

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

    }
}


