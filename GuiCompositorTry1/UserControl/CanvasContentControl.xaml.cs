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
using GuiCompositorTry1.Adorners;

namespace GuiCompositorTry1.UserControl
{
    public partial class CanvasContentControl : System.Windows.Controls.UserControl
    {
        public bool IsSelectedCCC
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register(" IsSelectedCCC", typeof(bool), typeof(CanvasContentControl), new FrameworkPropertyMetadata(
                false,
                new PropertyChangedCallback(OnIsSelectedCCCPropertyChanged)));


        public MoveScaleAdorner cccMoveScaleAdorner
        {
            get { return (MoveScaleAdorner)GetValue(cccMoveScaleAdornerProperty); }
            set { SetValue(cccMoveScaleAdornerProperty, value); }
        }

        public static readonly DependencyProperty cccMoveScaleAdornerProperty =
            DependencyProperty.Register("cccMoveScaleAdorner", typeof(MoveScaleAdorner), typeof(CanvasContentControl), new PropertyMetadata(null));



        public rotateAdorner cccRotateAdorner
        {
            get { return (rotateAdorner)GetValue(cccRotateAdornerProperty); }
            set { SetValue(cccRotateAdornerProperty, value); }
        }
        
        public static readonly DependencyProperty cccRotateAdornerProperty =
            DependencyProperty.Register("cccRotateAdorner", typeof(rotateAdorner), typeof(CanvasContentControl), new PropertyMetadata(null));




        public CanvasContentControl()
        {
            InitializeComponent();
        }



        private static void OnIsSelectedCCCPropertyChanged(
          DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if ((sender as CanvasContentControl).IsSelectedCCC == true)
            {
                DependencyObject _myCanvas = VisualTreeHelper.GetParent((sender as CanvasContentControl));
                Canvas _myCanvasC = _myCanvas as Canvas;
                AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer((sender as CanvasContentControl));

                adornerLayer.Add((sender as CanvasContentControl).cccMoveScaleAdorner);
                adornerLayer.Add((sender as CanvasContentControl).cccRotateAdorner);

                ProgramManager.ActiveControl.ActiveControl = sender as CanvasContentControl;

                Console.WriteLine($"Active Instance {ProgramManager.propGrid.SelectedObject.GetHashCode()}");
            }
            else
            {
                AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(sender as CanvasContentControl);
                adornerLayer.Remove((sender as CanvasContentControl).cccMoveScaleAdorner);
                adornerLayer.Remove((sender as CanvasContentControl).cccRotateAdorner);
            }
        }
    }
}
