using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace GuiCompositorTry1.VisualAdroner
{
    public partial class RotateAdornerVisual : System.Windows.Controls.UserControl
    {
        RotateEventHandler rotateEventHandler;
      
        public RotateAdornerVisual( )
        {
            InitializeComponent();
         
        }
        public void OnLoaded(object sender, RoutedEventArgs e) {
            DependencyObject _myCanvas = VisualTreeHelper.GetParent(this.DataContext as FrameworkElement);
            Canvas _myCanvasC = _myCanvas as Canvas;
            Console.WriteLine($"canvas do data context {_myCanvas}");
            rotateEventHandler = new RotateEventHandler(this.DataContext as FrameworkElement, _myCanvasC);
        }
            private void OnDragDelta(object sender, DragDeltaEventArgs e)
        {
           List<RotateTransform> result =rotateEventHandler.OnDragDelta(sender, e);
            RaiseEvent(new RotateRoutedEventArgs(RotateAdornerVisual.RotateRoutedEvent, sender, result));
        }

        private void OnDragStarted(object sender, DragStartedEventArgs e)
        {
            rotateEventHandler.OnDragStarted(sender, e);
        }

        private void OnDragCompleted(object sender, DragCompletedEventArgs e)
        {
            List<RotateTransform> result = rotateEventHandler.OnDragCompleted(sender, e);

            RaiseEvent(new RotateRoutedEventArgs(RotateAdornerVisual.RotateFinishRoutedEvent, sender, result));
        }
        public void Move_MouseEnter(object sender, MouseEventArgs e)
        {

            rotateEventHandler.Move_MouseEnter(sender, e);
        }
        public void Move_MouseLeave(object sender, MouseEventArgs e)
        {

            rotateEventHandler.Move_MouseLeave(sender, e);
        }

 


    }




}
