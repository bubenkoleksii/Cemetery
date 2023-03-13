using Cemetery.DL;
using Cemetery.Models.Request;

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
}
