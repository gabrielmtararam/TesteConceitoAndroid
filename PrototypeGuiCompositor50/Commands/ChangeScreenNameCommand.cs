using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeGuiCompositor30.Commands
{
    class ChangeScreenNameCommand:ICommand
    {

        private String _oldName;
        private String _newName;
        private IScreen _screen;


        public ChangeScreenNameCommand(IScreen screen,String oldName, String newName)
        {
            _oldName = oldName;
            _newName = newName;
            _screen = screen; 
            Execute();
        }
        public void Execute()
        {
            _screen.Name = _newName;
        }
        public void Undo()
        {
            _screen.Name  = _oldName;
        }
        public void Redo()
        {
            Execute();
        }
    }
}
