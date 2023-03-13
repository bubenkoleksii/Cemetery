using System.Data;
using Microsoft.Data.SqlClient;

namespace Cemetery.DL;

public static class Db
{
    private static readonly SqlConnection SqlConnection = new(@"Server = LOCALHOST;Database=Cemetery;Trusted_Connection=True;TrustServerCertificate=True;");

    public static void OpenConnection()
    {
        if (SqlConnection.State == ConnectionState.Closed)
        {
            SqlConnection.Open();
        }
    }

    public static void CloseConnection()
    {
        if (SqlConnection.State == ConnectionState.Open)
        {
            SqlConnection.Close();
        }
    }

    public static SqlConnection GetConnectionString()
    {
        return SqlConnection;
    }
}