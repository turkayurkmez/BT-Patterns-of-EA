using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibility
{
    public class ProductBusiness
    {
        public int Create(string name, decimal price)
        {
            using (var connection = new SqlConnection("Data Source=.;Initial Catalog=SingleResponsibility;Integrated Security=True"))
            {
                using (var command = new SqlCommand("INSERT INTO Products (ProductName, UnitPrice) VALUES (@name,@price)", connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@price", price);
                    connection.Open();
                    var affectedRow = command.ExecuteNonQuery();
                    connection.Close();
                    return affectedRow;
                }
            }
        }
    }
}
