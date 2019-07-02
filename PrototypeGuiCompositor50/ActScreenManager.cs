using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PrototypeGuiCompositor30.Annotations;

namespace PrototypeGuiCompositor30
{
    public class ActScreenManager:INotifyPropertyChanged
    {
        public IScreen Screen {
            get
            {
                return this.ScreenProp; 
            }
            set
            {
                if (value != this.ScreenProp)
                {
                    this.ScreenProp = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public IScreen ScreenProp = new DefaultScreen();
        //public IScreen screen=new DefaultScreen();
        public String name = "default";


        public event PropertyChangedEventHandler PropertyChanged;

        public ActScreenManager()
        {
            Screen = new DefaultScreen();
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {

            Console.WriteLine("tela alterada");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
