using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using PrototypeGuiCompositor30.UserControls;

namespace PrototypeGuiCompositor30
{
    public static class ControlsFactory
    {
        public static SimpleButton LoadDefaultButton(CanvasContentControl _contentControl)
        {
            //Button button = new Button();
            //button.MinHeight = 40;
            //button.MinWidth = 40;
            //button.Name = "btn"+button.GetHashCode().ToString();
            SimpleButton button = new SimpleButton(_contentControl);
            return button;
        }
    }
}
