using ZXing;
using ZXing.Common;
using System.Drawing;
using CEIS400_ECS;

public class Barcode
{
    public string Code { get; private set; }
    public Bitmap BarcodeImage { get; private set; }

    public static Barcode Generate(string inputData)
    {
        string stripped = inputData.Substring(0, 10);
        var instance = new Barcode
        {
            Code = $"{inputData}"
        };

        // Create the writer
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.CODE_128,
            Options = new EncodingOptions
            {
                Width = 300,
                Height = 100,
                Margin = 5
            }
        };

        // Generate the bitmap
        instance.BarcodeImage = writer.Write(instance.Code);

        return instance;
    }
}