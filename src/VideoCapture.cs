using Imago.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Capture;
using Windows.Graphics.DirectX.Direct3D11;

namespace Imago
{
    class VideoCapture
    {
        private readonly GraphicsCapturePicker picker;
        private readonly IDirect3DDevice device;

        private BasicCapture currentCapture;

        public VideoCapture()
        {
            this.picker = new GraphicsCapturePicker();
            this.device = Direct3D11Helper.CreateDevice();
        }

        public async Task StartAsync()
        {
            var item = await picker.PickSingleItemAsync();
            if (item != null)
            {
                var capture = new BasicCapture(device, item);
                this.currentCapture = capture;

                capture.StartCapture();
            }
        }

        public void Stop()
        {
            currentCapture?.Dispose();
        }
    }
}
