using System.Drawing;

namespace VendingMachine.Services;

public static class ImageConvertor
{
    public static string ConvertImageToBase(string path)
    {
        return Convert.ToBase64String(File.ReadAllBytes(path));
    }
    
    public static Image ConvertToImage(string base64)
    {
        return Image.FromStream(new MemoryStream(Convert.FromBase64String(base64)));
    }
}