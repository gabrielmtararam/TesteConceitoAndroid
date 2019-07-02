using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GuiCompositorTry1.Factorys;

namespace GuiCompositorTry1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OnAddScreenClick(object sender, RoutedEventArgs e)
        {
            //            throw new NotImplementedException();
            //   Console.WriteLine($"select { TreeViewScreens.SelectedItem.ToString()}");

            ScreenFactory.AddDefaultScreen(ProgramManager.ActiveScreen.Screen.Childrens, "teste", null);


        }

        public void OnRemoveScreenClick(object sender, RoutedEventArgs e)
        {
            //            throw new NotImplementedException();
        }
    }
}
