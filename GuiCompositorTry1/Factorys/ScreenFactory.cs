using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuiCompositorTry1.Interfaces;

namespace GuiCompositorTry1.Factorys
{
    public static class ScreenFactory
    {
    public static void AddDefaultScreen(ObservableCollection<IScreen> screens, string name, IScreen fatherNode)
    {
        screens.Add(new DefaultScreen(name));


    }
}
}
