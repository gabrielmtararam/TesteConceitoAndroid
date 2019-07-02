using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;
using PrototypeGuiCompositor30.Annotations;
using PrototypeGuiCompositor30.elements;
using PrototypeGuiCompositor30.Manager;
using Xceed.Wpf.DataGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid;

//using WPG;

namespace PrototypeGuiCompositor30
{
    public static class ProgramManager
    {
        public static ObservableCollection<IScreen> screens;
//        public static List<IScreen> screens;
        //public static IScreen ActiveScreen= new DefaultScreen();
        //public static dynamic showableElementInstersection=new ExpandoObject();
        public static ObservableCollection<SimpleTextImageElement> selecionados = new ObservableCollection<SimpleTextImageElement>();
        public static PropertyGrid propGrid  = new PropertyGrid();
        public static ActScreenManager ActiveScreen = new ActScreenManager();
        
        public static bool AddingScreen = false;
        public static void InitializeProgram()
        {
            screens = ScreensFactory.LoadScreenList();
            ActiveScreen.Screen = screens[0];
            propGrid = new PropertyGrid();

        }

        public static void uptadePropertyGrid()
        {
            InstersecElementManager.printPublic();

            propGrid.AutoGenerateProperties = true;
            dynamic teste = new DynamicDictionary();
            teste.batata = "teaaaaa";
            teste.carro = "arrrrrr";
            teste.numero = 10;
            //dynamic teste = new ExpandoObject();
            // ()
            //  teste.batata = 10;
            // teste.rato = "testando";
            // teste.Add("rato","ratoooooo");
              propGrid.SelectedObject = ((Dictionary<string, object>)teste.dictionary).Values;// ((IDictionary<string, Object>)ProgramManager.ActiveScreen.Screen.IntersectedProps).Keys;


        }

    }
}
