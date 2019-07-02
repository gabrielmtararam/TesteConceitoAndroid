using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GuiCompositorTry1.Interfaces
{
    public interface IScreen
    {
         Canvas ScreenCanvas { get; set; }
         ObservableCollection<IContent> Elements { get; set; }
         ObservableCollection<IScreen> Childrens { get; set; }
        IContent ActiveElement { get; set; }
    }
}
