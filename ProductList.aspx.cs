﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QsSpyShop.Models;
using System.Web.ModelBinding;

namespace QsSpyShop
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Product> GetProducts(
                                [QueryString("id")] int? categoryId,
                                [RouteData] string categoryName)
        {
            var _db = new QsSpyShop.Models.ProductContext();
            IQueryable<Product> query = _db.Products;

            if (categoryId.HasValue && categoryId > 0)
            {
                query = query.Where(p => p.CategoryID == categoryId);
            }

            if (!String.IsNullOrEmpty(categoryName))
            {
                query = query.Where(p =>
                                    String.Compare(p.Category.CategoryName,
                                    categoryName) == 0);
            }
            return query;
        }
    }
}