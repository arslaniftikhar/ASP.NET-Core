﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication1.Library
{
   public class Product
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        private int productPrice;

        public int ProductPrice
        {
            get { return productPrice; }
            set { productPrice = value; }
        }


        private string discription;

        public string Discription
        {
            get { return discription; }
            set { discription = value; }
        }

        public Product() { }

        public Product(int id, string name, int price, string discription)
        {




        }


    }
}
