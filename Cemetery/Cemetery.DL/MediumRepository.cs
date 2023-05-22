using System.Drawing;

namespace Cemetery.DL;

public static class MediumRepository
{
    private static string _mediumFolderPath = GetMediaPath();

    public static string AddMedium(string media)
    {
        var imageBytes = File.ReadAllBytes(media);
        
        var extension = Path.GetExtension(media).ToLowerInvariant();
        var fileName = Path.GetRandomFileName();
        var filePath = fileName + extension;

        var fileSavePath = Path.Combine(_mediumFolderPath, filePath);

        using (File.Create(fileSavePath)) { }

        File.WriteAllBytes(fileSavePath, imageBytes);

        return filePath;
    }

    public static void DeleteMedium()
    {
    }

    private static string GetMediaPath()
    {
        var rootFolderPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName).FullName;
        var storageFullPath = Path.Combine(rootFolderPath, "Cemetery.Media");

        return storageFullPath;
    }
}