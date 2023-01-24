using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BIPJ_sharedcopy_ishancopy1
{
    public class Debit_Card
    {

        //Private string _connStr = Properties.Settings.Default.DBConnStr;

        //System.Configuration.ConnectionStringSettings _connStr;
        string _connStr = ConfigurationManager.ConnectionStrings["debitcard"].ConnectionString;
        private string _cardID = null;
        private string _cardName = string.Empty;
        private string _cardDesc = ""; // this is another way to specify empty string
        private decimal _subscriptionCost = 0;
        private string _cardImage = "";

        // Default constructor
        public Debit_Card()
        {
        }

        // Constructor that take in all data required to build a Debit Card object
        public Debit_Card(string cardID, string cardName, string cardDesc,
                       decimal subscriptionCost, string cardImage)
        {
            _cardID = cardID;
            _cardName = cardName;
            _cardDesc = cardDesc;
            _subscriptionCost = subscriptionCost;
            _cardImage = cardImage;
        }

        // Constructor that take in all except Debit Card ID
        public Debit_Card(string cardName, string cardDesc,
                       decimal subscriptionCost, string cardImage)
            : this(null, cardName, cardDesc, subscriptionCost, cardImage)
        {
        }

        // Constructor that take in only Debit Card ID. The other attributes will be set to 0 or empty.
        public Debit_Card(string cardID)
            : this(cardID, "", "", 0, "")
        {
        }

        // Get/Set the attributes of the Debit Card object.
        // Note the attribute name (e.g. card_ID) is same as the actual database field name.
        // This is for ease of referencing.
        public string Card_ID
        {
            get { return _cardID; }
            set { _cardID = value; }
        }
        public string Card_Name
        {
            get { return _cardName; }
            set { _cardName = value; }
        }
        public string Card_Desc
        {
            get { return _cardDesc; }
            set { _cardDesc = value; }
        }
        public decimal Subscription_Cost
        {
            get { return _subscriptionCost; }
            set { _subscriptionCost = value; }
        }
        public string Card_Image
        {
            get { return _cardImage; }
            set { _cardImage = value; }
        }



        //Below as the Class methods for some DB operations. 
        public Debit_Card getCard(string cardID)
        {

            Debit_Card cardDetail = null;

            string card_Name, card_Desc, Card_Image;
            decimal subscription_Cost;

            string queryStr = "SELECT * FROM Cards WHERE Card_ID = @CardID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@CardID", cardID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                card_Name = dr["Card_Name"].ToString();
                card_Desc = dr["Card_Desc"].ToString();
                Card_Image = dr["Card_Image"].ToString();
                subscription_Cost = decimal.Parse(dr["Subscription_Cost"].ToString());

                cardDetail = new Debit_Card(cardID, card_Name, card_Desc, subscription_Cost, Card_Image);
            }
            else
            {
                cardDetail = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return cardDetail;
        }

        public List<Debit_Card> getCardAll()
        {
            List<Debit_Card> cardList = new List<Debit_Card>();

            string card_Name, card_Desc, Card_Image, card_ID;
            decimal subscription_Cost;

            string queryStr = "SELECT * FROM Cards Order By Card_Name";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                card_ID = dr["Card_ID"].ToString();
                card_Name = dr["Card_Name"].ToString();
                card_Desc = dr["Card_Desc"].ToString();
                Card_Image = dr["Card_Image"].ToString();
                subscription_Cost = decimal.Parse(dr["Subscription_Cost"].ToString());
                Debit_Card a = new Debit_Card(card_ID, card_Name, card_Desc, subscription_Cost, Card_Image);
                cardList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return cardList;
        }

        //public int CardInsert()
        //{

        //}//end Insert

        //public int CardDelete(decimal ID)
        //{

        //}//end Delete

        //public int CardUpdate(string cId, string cName, decimal cSubscriptionCost)
        //{

        //}//end Update


    }
}