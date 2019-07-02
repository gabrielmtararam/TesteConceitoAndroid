using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PrototypeGuiCompositor30.Commands
{
    class SelectScreenCommand:ICommand
    {
        private IScreen _oldScreen;
        private IScreen _newScreen;


        public SelectScreenCommand(IScreen oldScreen, IScreen newScreen)
        {
            _oldScreen = oldScreen;
            _newScreen = newScreen;
            Execute();
        }
        public void Execute()
        {
            Console.WriteLine($"mudando tela ativa para {_newScreen.Name}");
            ProgramManager.ActiveScreen.Screen = _newScreen;
            invertSelection(_newScreen);
            invertSelection(_newScreen);
            ProgramManager.uptadePropertyGrid();
        }
        public void Undo()
        {
            Console.WriteLine($"mudando tela ativa para {_oldScreen.Name}");
            ProgramManager.ActiveScreen.Screen = _oldScreen;
            invertSelection(_oldScreen);
            invertSelection(_oldScreen);
            ProgramManager.uptadePropertyGrid();
        }

        public void invertSelection(IScreen screen)
        {
            foreach (IContent i in screen.Elements)
            {
                i.CanvasContetControlInstance.IsActiveCCC = !i.CanvasContetControlInstance.IsActiveCCC;
                i.CanvasContetControlInstance.IsSelectedCCC = !i.CanvasContetControlInstance.IsSelectedCCC;
            }

            foreach (IContent i in screen.Elements)
            {
                if (i.CanvasContetControlInstance.IsActiveCCC)
                {
                    i.CanvasContetControlInstance.IsActiveCCC = false;
                    i.CanvasContetControlInstance.IsActiveCCC = true;
                }
            }

        }
        public void Redo()
        {
            Execute();
        }
    }
}
