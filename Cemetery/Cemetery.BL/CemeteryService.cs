using Cemetery.DL;
using Cemetery.Models.Request;
using Cemetery.Models.Response;

namespace Cemetery.BL;

public static class CemeteryService
{
    public static void AddCemetery(CemeteryRequest cemeteryRequest)
    {
        try
        { 
            CemeteryRepository.InsertCemetery(cemeteryRequest);
        }
        catch
        {
            throw new Exception("Cannot insert cemetery to database");
        }
    }

    public static List<CemeteryResponse> GetAllCemeteries()
    {
        try
        {
            var cemeteries = CemeteryRepository.GetAllCemeteries();
            return cemeteries;
        }
        catch
        {
            throw new Exception("Cannot get cemeteries from database");
        }
    }
}
