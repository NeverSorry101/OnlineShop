using OnlineShop.API;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Classi;

namespace OnlineShop
{
    internal class Sql
    {
        private static string connectionString = "Data Source=DESKTOP-TTMI49C\\SQLEXPRESS;Initial Catalog=DB_1;Integrated Security=True;";

        public static void CreateTables()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            using (conn)
            {
                conn.Open();
                SqlTransaction sqlTransaction = conn.BeginTransaction();
                try
                {
                    string query = "CREATE TABLE Product (\r\n    id INT PRIMARY KEY IDENTITY(1,1),\r\n    title NVARCHAR(255),\r\n    description NVARCHAR(MAX),\r\n    category NVARCHAR(255),\r\n    price FLOAT,\r\n    discountPercentage FLOAT,\r\n    rating FLOAT,\r\n    stock INT,\r\n    brand NVARCHAR(255),\r\n    sku NVARCHAR(50),\r\n    weight INT,\r\n    warrantyInformation NVARCHAR(MAX),\r\n    shippingInformation NVARCHAR(MAX),\r\n    availabilityStatus NVARCHAR(50),\r\n    returnPolicy NVARCHAR(MAX),\r\n    minimumOrderQuantity INT,\r\n    thumbnail NVARCHAR(MAX),\r\n    metaId INT,\r\n    dimensionsId INT,\r\n    FOREIGN KEY (metaId) REFERENCES Meta(id),\r\n    FOREIGN KEY (dimensionsId) REFERENCES Dimensions(id)\r\n);\r\nCREATE TABLE Review (\r\n    id INT PRIMARY KEY IDENTITY(1,1),\r\n    productId INT,\r\n    rating INT,\r\n    comment NVARCHAR(MAX),\r\n    date DATETIME,\r\n    reviewerName NVARCHAR(255),\r\n    reviewerEmail NVARCHAR(255),\r\n    FOREIGN KEY (productId) REFERENCES Product(id)\r\n);\r\nCREATE TABLE Meta (\r\n    id INT PRIMARY KEY IDENTITY(1,1),\r\n    createdAt DATETIME,\r\n    updatedAt DATETIME,\r\n    barcode NVARCHAR(50),\r\n    qrCode NVARCHAR(50)\r\n);\r\nCREATE TABLE Dimensions (\r\n    id INT PRIMARY KEY IDENTITY(1,1),\r\n    width FLOAT,\r\n    height FLOAT,\r\n    depth FLOAT\r\n);\r\nCREATE TABLE ProductTags (\r\n    productId INT,\r\n    tag NVARCHAR(255),\r\n    PRIMARY KEY (productId, tag),\r\n    FOREIGN KEY (productId) REFERENCES Product(id)\r\n);\r\nCREATE TABLE ProductImages (\r\n    id INT PRIMARY KEY IDENTITY(1,1),\r\n    productId INT,\r\n    imageUrl NVARCHAR(MAX),\r\n    FOREIGN KEY (productId) REFERENCES Product(id)\r\n);";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Transaction = sqlTransaction;
                    cmd.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    Console.WriteLine(ex.Message);
                }

            }


        }

        public static void UploadData(List<Product> dati)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            using (conn)
            {
                conn.Open();
                SqlTransaction sqlTransaction = conn.BeginTransaction();
                try
                {
                    string query = "";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Transaction = sqlTransaction;
                    cmd.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    Console.WriteLine(ex.Message);
                }

            }
        }

    }
}
