using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeGuiCompositor30
{
    public static class ScreensFactory
    {
        public static ObservableCollection<IScreen> LoadScreenList()
        {
            ObservableCollection<IScreen> screens = new ObservableCollection<IScreen>();
            screens.Add(new DefaultScreen());
            return screens;
        }

        public static void  AddDefaultScreen(ObservableCollection<IScreen> screens, string name, IScreen fatherNode)
        {
            screens.Add(new DefaultScreen(name));
          

        }
        public static void AddDefaultScreen(ObservableCollection<IScreen> screens, string name)
        {
            screens.Add(new DefaultScreen(name));


        }

    }
}
