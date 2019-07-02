using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PrototypeGuiCompositor30.Annotations;
using PrototypeGuiCompositor30.elements;


namespace PrototypeGuiCompositor30
{
   public class DefaultScreen:IScreen, INotifyPropertyChanged
    {
       public ObservableCollection<IScreen> Childrens { get; set; }
        public Canvas Screen { get; set; }
       public ObservableCollection<IContent> Elements { get; set; }
       public IContent ActiveElement { get; set; } = new SimpleTextImageElement();
      public dynamic IntersectedProps { get; set; } = new ExpandoObject() as IDictionary<string, Object>;

        //public IContent ActiveControl { get; set; } = new SimpleTextImageElement();();


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

         public DefaultScreen()
        {
            this.Screen = new Canvas();
            (this.Screen as Canvas).Background = new SolidColorBrush(Colors.Blue);

            this.Elements = new ObservableCollection<IContent>();
            Name = "defaultName";
            Childrens=new ObservableCollection<IScreen>();
        }
         public DefaultScreen(string name)
         {
             this.Screen = new Canvas();
             (this.Screen as Canvas).Background = new SolidColorBrush(Colors.Blue);

             this.Elements = new ObservableCollection<IContent>();
             Name =name;
             Childrens = new ObservableCollection<IScreen>();
        }

         public void UnselectAll()
         {
             foreach (IContent i in this.Elements)
             {
                 i.CanvasContetControlInstance.IsActiveCCC = false;
                 i.CanvasContetControlInstance.IsSelectedCCC = false;
                
             }
         }

         public bool GetActiveExist()
         {
             
             foreach (IContent i in ProgramManager.ActiveScreen.Screen.Elements)
             {
                 if (i.CanvasContetControlInstance.IsActiveCCC == true)
                     return true;
             }

             return false;
         }
        public void uptdateStatus()
        {
            bool allSelected = true;
            foreach (IContent i in Elements)
            {
                if ((i.Content as IContent).IsSelected == false)
                    allSelected = false;

            }
            IsAllSelected = allSelected;
        }

        public void insertChildren(IScreen children)
        {
            if(Childrens==null)
                Childrens = new ObservableCollection<IScreen>();
            Childrens.Add(children);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
