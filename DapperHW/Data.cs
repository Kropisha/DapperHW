using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace DapperHW
{
    class Data
    {
        string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=computer;Integrated Security=True";
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                products = db.Query<Product>("SELECT * FROM Product").ToList();
            }
            return products;
        }

        public Product Get(int model)
        {
            Product product = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                product = db.Query<Product>("SELECT * FROM Product WHERE Model = @model", new { model }).FirstOrDefault();
            }
            return product;
        }

        public Product Create(Product product)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Product (Maker, Model, Type) VALUES(@Maker, @Model, @Type); SELECT CAST(SCOPE_IDENTITY() as int)";
                int productId = db.Query<int>(sqlQuery, product).FirstOrDefault();
                product.Model = productId;
            }
            return product;
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
                db.Execute(sqlQuery, new { model });
            }
        }
    }
}
