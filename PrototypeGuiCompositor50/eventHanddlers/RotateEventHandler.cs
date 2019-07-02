using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PrototypeGuiCompositor30
{
    class RotateEventHandler
    {
       


        private double initialAngle;
        private RotateTransform rotateTransformOriginal;
        private Vector startVector;
        private Point centerPoint;
        private RotateTransform lastOne;
      
        RotateTransform rotateTransformFinal;
        List<RotateTransform> resultFinal;

        Canvas canvas;
        Point _origin;
        FrameworkElement parentPanel;

        Line myLine;

        public RotateEventHandler(FrameworkElement _parentPanel, Canvas _canvas)
        {
            parentPanel = _parentPanel;
            lastOne = new RotateTransform();

            rotateTransformFinal = parentPanel.RenderTransform as RotateTransform;
            canvas = _canvas;
       
        }

        public RotateTransform getNextRotateTransform(Point origin,Point currentPos, FrameworkElement parentPanelAux, Thumb thumb)
        {
            var y = -(currentPos.Y - origin.Y + thumb.ActualHeight / 2);
            var x = currentPos.X - origin.X + thumb.ActualWidth / 2;

            double tg = y / x;
            double radians = Math.Atan(tg);
            double angle = radians * (180 / Math.PI);

            if (y < 0 && x > 0)
                angle = angle + 360;
            else if (y < 0)
                angle = angle + 180;
            else if (y > 0 && x < 0)
                angle = angle + 180;

            RotateTransform rotateTransform1 = new RotateTransform(-angle, parentPanelAux.ActualWidth / 2, parentPanelAux.ActualHeight / 2);

            return rotateTransform1;
        }
        public List<RotateTransform> OnDragDelta(object sender, DragDeltaEventArgs e)
        {
            canvas.Children.Remove(myLine);
            myLine = new Line();

            var s = sender as Thumb;
            Point _currentPos = Mouse.GetPosition(canvas);

            myLine.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            myLine.X1 = _origin.X - s.ActualWidth / 2;
            myLine.X2 = _currentPos.X;
            myLine.Y1 = _origin.Y - s.ActualHeight / 2;
            myLine.Y2 = _currentPos.Y;
            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;
            myLine.StrokeThickness = 2;
            canvas.Children.Add(myLine);

            lastOne = rotateTransformFinal;

             rotateTransformFinal = getNextRotateTransform(_origin, _currentPos, parentPanel,  s);

            resultFinal = new List<RotateTransform>();
            resultFinal.Add(lastOne);
            resultFinal.Add(rotateTransformFinal);
            

            return resultFinal;
        }


        public void OnDragStarted(object sender, DragStartedEventArgs e)
        {
            var s = sender as Thumb;

            _origin = parentPanel.TranslatePoint(new Point(0, 0), canvas);
            _origin.X += parentPanel.ActualWidth / 2;
            _origin.Y += parentPanel.ActualHeight/2;
            rotateTransformOriginal = parentPanel.RenderTransform as RotateTransform;

        }

        public List<RotateTransform> OnDragCompleted(object sender, DragCompletedEventArgs e)
        {
            canvas.Children.Remove(myLine);
            List<RotateTransform> result = new List<RotateTransform>();
            result.Add(rotateTransformFinal);
            result.Add(rotateTransformOriginal);
            var s = sender as Thumb;
            s.Opacity = 0;

            return result;
        }

        public void Move_MouseEnter(object sender, MouseEventArgs e)
        {
            FrameworkElement senderFE = sender as FrameworkElement;
            if (senderFE.Cursor != Cursors.Wait)
                Mouse.OverrideCursor = Cursors.SizeAll;
        }


        public void Move_MouseLeave(object sender, MouseEventArgs e)
        {
            FrameworkElement senderFE = sender as FrameworkElement;
            if (senderFE.Cursor != Cursors.Wait)
                Mouse.OverrideCursor = Cursors.Arrow;
        }


    }
}
