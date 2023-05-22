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

    public static void AddImage(string media, Guid id)
    {
        var mediaExtensions = new List<string> { ".jpg", ".png", ".jpeg", ".gif", ".webp", ".svg" };

        var extension = Path.GetExtension(media).ToLowerInvariant();

        if (string.IsNullOrEmpty(extension) || !mediaExtensions.Contains(extension))
            throw new ArgumentException("Невалідний формат");

        var fileName = MediumRepository.AddMedium(media);
        CemeteryRepository.AddImage(fileName, id);
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
