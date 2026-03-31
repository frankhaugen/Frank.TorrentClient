using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Frank.TorrentClient.Gui3.Extensions;

public static class ByteExtensions
{
    public static Image ToImage(this byte[]? bytes)
    {
        var image = new Image();
        if (bytes == null || bytes.Length < 1) return image;

        var bitmapImage = new BitmapImage();
        var stream = new MemoryStream(bytes);

        bitmapImage.BeginInit();
        bitmapImage.StreamSource = stream;
        bitmapImage.EndInit();

        image.Source = bitmapImage;
        return image;
    }
}