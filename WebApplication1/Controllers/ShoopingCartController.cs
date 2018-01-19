using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;


using WebApplication1.Library.DAL;
using WebApplication1.Library;
namespace WebApplication1.Controllers
{
    public class ShoopingCartController : Controller
    {
        public IActionResult Index()
        {
            List<Product> uList = new List<Product>();
            uList = ProductDAL.GetAllProduct();
            List<ProductModel> tempList = null;

            if (uList != null && uList.Count > 0)
            {
                tempList = new List<ProductModel>();
                foreach (Product pObj in uList)
                {
                    ProductModel tempProduct = new ProductModel();
                    tempProduct.ID = pObj.ID;
                    tempProduct.ProductName = pObj.ProductName;
                    tempProduct.ProductPrice = pObj.ProductPrice;
                    tempList.Add(tempProduct);
                }

            }
            return View(tempList);
        }

        public IActionResult Create()
        {

            return View();
        }
        public IActionResult Edit(int id)
        {          
            List<Product> list = new List<Product>();
            list = ProductDAL.GetById(id);
            List<ProductModel> tempList = null;
            if (list != null && list.Count > 0)
            {
                ProductModel productModel = new ProductModel();
                foreach (Product item in list)
                {
                    tempList = new List<ProductModel>();
                    productModel.ID = item.ID;
                    productModel.ProductName = item.ProductName;
                    productModel.ProductPrice = item.ProductPrice;
                    productModel.ProductDetails = item.ProductDetails;
                    tempList.Add(productModel);
                    ViewBag.product = tempList;
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Update(ProductModel productModel)
        {
            Product product = new Product();
            product.ID = productModel.ID;
            product.ProductName = productModel.ProductName;
            product.ProductPrice = productModel.ProductPrice;
            product.ProductDetails = productModel.ProductDetails;
            ProductDAL.UpdateProduct(product);
            return RedirectToAction("Index");
        }

        public IActionResult SaveProduct( ProductModel ProModel)
        {
            Product PROBJ = new Product();
            PROBJ.ID = ProModel.ID;
            PROBJ.ProductName = ProModel.ProductName;
            PROBJ.ProductPrice = ProModel.ProductPrice;
            PROBJ.ProductDetails = ProModel.ProductDetails;
            ProductDAL.InsertProduct(PROBJ);
            return View(ProModel);

        }
        public IActionResult Delete(int id)
        {
            ProductDAL.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
