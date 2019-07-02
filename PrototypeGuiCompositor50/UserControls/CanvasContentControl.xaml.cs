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
using PrototypeGuiCompositor30.elements;
using PrototypeGuiCompositor30.UserControls;
using ThicknessConverter = Xceed.Wpf.DataGrid.Converters.ThicknessConverter;

namespace PrototypeGuiCompositor30
{ 
    public partial class CanvasContentControl : UserControl
    {
       
        MoveEventHandler mouseEventHandler;
        public bool IsSelectedCCC
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register(" IsSelectedCCC", typeof(bool), typeof(CanvasContentControl), new FrameworkPropertyMetadata(
     false,
     new PropertyChangedCallback(OnIsSelectedCCCPropertyChanged)));

        public bool IsActiveCCC
        {
            get { return (bool)GetValue(IsActiveCCCProperty); }
            set { SetValue(IsActiveCCCProperty, value); }
        }

        public static readonly DependencyProperty IsActiveCCCProperty =
            DependencyProperty.Register(" IsActiveCCC", typeof(bool), typeof(CanvasContentControl), new FrameworkPropertyMetadata(
                false,
                new PropertyChangedCallback(OnIsActiveCCCPropertyChanged)));

        private static void OnIsActiveCCCPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            DependencyObject _myCanvas = VisualTreeHelper.GetParent((sender as CanvasContentControl));
            Canvas _myCanvasC = _myCanvas as Canvas;
           
            _myCanvasC.UpdateLayout();
            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer((sender as CanvasContentControl));


            //Console.WriteLine($"adorner layer {adornerLayer}");
            ClearAdornerLayer(sender);
            if ((sender as CanvasContentControl).IsActiveCCC == true)
            {
            //    Console.WriteLine($"Adcionando adorner {(sender as CanvasContentControl).IContentFather.elementData.Name}");
                adornerLayer.Remove((sender as CanvasContentControl).cccMoveScaleAdorner);
                adornerLayer.Add((sender as CanvasContentControl).cccMoveScaleAdornerSelected);
              //  adornerLayer.Add((sender as CanvasContentControl).cccRotateAdorner);
                //   ProgramManager.ActiveControl.ActiveControl.CanvasContetControlInstance = sender as CanvasContentControl;

            }
            else
            {
               // Console.WriteLine($"removendo adorner {(sender as CanvasContentControl).IContentFather.elementData.Name}");
                adornerLayer.Remove((sender as CanvasContentControl).cccMoveScaleAdornerSelected);
                adornerLayer.Add((sender as CanvasContentControl).cccMoveScaleAdorner);
            }
        }

        private static void ClearAdornerLayer(DependencyObject sender)
        {
            AdornerLayer myAdornerLayer = AdornerLayer.GetAdornerLayer((sender as CanvasContentControl));
           // Console.WriteLine($"sender {sender}  adorner layer {AdornerLayer.GetAdornerLayer((sender as CanvasContentControl))}  ");
            Adorner[] toRemoveArray = myAdornerLayer.GetAdorners((sender as CanvasContentControl));
            if (toRemoveArray != null)
            {
                for (int x = 0; x < toRemoveArray.Length; x++)
                {
                    myAdornerLayer.Remove(toRemoveArray[x]);
                }
            }
        }
        public MoveScaleAdorner cccMoveScaleAdorner
        {
            get { return (MoveScaleAdorner)GetValue(cccMoveScaleAdornerProperty); }
            set { SetValue(cccMoveScaleAdornerProperty, value); }
        }

        public static readonly DependencyProperty cccMoveScaleAdornerProperty =
            DependencyProperty.Register("cccMoveScaleAdorner", typeof(MoveScaleAdorner), typeof(CanvasContentControl), new PropertyMetadata(null));

        public MoveScaleAdornerSelected cccMoveScaleAdornerSelected
        {
            get { return (MoveScaleAdornerSelected)GetValue(cccMoveScaleAdornerSelectedProperty); }
            set { SetValue(cccMoveScaleAdornerSelectedProperty, value); }
        }

        public static readonly DependencyProperty cccMoveScaleAdornerSelectedProperty =
            DependencyProperty.Register("cccMoveScaleAdornerSelected", typeof(MoveScaleAdornerSelected), typeof(CanvasContentControl), new PropertyMetadata(null));




        public SimpleTextImageElement IContentFather
        {
            get { return (SimpleTextImageElement)GetValue(IContentFatherProperty); }
            set { SetValue(IContentFatherProperty, value); }
        }
        public static readonly DependencyProperty IContentFatherProperty =
            DependencyProperty.Register("IContentFather", typeof(SimpleTextImageElement), typeof(CanvasContentControl), new PropertyMetadata(null));



        public rotateAdorner cccRotateAdorner
        {
            get { return (rotateAdorner)GetValue(cccRotateAdornerProperty); }
            set { SetValue(cccRotateAdornerProperty, value); }
        }
        public static readonly DependencyProperty cccRotateAdornerProperty =
            DependencyProperty.Register("cccRotateAdorner", typeof(rotateAdorner), typeof(CanvasContentControl), new PropertyMetadata(null));


        private static void OnIsSelectedCCCPropertyChanged(
           DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            DependencyObject _myCanvas = VisualTreeHelper.GetParent((sender as CanvasContentControl));
            Canvas _myCanvasC = _myCanvas as Canvas;
            _myCanvasC.UpdateLayout();
            ClearAdornerLayer(sender);
            if ((sender as CanvasContentControl).IsSelectedCCC == true)
            {
               // DependencyObject _myCanvas = VisualTreeHelper.GetParent((sender as CanvasContentControl));
               // Canvas _myCanvasC = _myCanvas as Canvas;
                AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer((sender as CanvasContentControl));

                //   adornerLayer.Remove((sender as CanvasContentControl).cccMoveScaleAdorner);
                adornerLayer.Add((sender as CanvasContentControl).cccMoveScaleAdorner);
                adornerLayer.Add((sender as CanvasContentControl).cccRotateAdorner);
                ProgramManager.selecionados.Add((sender as CanvasContentControl).IContentFather);
                Console.WriteLine($"selecionadosssssss {ProgramManager.selecionados}");
             //   ProgramManager.ActiveControl.ActiveControl.CanvasContetControlInstance = sender as CanvasContentControl;

            }
            else
            {

                AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(sender as CanvasContentControl);
                adornerLayer.Remove((sender as CanvasContentControl).cccMoveScaleAdorner);
                ProgramManager.selecionados.Remove((sender as CanvasContentControl).IContentFather);
                //adornerLayer.Remove((sender as CanvasContentControl).cccMoveScaleAdornerSelected);
                adornerLayer.Remove((sender as CanvasContentControl).cccRotateAdorner);
            }
        }

        public void OnLoaded(object sender, RoutedEventArgs e)
        {

            DependencyObject _myCanvas = VisualTreeHelper.GetParent(this);
            Canvas _myCanvasC = _myCanvas as Canvas;

            mouseEventHandler = new MoveEventHandler(_myCanvasC);
            _myCanvasC.PreviewMouseLeftButtonDown += mouseEventHandler.MyCanvas_PreviewMouseLeftButtonDown;
           _myCanvasC.PreviewMouseMove += mouseEventHandler.MyCanvas_PreviewMouseMove;
           _myCanvasC.PreviewMouseLeftButtonUp += mouseEventHandler.MyCanvas_PreviewMouseLeftButtonUp;
            PreviewKeyDown += mouseEventHandler.window1_PreviewKeyDown;

            MouseEnter += mouseEventHandler.Move_MouseEnter;
            MouseLeave += mouseEventHandler.Move_MouseLeave;

            cccMoveScaleAdorner = new MoveScaleAdorner(this);
            cccMoveScaleAdornerSelected = new MoveScaleAdornerSelected(this);
            cccRotateAdorner = new rotateAdorner(this);
            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this);
            adornerLayer.Visibility = Visibility.Visible;
        }

        public CanvasContentControl()
        {
            InitializeComponent();
            this.IsSelectedCCC = false;

        }

    }

   


}
