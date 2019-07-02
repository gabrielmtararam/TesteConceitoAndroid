using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace PrototypeGuiCompositor30
{
    
    class ImageRender
    {
        private ObservableCollection<IScreen> _screens;
        private int _activeScreen;

        public  ImageRender(ObservableCollection<IScreen> screens, int activeScreen)
        {
            _screens = screens;
            _activeScreen = activeScreen;
        }

        public void RenderActiveImage()
        {
            Canvas canvas = (Canvas)((ObservableCollection<IScreen>)_screens)[_activeScreen].Screen;
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)canvas.RenderSize.Width,
                (int)canvas.RenderSize.Height, 96d, 96d, System.Windows.Media.PixelFormats.Default);
            rtb.Render(canvas);

            var crop = new CroppedBitmap(rtb, new Int32Rect(0, 0, (int)canvas.RenderSize.Width, (int)canvas.RenderSize.Height));

            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(crop));

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                using (var fs = System.IO.File.OpenWrite(saveFileDialog.FileName))
                {
                    pngEncoder.Save(fs);
                }
                // File.WriteAllText(saveFileDialog.FileName, txtEditor.Text);
            }
        }

    }
}
