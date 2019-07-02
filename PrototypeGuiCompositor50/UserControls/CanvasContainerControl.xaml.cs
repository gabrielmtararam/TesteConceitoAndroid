using PrototypeGuiCompositor30.eventHanddlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrototypeGuiCompositor30
{ 
    public partial class CanvasContainerControl : UserControl
    {
        public IScreen Screen
        {
            get { return (IScreen)GetValue(ScreenProperty); }
            set { SetValue(ScreenProperty, value); }
        }
        public static readonly DependencyProperty ScreenProperty =
            DependencyProperty.Register("Screen", typeof(IScreen), typeof(CanvasContainerControl), new PropertyMetadata(null));


        public int InsertElementMode
        {
            get { return (int)GetValue(InsertElementModeProperty); }
            set { SetValue(InsertElementModeProperty, value); }
        }
        public static readonly DependencyProperty InsertElementModeProperty =
            DependencyProperty.Register("InsertElementMode", typeof(int), typeof(CanvasContentControl), new PropertyMetadata(null));



        public void OnLoaded(object sender, RoutedEventArgs e)
        {
        }

        public CanvasContainerControl()
        {
            InitializeComponent();
        }
        public void Move_MouseEnter(object sender, MouseEventArgs e)
        {
        }
        public void Move_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (this.InsertElementMode == 1)
            {
                ICommand comando = new InsertButtonCommand(ProgramManager.ActiveScreen.Screen, this, Mouse.GetPosition(this.Content as Canvas).X, Mouse.GetPosition(this.Content as Canvas).Y);
                CommandManager.AddCommand(comando);
            }
        }

    }
}
