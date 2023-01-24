using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIPJ_sharedcopy_ishancopy1
{
    public class ShoppingCartItem
    {
        public int Quantity { get; set; }

        private string _ItemID;
        public string ItemID
        {
            get { return _ItemID; }
            set { _ItemID = value; }
        }

        private string _ItemName;
        public string Product_Name
        {
            get { return _ItemName; }
            set { _ItemName = value; }
        }

        private string _ItemDesc;
        public string Product_Desc
        {
            get { return _ItemDesc; }
            set { _ItemDesc = value; }

        }

        private decimal _ItemPrice;
        public decimal Product_Price
        {
            get { return _ItemPrice; }
            set { _ItemPrice = value; }
        }

        public decimal TotalPrice
        {
            get { return Product_Price * Quantity; }
        }

        public ShoppingCartItem(string productID)
        {
            this.ItemID = productID;
        }

        public ShoppingCartItem(string productID, Product prod)
        {
            this.ItemID = productID;
            this.Product_Name = prod.Product_Name;
            this.Product_Desc = prod.Product_Desc;
            this.Product_Price = prod.Unit_Price; ;

        }

        public ShoppingCartItem(string productID, string productName, string productDesc, decimal productPrice)
        {
            this.ItemID = productID;
            this.Product_Name = productName;
            this.Product_Desc = productDesc;
            this.Product_Price = productPrice;

        }

        public bool Equals(ShoppingCartItem anItem)
        {
            return anItem.ItemID == this.ItemID;
        }

        //public bool Equals(ShoppingCartItem product)
        //{
        //    return product.ItemID == this.ItemID;
        //}
    }
}
