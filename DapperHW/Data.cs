using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace DapperHW
{
    class Data
    {
        private string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=computer;Integrated Security=True";

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>(); // Note: You can skip 'List<Product>' if you specefy this type in right part. 
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                products = db.Query<Product>("SELECT * FROM Product").ToList(); // Note: Try not use select all 
            }
            return products;
        }

        public Product Get(int model)
        {
            Product product = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                product = db.Query<Product>("SELECT * FROM Product WHERE Model = @model", new { model }).FirstOrDefault(); // Note: Why did you create the redundant variebel (Product)?
            }
            return product;
        }

        public void Create(Product product)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Product (Maker, Model, Type) VALUES(@Maker, @Model, @Type); SELECT CAST(SCOPE_IDENTITY() as int)";
                db.Execute(sqlQuery, product);
            }
        }

        public void Update(Product product)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Product SET Maker = @Maker, Type = @Type WHERE Model = @Model";
                db.Execute(sqlQuery, product);
            }
        }

        public void Delete(int model)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Product WHERE Model = @Model";
                db.Execute(sqlQuery, new { model }); // Note: Here you can just insert model without 'new'
            }
        }
    }
}
