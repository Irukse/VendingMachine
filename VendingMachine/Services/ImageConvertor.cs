using System.Drawing;

namespace VendingMachine.Services;

public static class ImageConvertor
{
    public static byte[] ReadImage(string path)
    {
        var image = File.ReadAllBytes(path);
        return image;
    }

    public static void WriteImage(string path, string name, byte[] image)
    {
        File.WriteAllBytes($"{path}\\{name}", image);
    }
}