using Cemetery.Models.Request;
using Cemetery.Models.Response;
using Microsoft.Data.SqlClient;

namespace Cemetery.DL;

public static class CemeteryRepository
{
    public static List<CemeteryResponse> GetAllCemeteries()
    {
        try
        {
            var queryString = "SELECT * FROM Cemetery";
            var command = new SqlCommand(queryString, Db.GetConnectionString());

            var cemeteriesResponse = new List<CemeteryResponse>();

            Db.OpenConnection();

            using (command)
            {
                var reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        var cemeteryResponse = new CemeteryResponse
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Address = reader.GetString(reader.GetOrdinal("Address")),
                            City = reader.GetString(reader.GetOrdinal("City")),
                            CountOfBurial = reader.GetInt32(reader.GetOrdinal("CountOfBurial"))
                        };

                        cemeteriesResponse.Add(cemeteryResponse);
                    }
                }
            }

            Db.CloseConnection();

            return cemeteriesResponse;
        }
        catch
        {
            throw new Exception("Cannot get cemeteries from database");
        }
    }

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