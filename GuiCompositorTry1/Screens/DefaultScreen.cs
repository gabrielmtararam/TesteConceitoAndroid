using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using GuiCompositorTry1.Interfaces;
using GuiCompositorTry1.UserControl;

namespace GuiCompositorTry1.Screens
{
    public class DefaultScreen
    {
       public  Canvas ScreenCanvas { get; set; }
       public ObservableCollection<IContent> Elements { get; set; }
       public IContent ActiveElement { get; set; }
       public ObservableCollection<IScreen> Childrens { get; set; }
        public string Name
       {
           get
           {
               return this.NameProp;
           }
           set
           {
               if (value != this.NameProp)
               {
                   this.NameProp = value;
                   NotifyPropertyChanged();
               }
           }
       }

       public string NameProp;
       public bool IsAllSelected { get; set; }

       public DefaultScreen(String name="DefaultName")
       {
           this.ScreenCanvas = new Canvas();
           (this.ScreenCanvas as Canvas).Background = new SolidColorBrush(Colors.Blue);

           this.Elements = new ObservableCollection<IContent>();
           Name = name;
           Childrens = new ObservableCollection<IScreen>();
       }


       public void uptdateStatus()
       {
           bool allSelected = true;
           foreach (IContent i in Elements)
           {
               if ((i.CanvasUserControl as CanvasContentControl).IsSelectedCCC == false)
                   allSelected = false;
           }
           IsAllSelected = allSelected;
       }

   

       public event PropertyChangedEventHandler PropertyChanged;
       private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
       {

           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
       }
    }
}
