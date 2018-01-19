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
            DatabaseClass databaseClass = new DatabaseClass();
            
            var sql = "select * from Products;";
            databaseClass.Query(sql);
            List<Product> productList = new List<Product>();
            databaseClass.sqlConnection.Open();

            using (databaseClass.sqlConnection)
            {

                SqlDataReader dr = databaseClass.sqlCommand.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {                        
                        Product obj = new Product();

                        obj.ID = Convert.ToInt32(dr[0]);
                        obj.ProductName = Convert.ToString(dr[1]);
                        obj.ProductPrice = Convert.ToInt32(dr[2]);
                        obj.ProductDetails = Convert.ToString(dr[3]); 
                        productList.Add(obj);
                    }
                    productList.TrimExcess();
                }
                return productList;
            }
        }
        public static List<Product> GetById(int id)
        {
            DatabaseClass databaseClass = new DatabaseClass();
            var sql = "SELECT * FROM Products WHERE Id=@id";  
            databaseClass.Query(sql);
            List<Product> productList = new List<Product>();
            //Product product = new Product();
            databaseClass.sqlConnection.Open();
            using (databaseClass.sqlConnection)
            {
                databaseClass.sqlCommand.Parameters.AddWithValue("@id", id);
                SqlDataReader dataReader = databaseClass.sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Product product = new Product();
                        product.ID = Convert.ToInt32(dataReader[0]);
                        product.ProductName = Convert.ToString(dataReader[1]);
                        product.ProductPrice = Convert.ToInt32(dataReader[2]);
                        product.ProductDetails = Convert.ToString(dataReader[3]);
                        productList.Add(product);
                    }
                    productList.TrimExcess();
                }
                
            }
            return productList;
        }
        public static void InsertProduct(Product p)
        {
            DatabaseClass databaseClass = new DatabaseClass();
            var sql = "insert into Products (Id, ProductName,ProductPrice,ProductDetails) values (@id, @proName,@pPrice,@Discription);";
            databaseClass.Query(sql);
            databaseClass.sqlConnection.Open();

            using (databaseClass.sqlConnection)
            {
                    databaseClass.sqlCommand.Parameters.AddWithValue("@id", p.ID);
                    databaseClass.sqlCommand.Parameters.AddWithValue("@proName", p.ProductName);
                    databaseClass.sqlCommand.Parameters.AddWithValue("@pPrice", p.ProductPrice);
                    databaseClass.sqlCommand.Parameters.AddWithValue("@Discription", p.ProductDetails);
                    databaseClass.sqlCommand.ExecuteNonQuery();
            }
        }

        public static void UpdateProduct(Product product)
        {
            DatabaseClass databaseClass = new DatabaseClass();

            var sql = "UPDATE Products SET ProductName = @name, ProductPrice = @price,ProductDetails = @details WHERE Id = @id; ";
            databaseClass.Query(sql);
            databaseClass.sqlConnection.Open();
            using (databaseClass.sqlConnection)
            {
                databaseClass.sqlCommand.Parameters.AddWithValue("@name", product.ProductName);
                databaseClass.sqlCommand.Parameters.AddWithValue("@price", product.ProductPrice);
                databaseClass.sqlCommand.Parameters.AddWithValue("@details", product.ProductDetails);
                databaseClass.sqlCommand.Parameters.AddWithValue("@id", product.ID);
                databaseClass.sqlCommand.ExecuteNonQuery();
            }
        }

        public static void Delete(int id)
        {
            DatabaseClass db = new DatabaseClass();
            var sql = "Delete From Products WHERE Id=@id";
            db.Query(sql);
            db.sqlConnection.Open();
            using (db.sqlConnection)
            {
                db.sqlCommand.Parameters.AddWithValue("@id", id);
                db.sqlCommand.ExecuteNonQuery();
            }

        }
    }


}