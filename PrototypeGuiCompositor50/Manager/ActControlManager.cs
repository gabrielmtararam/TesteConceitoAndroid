using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using PrototypeGuiCompositor30.Annotations;
using PrototypeGuiCompositor30.elements;

namespace PrototypeGuiCompositor30
{
    public class ActControlManager:INotifyPropertyChanged
    {



        public SimpleTextImageElement ActiveControl
        {
            get
            {
                return this.ActiveControlProp;
            }
            set
            {
                if (value != this.ActiveControlProp)
                {
                    this.ActiveControlProp = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public SimpleTextImageElement ActiveControlProp = new SimpleTextImageElement();

        


        public event PropertyChangedEventHandler PropertyChanged;

        public ActControlManager()
        {
           
            ActiveControl = new SimpleTextImageElement();
           // ActiveControl.Content = ControlsFactory.LoadDefaultButton(ActiveControl);
          //  ActiveControl.Content2 = ActiveControl.Content2SimpleButton.controle;
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            Console.WriteLine($"property changed {propertyName}");
            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
