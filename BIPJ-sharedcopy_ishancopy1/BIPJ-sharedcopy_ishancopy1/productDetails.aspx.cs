using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIPJ_sharedcopy_ishancopy1
{
    public partial class productDetails : System.Web.UI.Page
    {
        Product prod = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Product aProd = new Product();
            // Get Product ID from querystring
            string prodID = Request.QueryString["ProdID"].ToString();
            prod = aProd.getProduct(prodID);

            lbl_ProdName.Text = prod.Product_Name;
            lbl_ProdDesc.Text = prod.Product_Desc;
            lbl_Price.Text = prod.Unit_Price.ToString("c");
            img_Product.ImageUrl = "~\\Images\\" + prod.Product_Image;

            lbl_ProdID.Text = prodID.ToString();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string iProductID = prod.Product_ID.ToString();
            ShoppingCart.Instance.AddItem(iProductID, prod);
            Response.Redirect("ViewCart.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("products.aspx");
        }

        protected void purchase_Click(object sender, EventArgs e)
        {
            Response.Redirect("cards6.aspx");
        }

        protected void Button9384_Click(object sender, EventArgs e)
        {
            Response.Redirect("cards5.aspx");
        }
    }
}
