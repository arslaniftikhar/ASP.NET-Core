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

        public IActionResult SaveProduct( ProductModel ProModel)
        {
            Product PROBJ = new Product();
            PROBJ.ProductName = ProModel.ProductName;
            PROBJ.ProductPrice = ProModel.ProductPrice;
            PROBJ.Discription = PROBJ.Discription;
            ProductDAL.InsertProduct(PROBJ);
            return View(ProModel);
        }

    }
}
