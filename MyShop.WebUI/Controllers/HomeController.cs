﻿using MyShop.Core.Contracts;
using MyShop.Core.Models;
using MyShop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Product> context;
        IRepository<ProductCategory> productCategories;

        public HomeController(IRepository<Product> _context, IRepository<ProductCategory> _productCategories)
        {
            context = _context;
            productCategories = _productCategories;
        }

        public ActionResult Index(string Category=null)
        {
            List<Product> products;
            List<ProductCategory> categories = productCategories.Collection().ToList();

            if (Category == null)
            {
                products = context.Collection().ToList();
            }
            else
            {
                products = context.Collection().Where(p => p.Category == Category).ToList();
            }
            ProductListViewModel model = new ProductListViewModel();
            model.Products = products;
            model.ProductsCategories = categories;

            return View(model);

            //ProductListViewModel model = new ProductListViewModel();
            //List<Product> _products;
            //List<ProductCategory> categories = productCategories.Collection().ToList();

            //if (_Category==null)
            //{
            //    _products = context.Collection().ToList();
            //}
            //else
            //{
            //    _products = context.Collection().Where(p => p.Category == _Category).ToList();
            //}

            //model.Products = _products;
            //model.ProductCategories = categories;
            //return View(model);
        }

        public ActionResult Details(string Id)
        {
            Product product = context.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}