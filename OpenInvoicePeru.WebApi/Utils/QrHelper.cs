using System;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Formats.Png; // For PngEncoder
using ZXing; // General ZXing namespace
using ZXing.QrCode; // For QrCodeEncodingOptions
// Note: We will use fully qualified names for BarcodeWriter to avoid ambiguity.

namespace OpenInvoicePeru.WebApi.Utils
{
    public static class QrHelper
    {
        /// <summary>
        /// Permite generar la imagen para QR en formato PNG.
        /// </summary>
        /// <param name="parameter">Trama a generar</param>
        public static string GenerarImagenQr(string parameter)
        {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));

            // Use the fully qualified name for BarcodeWriter from ZXing.ImageSharp
            var barcodeWriter = new ZXing.ImageSharp.BarcodeWriter<Rgba32>
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions
                {
                    Width = 800,
                    Height = 800
                }
                // Renderer is often inferred or not needed when using the specific BarcodeWriter<T>
            };

            using (var mem = new MemoryStream())
            {
                // The Write method should produce an Image<Rgba32>
                var imagen = barcodeWriter.Write(parameter); 
                imagen.Save(mem, new PngEncoder()); // Use ImageSharp's PngEncoder

                return Convert.ToBase64String(mem.ToArray());
            }
        }
    }
}