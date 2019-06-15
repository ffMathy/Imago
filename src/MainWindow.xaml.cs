using ShareX.ScreenCaptureLib;
using ShareX.UploadersLib.ImageUploaders;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows;

namespace Imago
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (var image = RegionCaptureTasks.GetRegionImage(new RegionCaptureOptions()
            {
                DetectWindows = true
            }))
            {
                var jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                image.Save("upload.jpg", jpgEncoder, new EncoderParameters(1) {
                    Param = new [] {
                        new EncoderParameter(Encoder.Quality, 100L)
                    }
                });
            }

            var imgur = new Imgur(new ShareX.UploadersLib.OAuth2Info("81d370264718197", ""));
            using (var image = Image.FromFile("upload.jpg"))
            {
                var result = imgur.UploadImage(image, "upload.jpg");
                var uri = new Uri(result.URL);
                var finalUri = new Uri(uri.Scheme + "://i." + uri.Host + uri.AbsolutePath + ".jpg");
                Process.Start(finalUri.ToString());
            }
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }
}
