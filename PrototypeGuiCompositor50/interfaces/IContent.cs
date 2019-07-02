using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using PrototypeGuiCompositor30.DataModels;

namespace PrototypeGuiCompositor30
{
    public interface IContent
    {
         Panel Content { get; set; }
         CanvasContentControl CanvasContetControlInstance { get; set; }
          Boolean IsSelected { get; set; }
          ElementContentDataModel elementData { get; set; }
    }
}
