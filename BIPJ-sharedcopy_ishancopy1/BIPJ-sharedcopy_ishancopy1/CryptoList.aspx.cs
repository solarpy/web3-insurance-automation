using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.IO;
using System.Net;

namespace BIPJ_sharedcopy_ishancopy1
{
    public partial class CryptoList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("crypto");
            dt.Columns.Add("logo");
            dt.Columns.Add("price");
            var result = string.Empty;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://min-api.cryptocompare.com/data/top/totalvolfull?limit=10&tsym=USD");
            httpWebRequest.Method = "GET";
            httpWebRequest.KeepAlive = false;
            httpWebRequest.Accept = "text/json";
            string value = string.Empty;
            var placeholderobj = new JObject();

            httpWebRequest.ContentType = "application/json";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))

            {

                result = streamReader.ReadToEnd();
                var bigdict = JObject.Parse(result);
                for (int i = 0; i < 10; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["crypto"] = bigdict["Data"][i]["CoinInfo"]["Name"].ToString();
                    dr["logo"] = "https://www.cryptocompare.com" + bigdict["Data"][i]["CoinInfo"]["ImageUrl"].ToString();
                    dr["price"] = bigdict["Data"][i]["RAW"]["USD"]["PRICE"].ToString();
                    lbl_Test.Text = bigdict["Data"][i]["RAW"]["USD"]["PRICE"].ToString();
                    dt.Rows.Add(dr);
                }
                placeholderobj = bigdict;

            }
            DataList2.DataSource = dt;
            DataList2.DataBind();

        }

    }
}