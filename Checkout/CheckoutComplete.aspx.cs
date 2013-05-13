﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QsSpyShop.Models;

namespace QsSpyShop.Checkout
{
    public partial class CheckoutComplete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verify user has completed the checkout process.
                if (Session["userCheckoutCompleted"] != "true")
                {
                    Session["userCheckoutCompleted"] = "";
                    Response.Redirect("CheckoutError.aspx?" + "Desc=Unvalidated%20Checkout.");
                }

                NVPAPICaller payPalCaller = new NVPAPICaller();

                string retMsg = "";
                string token = "";
                string finalPaymentAmount = "";
                string PayerID = "";
                NVPCodec decoder = new NVPCodec();

                token = Session["token"].ToString();
                PayerID = Session["payerId"].ToString();
                finalPaymentAmount = Session["payment_amt"].ToString();

                bool ret = payPalCaller.DoCheckoutPayment(finalPaymentAmount, token, PayerID, ref decoder, ref retMsg);
                if (ret)
                {
                    // Retrieve PayPal confirmation value.
                    string PaymentConfirmation = decoder["PAYMENTINFO_0_TRANSACTIONID"].ToString();
                    TransactionId.Text = PaymentConfirmation;


                    ProductContext _db = new ProductContext();
                    // Get the current order id.
                    int currentOrderId = -1;
                    if (Session["currentOrderId"] != "")
                    {
                        currentOrderId = Convert.ToInt32(Session["currentOrderID"]);
                    }
                    Order myCurrentOrder;
                    if (currentOrderId >= 0)
                    {
                        // Get the order based on order id.
                        myCurrentOrder = _db.Orders.Single(o => o.OrderId == currentOrderId);
                        // Update the order to reflect payment has been completed.
                        myCurrentOrder.PaymentTransactionId = PaymentConfirmation;
                        // Save to DB.
                        _db.SaveChanges();
                    }

                    // Clear shopping cart.
                    QsSpyShop.Logic.ShoppingCartActions usersShoppingCart =
                        new QsSpyShop.Logic.ShoppingCartActions();
                    usersShoppingCart.EmptyCart();

                    // Clear order id.
                    Session["currentOrderId"] = "";
                }
                else
                {
                    Response.Redirect("CheckoutError.aspx?" + retMsg);
                }
            }
        }

        protected void Continue_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}