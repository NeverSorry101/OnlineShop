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
        //private static string connectionString = "Data Source=DESKTOP-TTMI49C\\SQLEXPRESS;Initial Catalog=DB_1;Integrated Security=True;";
        private static string connectionString = "Server=V-SQLSRV01;Database=_Minisini;User Id=minidevelopment;Password=minidevelopment;";
        public static void CreateTables()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            using (conn)
            {
                conn.Open();
                SqlTransaction sqlTransaction = conn.BeginTransaction();
                try
                {
                    string query = "CREATE TABLE Meta (\r\nid INT PRIMARY KEY IDENTITY(1,1),\r\ncreatedAt DATETIME,\r\nupdatedAt DATETIME,\r\nbarcode NVARCHAR(50),\r\nqrCode NVARCHAR(50)\r\n);\r\n\r\nCREATE TABLE Dimensions (\r\nid INT PRIMARY KEY IDENTITY(1,1),\r\nwidth FLOAT,\r\nheight FLOAT,\r\ndepth FLOAT\r\n);\r\n\r\nCREATE TABLE Product (   id INT PRIMARY KEY IDENTITY(1,1),\r\ntitle NVARCHAR(255),\r\ndescription NVARCHAR(MAX),\r\ncategory NVARCHAR(255),\r\nprice FLOAT, \r\ndiscountPercentage FLOAT,\r\nrating FLOAT, \r\nstock INT, \r\nbrand NVARCHAR(255),\r\nsku NVARCHAR(50),\r\nweight INT,\r\nwarrantyInformation NVARCHAR(MAX),\r\nshippingInformation NVARCHAR(MAX), \r\navailabilityStatus NVARCHAR(50),\r\nreturnPolicy NVARCHAR(MAX),\r\nminimumOrderQuantity INT,\r\nthumbnail NVARCHAR(MAX), \r\nmetaId INT,\r\ndimensionsId INT,\r\nFOREIGN KEY (metaId) REFERENCES Meta(id),\r\nFOREIGN KEY (dimensionsId) REFERENCES Dimensions(id));\r\n\r\nCREATE TABLE Review (\r\nid INT PRIMARY KEY IDENTITY(1,1),\r\nproductId INT,\r\nrating INT,\r\ncomment NVARCHAR(MAX),\r\ndate DATETIME,\r\nreviewerName NVARCHAR(255),\r\nreviewerEmail NVARCHAR(255),\r\nFOREIGN KEY (productId) REFERENCES Product(id)\r\n);\r\n\r\n\r\nCREATE TABLE ProductTags (\r\nproductId INT,\r\ntag NVARCHAR(255),\r\nPRIMARY KEY (productId, tag),\r\nFOREIGN KEY (productId) REFERENCES Product(id)\r\n);\r\nCREATE TABLE ProductImages (\r\nid INT PRIMARY KEY IDENTITY(1,1),\r\nproductId INT,    \r\nimageUrl NVARCHAR(MAX), \r\nFOREIGN KEY (productId) REFERENCES Product(id));";
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
