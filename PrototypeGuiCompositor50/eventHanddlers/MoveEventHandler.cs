using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Media;
using PrototypeGuiCompositor30.elements;
using PrototypeGuiCompositor30.Manager;

namespace PrototypeGuiCompositor30
{
    class MoveEventHandler
    {
        private bool _isDown;
        private bool _isDragging;
        private UIElement _MovedElement;
        private double _originalLeft;
        private double _originalTop;
        private Adorner _overlayElement;

        double nextLeftOffset;
        double nextTopOffset;
        FrameworkElement _FrMovedElement;

        private Point _previousMousePosition;
        private Canvas _myCanvas;


        List<double> scaleBefore;
        List<double> LastOne;
        List<double> result;


        public MoveEventHandler(Canvas myCanvas)
        {
            _myCanvas = myCanvas;
            _previousMousePosition.X = 0;
            _previousMousePosition.Y = 0;

        }


        public void window1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
       //     Console.WriteLine("here4");
            if (e.Key == Key.Escape && _isDragging)
            {
                DragFinished(true);
            }
        }

        public void MyCanvas_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
        //    Console.WriteLine("here3");
            if (_isDown)
            {
              DragFinished(true);
              

            }
           
        }

        public void DragFinished(bool cancelled)
        {
            //    Console.WriteLine("here2");
            List<List<double>> result = new List<List<double>>();
            Mouse.Capture(null);
            if (_isDragging)
            {
                AdornerLayer.GetAdornerLayer(_overlayElement.AdornedElement).Remove(_overlayElement);

                if (cancelled == false)
                {
                    _isDragging = false;
                    _isDown = false;
                  //  Canvas.SetTop(_MovedElement, _originalTop);
                 //   Canvas.SetLeft(_MovedElement, _originalLeft);
                  
                }
                _overlayElement = null;
            }
            _isDragging = false;
            _isDown = false;
            result = null;
            if ((nextTopOffset != null) && (nextLeftOffset != null))
            {
                result = new List<List<double>>();
                result.Add(new List<double>());
                result.Add(new List<double>());
                result[0].Add(nextTopOffset);
                result[0].Add(nextLeftOffset);
                result[1].Add(_originalTop);
                result[1].Add(_originalLeft);
            }
           
            //  CommandManager.AddCommand(new MoveCommand(_FrMovedElement, nextTopOffset, nextLeftOffset, _originalTop, _originalLeft));

        }

        public void MyCanvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {

         
            if (_isDown)
            {
           //     Console.WriteLine("here1");
                if ((_isDragging == false) &&
                    ((Math.Abs(e.GetPosition(_myCanvas).X - _originalLeft) >
                      SystemParameters.MinimumHorizontalDragDistance) ||
                     (Math.Abs(e.GetPosition(_myCanvas).Y - _originalTop) >
                      SystemParameters.MinimumVerticalDragDistance)))
                {
               //     Console.WriteLine("here11");
                    DragStarted();
                }else
                if (_isDragging)
                {
                   
                     DragMoved();
                }
            }
            //return null;
        }
        public void DragStarted()
        {
          //  Console.WriteLine("here5");
            _isDragging = true;
            _originalLeft = Canvas.GetLeft(_MovedElement);
            _originalTop = Canvas.GetTop(_MovedElement);

            _overlayElement = new SimpleCircleAdorner(_MovedElement);
            var layer = AdornerLayer.GetAdornerLayer(_MovedElement);
            layer.Add(_overlayElement);
        }



        public void DragMoved()
        {
           
            _FrMovedElement = _MovedElement as FrameworkElement;

            //(_MovedElement as CanvasContentControl).IsSelectedCCC = true;

            nextTopOffset = MoveCalculator.getNextOffset(Canvas.GetTop(_MovedElement), _FrMovedElement.ActualHeight, _myCanvas.ActualHeight, Mouse.GetPosition(_MovedElement).Y, Mouse.GetPosition(_myCanvas).Y, _previousMousePosition.Y);
            nextLeftOffset = MoveCalculator.getNextOffset(Canvas.GetLeft(_MovedElement), _FrMovedElement.ActualWidth, _myCanvas.ActualWidth, Mouse.GetPosition(_MovedElement).X, Mouse.GetPosition(_myCanvas).X, _previousMousePosition.X);



            if (LastOne == null)
                LastOne = new List<double>();
            if (result == null)
                result = new List<double>();

            LastOne.Clear();
            //LastOne.Add(_MovedElement.ActualHeight);
            // LastOne.Add(_MovedElement.ActualWidth);
            LastOne.Add(Canvas.GetTop(_MovedElement));
            LastOne.Add(Canvas.GetLeft(_MovedElement));
            result.Clear();
            result.Add(nextTopOffset);
            result.Add(nextLeftOffset);
            List<List<double>> finalResult = new List<List<double>>();
            finalResult.Add(result);
            finalResult.Add(LastOne);

            //List<List<double>> result = mouseEventHandler.MyCanvas_PreviewMouseMove(sender, e);
            TransformationsEventHandler.MoveEvent(finalResult);


           // return finalResult;

           // Canvas.SetTop(_MovedElement, nextTopOffset);
            //Canvas.SetLeft(_MovedElement, nextLeftOffset);
            _previousMousePosition = Mouse.GetPosition(_myCanvas);
        }
        public void MyCanvas_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
       
            DependencyObject parent;
            CanvasContentControl _MovedElementCCC = e.Source as CanvasContentControl;
            _MovedElement = e.Source as UIElement;
            parent = VisualTreeHelper.GetParent(_MovedElement);
            



            if (e.Source == _myCanvas)
            {
                //   Console.WriteLine("here71");
                //  e.Handled = true;
                if (ProgramManager.AddingScreen ==false)
                 ProgramManager.ActiveScreen.Screen.UnselectAll();
             //   e.Handled = true;
            }
            else
            {
               // ProgramManager.ActiveControl.ActiveControl =null;

                if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
                {
                    
                    if (ProgramManager.ActiveScreen.Screen.GetActiveExist())
                        if (_MovedElementCCC.IsActiveCCC)
                            _MovedElementCCC.IsActiveCCC = true;

                    _MovedElementCCC.IsSelectedCCC = !_MovedElementCCC.IsSelectedCCC;

                    e.Handled = true;
                }
                else if(Keyboard.IsKeyDown(Key.LeftAlt) || Keyboard.IsKeyDown(Key.RightAlt))
                {
                    if (_MovedElementCCC.IsSelectedCCC == true)
                    {
                        

                        if (ProgramManager.ActiveScreen.Screen.ActiveElement != null)
                            ProgramManager.ActiveScreen.Screen.ActiveElement.CanvasContetControlInstance.IsActiveCCC = false;


                        ProgramManager.ActiveScreen.Screen.ActiveElement = (SimpleTextImageElement) _MovedElementCCC.IContentFather;
                        _MovedElementCCC.IsActiveCCC = true;
                        //   ProgramManager.uptadePropertyGrid(ProgramManager.ActiveScreen.Screen.ActiveElement.elementData);

                       // Console.WriteLine("heeeeeereeee");
                        InstersecElementManager.update();

                        e.Handled = true;
                    }
                    else
                    {
                        ProgramManager.ActiveScreen.Screen.UnselectAll();
                        _MovedElementCCC.IsSelectedCCC = true;
                        _MovedElementCCC.IsActiveCCC = true;
                        ProgramManager.ActiveScreen.Screen.ActiveElement = (SimpleTextImageElement)_MovedElementCCC.IContentFather;
                     //   ProgramManager.uptadePropertyGrid(ProgramManager.ActiveScreen.Screen.ActiveElement.elementData);
                        e.Handled = true;
                    }

                }
                else if (_MovedElementCCC.IsSelectedCCC == false)
                    {
                        ProgramManager.ActiveScreen.Screen.UnselectAll();
                        _MovedElementCCC.IsSelectedCCC = true;
                        _MovedElementCCC.IsActiveCCC = true;
                        ProgramManager.ActiveScreen.Screen.ActiveElement = (SimpleTextImageElement)_MovedElementCCC.IContentFather;
                    e.Handled = true;
                }

                _isDown = true;
                 _myCanvas.CaptureMouse();

            }

            //ProgramManager.ActiveControl.ActiveControl = _MovedElementCCC.IContentFather;
            //if (e.ClickCount == 2)
            //{
            //    Console.WriteLine($"here73  {_MovedElementCCC.IsSelectedCCC} {_MovedElementCCC.GetHashCode()}");
            //    _MovedElementCCC.IsSelectedCCC = !_MovedElementCCC.IsSelectedCCC;
            //    ProgramManager.ActiveControl.ActiveControl = null;
            //    e.Handled=true;


            //}
            //else
            //{
            //    _isDown = true;
            // _myCanvas.CaptureMouse();
            //}
            //}
          //  Console.WriteLine($" active elementeeeee {ProgramManager.ActiveScreen.Screen.ActiveElement.elementData.Name}");
            ProgramManager.uptadePropertyGrid();
        }
        public void Move_MouseEnter(object sender, MouseEventArgs e)

        {
         //   Console.WriteLine("here8");
            FrameworkElement senderFE = sender as FrameworkElement;
            if (senderFE.Cursor != Cursors.Wait)

                Mouse.OverrideCursor = Cursors.Hand;


        }


        public void Move_MouseLeave(object sender, MouseEventArgs e)

        {
        //    Console.WriteLine("here9");
            FrameworkElement senderFE = sender as FrameworkElement;
            if (senderFE.Cursor != Cursors.Wait)

                Mouse.OverrideCursor = Cursors.Arrow;

        }




    }
}
