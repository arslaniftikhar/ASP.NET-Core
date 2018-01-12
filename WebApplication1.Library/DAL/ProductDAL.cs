using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace WebApplication1.Library.DAL
{
  public static class ProductDAL
    {

     public static  List<Product> GetAllProduct()
        {

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-264EDV0;initial Catalog=ClassPractice; user id=dbo; Password=abc123;");

            SqlCommand cmd = new SqlCommand("select * from Product;", con);

            List<Product> productList = new List<Product>();
            con.Open();

            using (con)
            {

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {


                    while (dr.Read())
                    {
                        
                        Product obj = new Product();

                        obj.ID = Convert.ToInt32(dr[0]);
                        obj.ProductName = Convert.ToString(dr["ProductName"]);
                        obj.ProductPrice = Convert.ToInt32(dr["price"]);

                        obj.Discription = Convert.ToString(dr["discription"]); 

                        productList.Add(obj);
                    }

                    productList.TrimExcess();
                }

                return productList;


            }

        }

        public static void InsertProduct( Product p)
        {
           
         
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-IH19O78;initial Catalog=UEBSITSectionB; user id=sa; Password=abc123;");

                SqlCommand cmd = new SqlCommand("insert into Product (ProductName,price,Discription) values (@proName,@pPrice,@Discription);", con);


                con.Open();

                using (con)
                {

                cmd.Parameters.AddWithValue("@proName", p.ProductName);
                cmd.Parameters.AddWithValue("@pPrice", p.ProductPrice);
                cmd.Parameters.AddWithValue("@Discription", p.Discription);

                cmd.ExecuteNonQuery();


                }

           



        }
    }


}