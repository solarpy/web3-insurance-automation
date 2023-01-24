using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIPJ_sharedcopy_ishancopy1
{
    public partial class debitcard : System.Web.UI.Page
    {
        Debit_Card aDebit_Card = new Debit_Card();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }
        protected void bind()
        {
            List<Debit_Card> cardList = new List<Debit_Card>();
            cardList = aDebit_Card.getCardAll();
            gvCard.DataSource = cardList;
            gvCard.DataBind();
        }
        protected void gvCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the currently selected row 
            GridViewRow row = gvCard.SelectedRow;

            // Get Card ID from the selected row, which is the 
            // first row, i.e. index 0.
            string cardID = row.Cells[0].Text;

            // Redirect to next page, with the Card Id added to the URL,
            // e.g. ProductDetails.aspx?ProdID=1
            Response.Redirect("debitcardDetails.aspx?cardID=" + cardID);
        }
    }
}