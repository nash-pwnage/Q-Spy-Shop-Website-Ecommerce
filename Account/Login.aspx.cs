using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QsSpyShop.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];

            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LoginCtrl_LoggedIn(object sender, EventArgs e)
        {
            QsSpyShop.Logic.ShoppingCartActions usersShoppingCart = new QsSpyShop.Logic.ShoppingCartActions();
            String cartId = usersShoppingCart.GetCartId();
            usersShoppingCart.MigrateCart(cartId, User.Identity.Name.ToString());
        }
    }
}