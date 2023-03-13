using Cemetery.Models.Request;
using Microsoft.Data.SqlClient;

namespace Cemetery.DL;

public static class CemeteryRepository
{
    public static void InsertCemetery(CemeteryRequest cemeteryRequest)
    {
        try
        {
            var cemeteryId = Guid.NewGuid().ToString();
            var queryString =
                $"INSERT INTO Cemetery (Id, [Name], [Address], City, [Year], CountOfBurial) VALUES (N'{cemeteryId}', N'{cemeteryRequest.Name}', N'{cemeteryRequest.Address}', N'{cemeteryRequest.City}', {cemeteryRequest.Year}, {cemeteryRequest.CountOfBurial});";
            var command = new SqlCommand(queryString, Db.GetConnectionString());

            Db.OpenConnection();
            command.ExecuteNonQuery();
            Db.CloseConnection();
        }
        catch
        {
            throw new Exception("Cannot insert cemetery to database");
        }
    }
}