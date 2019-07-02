using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
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
using PrototypeGuiCompositor30.Commands;

using PrototypeGuiCompositor30.UserControls;

namespace PrototypeGuiCompositor30
{

    public partial class MainWindow : Window
    {
        private ImageRender imgRender;
        public ObservableCollection<IScreen>  telas{ get; set; }
        public MainWindow()
        {
            ProgramManager.InitializeProgram();
            InitializeComponent();

           canvasContainer.Screen =ProgramManager.ActiveScreen.Screen;

        //   ProgramManager.propGrid = PropertyGrid;

            TransformationsRoutedEventHandler transforEventHandlers = new TransformationsRoutedEventHandler(canvasContainer.Screen); 

            imgRender = new ImageRender(ProgramManager.screens,0);

            AddHandler(CanvasContentControl.MoveRoutedEvent, new RoutedEventHandler(transforEventHandlers.MoveEvent));

            AddHandler(MoveScaleAdornerVisual.MoveScaleRoutedEvent, new RoutedEventHandler(transforEventHandlers.ScaleEvent));

            AddHandler(RotateAdornerVisual.RotateRoutedEvent, new RoutedEventHandler(transforEventHandlers.RotateEvent));

            AddHandler(CanvasContentControl.MoveRoutedFinishEvent, new RoutedEventHandler(transforEventHandlers.MoveFinishEvent));

            AddHandler(RotateAdornerVisual.RotateFinishRoutedEvent, new RoutedEventHandler(transforEventHandlers.RotateFinishEvent));

            AddHandler(MoveScaleAdornerVisual.MoveScaleFinishRoutedEvent, new RoutedEventHandler(transforEventHandlers.ScaleFinishEvent));

            telas = new ObservableCollection<IScreen>();
            telas = (ObservableCollection<IScreen>) ProgramManager.screens;

            ProgramManager.propGrid = PropertyGrid;
        }
        
        private void OnImageInsertSelect(object sender, RoutedEventArgs e)
        {
            
            if (sender.GetType() == typeof(Button))
            {
                int value = GetButtonId((sender as Button).Name);
                switch (value)
                {
                    case 1:
                        if (canvasContainer.InsertElementMode == value)
                        {
                            (sender as Button).Background = Brushes.Transparent;
                            canvasContainer.InsertElementMode = 0;
                            ProgramManager.AddingScreen = false;
                        }
                        else
                        {
                            (sender as Button).Background = Brushes.Blue;
                            canvasContainer.InsertElementMode = 1;
                            ProgramManager.AddingScreen = true;
                        }

                        break;
                }

               
            }   
        }

        private void OnSelectAllClick(object sender, RoutedEventArgs e)
        {
            bool allSelected = true;
           foreach(IContent i in (canvasContainer.Screen).Elements)
            {
                if ((i.CanvasContetControlInstance as CanvasContentControl).IsSelectedCCC==false)
                    allSelected=false;

            }
            if (allSelected == true)
            {
                imageSelectAll.Source = new BitmapImage(new Uri(@"C:\Users\Eletronica10\source\repos\PrototypeGuiCompositor\PrototypeGuiCompositor\PrototypeGuiCompositor40\images\icons8-checked-checkbox-32.png"));
            }
            foreach (IContent i in (canvasContainer.Screen).Elements)
            {
                (i.CanvasContetControlInstance as CanvasContentControl).IsSelectedCCC = true;
            }
        }



        private int GetButtonId(string name)
        { 
            name = name.ToLower();
                string[] result = name.Split(new[] { "button" }, StringSplitOptions.None);
            int value = Int32.Parse(result[1]);
            return value;
        }

        private void OnUndoclick(object sender, RoutedEventArgs e)
        {
            CommandManager.UndoCommand();
        }

        private void OnRedoClick(object sender, RoutedEventArgs e)
        {
            CommandManager.RedoCommand();
        }

        private void OnRenderImageClick(object sender, RoutedEventArgs e)
        {
            imgRender.RenderActiveImage();

        }

            private void OnAddScreenClick(object sender, RoutedEventArgs e)
            {
                ScreensFactory.AddDefaultScreen(ProgramManager.ActiveScreen.Screen.Childrens, "teste", null);
            }

            public void OnRemoveScreenClick(object sender, RoutedEventArgs e)
            {
            }

        void keyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox == null)
                return;
            if (e.Key == Key.Enter || e.Key == Key.Return)
                textBox.IsReadOnly = true;
        }

        public void doubleClickTreeEvent(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("entrou aqui");
            TextBox textBox = sender as TextBox;
            IScreen telaSelecionada = (IScreen) textBox.DataContext;
            if (textBox == null)
                return;
            textBox.IsReadOnly = false;
        }

        private void OnItemSelected(object sender, RoutedEventArgs e)
        {
        }

        private void OnMouseTreeItemLeftButtonDown(object sender, EventArgs eventArgs)
        {
           
             TextBox textBox = sender as TextBox;
             
            IScreen telaSelecionada = (IScreen)textBox.DataContext;

          
            if ((telaSelecionada != null) &&(telaSelecionada != ProgramManager.ActiveScreen.Screen))
            {
                Console.WriteLine($"res {telaSelecionada.Name} aaa { ProgramManager.ActiveScreen.Screen.Name}");
                ICommand comando = new SelectScreenCommand(ProgramManager.ActiveScreen.Screen, telaSelecionada);
                CommandManager.AddCommand(comando);
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
           ((UIElement) sender).Focus();
        }
    }
}
