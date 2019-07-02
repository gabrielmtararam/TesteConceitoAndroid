using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PrototypeGuiCompositor30.elements;

namespace PrototypeGuiCompositor30
{
    class TransformationsEventHandler
    {
       // private static IScreen _screen;

      //  public  TransformationsEventHandler(IScreen screen)
      //  {
      //      this._screen = screen;

      //  }

        public static void ScaleFinishEvent(RoutedEventArgs e)
        {
            MoveScaleRoutedEventArgs argumentos = e as MoveScaleRoutedEventArgs;

            double dy = argumentos.MyProperty[0][2] - argumentos.MyProperty[1][2];
            double dx = argumentos.MyProperty[0][3] - argumentos.MyProperty[1][3];
            double x0;
            double y0;

            double dsy = argumentos.MyProperty[0][0] - argumentos.MyProperty[1][0];
            double dsx = argumentos.MyProperty[0][1] - argumentos.MyProperty[1][1];
            double sx0;
            double sy0;

            foreach (IContent element in ProgramManager.ActiveScreen.Screen.Elements)
            {
                CanvasContentControl cccElement = (element.CanvasContetControlInstance as CanvasContentControl);
                if (cccElement.IsSelectedCCC == true)
                {
                    List<double> previousScale = new List<double>();
                    List<double> nextScale = new List<double>();

                    previousScale.Clear();
                    nextScale.Clear();

                    y0 = Canvas.GetTop(cccElement) - dy;
                    x0 = Canvas.GetLeft(cccElement) - dx;

                    sy0 = cccElement.ActualHeight - dsy;
                    sx0 = cccElement.ActualWidth - dsx;
                    previousScale.Clear();

                    previousScale.Add(sy0);
                    previousScale.Add(sx0);
                    previousScale.Add(y0);
                    previousScale.Add(x0);

                    nextScale.Add(cccElement.ActualHeight);
                    nextScale.Add(cccElement.ActualWidth);
                    nextScale.Add(Canvas.GetTop(cccElement));
                    nextScale.Add(Canvas.GetLeft(cccElement));

                    ICommand scaleComand = new ScaleElementCommand(cccElement, nextScale, previousScale);
                    CommandManager.AddCommand(scaleComand);

                }
            }
        }



        public static void RotateFinishEvent(RoutedEventArgs e)
        {
            RotateRoutedEventArgs argumentos = e as RotateRoutedEventArgs;
            RotateTransform rotateFirst = argumentos.MyProperty[1];
            RotateTransform rotateLast = argumentos.MyProperty[0];

            foreach (IContent element in ProgramManager.ActiveScreen.Screen.Elements)
            {
                CanvasContentControl cccElement = (element.CanvasContetControlInstance as CanvasContentControl);
                if (cccElement.IsSelectedCCC == true)
                {
                    ICommand rotateCommand = new RotateCommand(cccElement, rotateLast, rotateFirst);
                    CommandManager.AddCommand(rotateCommand);
                }
            }
        }

        public static void MoveFinishEvent(RoutedEventArgs e)
        {
            MoveRoutedEventArgs argumentos = e as MoveRoutedEventArgs;

            if (argumentos.MyProperty != null)
            {
                double dy = argumentos.MyProperty[0][0] - argumentos.MyProperty[1][0];
                double dx = argumentos.MyProperty[0][1] - argumentos.MyProperty[1][1];
                double x0;
                double y0;
                foreach (IContent element in ProgramManager.ActiveScreen.Screen.Elements)
                {
                    CanvasContentControl cccElement = (element.CanvasContetControlInstance as CanvasContentControl);

                    if (cccElement.IsSelectedCCC == true)
                    {
                        y0 = Canvas.GetTop(cccElement) - dy;
                        x0 = Canvas.GetLeft(cccElement) - dx;
                        CommandManager.AddCommand(new MoveCommand(cccElement, Canvas.GetTop(cccElement), Canvas.GetLeft(cccElement), y0, x0));
                    }
                }
            }
        }



        public static void RotateEvent(RoutedEventArgs e)
        {
            RotateRoutedEventArgs argumentos = e as RotateRoutedEventArgs;
            RotateTransform rotateFirst = argumentos.MyProperty[0];
            RotateTransform rotateLast = argumentos.MyProperty[1];

            foreach (IContent element in ProgramManager.ActiveScreen.Screen.Elements)
            {
                CanvasContentControl cccElement = (element.CanvasContetControlInstance as CanvasContentControl);
                if (cccElement.IsSelectedCCC == true)
                {
                    cccElement.RenderTransform = rotateLast;
                }
            }
        }



        public static void MoveEvent(List<List<double>> argumentos)
        {
          //  MoveRoutedEventArgs argumentos = e as MoveRoutedEventArgs;
          //  Console.WriteLine($" sender {sender}");
            if (argumentos != null)
            {
                double nextTop = argumentos[0][0] - argumentos[1][0];
                double nextLeft = argumentos[0][1] - argumentos[1][1];

                foreach (IContent element in ProgramManager.ActiveScreen.Screen.Elements)
                {
                    CanvasContentControl cccElement = (element.CanvasContetControlInstance as CanvasContentControl);
                    if (cccElement.IsSelectedCCC == true)
                    {
                        if (ProgramManager.ActiveScreen.Screen.ActiveElement != element)
                        {
                            cccElement.IContentFather.elementData.XPos = Canvas.GetLeft(cccElement) + nextLeft;
                            cccElement.IContentFather.elementData.YPos = Canvas.GetTop(cccElement) + nextTop;
                            //   Canvas.SetTop(cccElement, Canvas.GetTop(cccElement) + nextTop);
                            //   Canvas.SetLeft(cccElement, Canvas.GetLeft(cccElement) + nextLeft);
                        }
                    }
                }
                if (ProgramManager.ActiveScreen.Screen.ActiveElement != null)
                {
                    //   Console.WriteLine($"here 2 {ProgramManager.ActiveControl.ActiveControl.Name}");

                    ProgramManager.ActiveScreen.Screen.ActiveElement.CanvasContetControlInstance.IContentFather.elementData.YPos = Canvas.GetTop(ProgramManager.ActiveScreen.Screen.ActiveElement.CanvasContetControlInstance) + nextTop;
                    ProgramManager.ActiveScreen.Screen.ActiveElement.CanvasContetControlInstance.IContentFather.elementData.XPos = Canvas.GetLeft(ProgramManager.ActiveScreen.Screen.ActiveElement.CanvasContetControlInstance) + nextLeft;

                }
            }
        }

        public static void ScaleEvent(RoutedEventArgs e)
        {
            MoveScaleRoutedEventArgs argumentos = e as MoveScaleRoutedEventArgs;

            double ScaleX = argumentos.MyProperty[0][1] - argumentos.MyProperty[1][1];
            double ScaleY = argumentos.MyProperty[0][0] - argumentos.MyProperty[1][0];
            double nextTop = argumentos.MyProperty[0][2] - argumentos.MyProperty[1][2];
            double nextLeft = argumentos.MyProperty[0][3] - argumentos.MyProperty[1][3];

            foreach (IContent element in ProgramManager.ActiveScreen.Screen.Elements)
            {
                CanvasContentControl cccElement = (element.CanvasContetControlInstance as CanvasContentControl);
                if (cccElement.IsSelectedCCC == true)
                {
                    //  cccElement.Width = cccElement.ActualWidth + ScaleX;
                    // cccElement.Height = cccElement.ActualHeight + ScaleY;

                    //  cccElement.Height = _scaleChanges[1];
                   ((SimpleTextImageElement) element).elementData.Height = cccElement.ActualHeight + ScaleY;
                   ((SimpleTextImageElement)element).elementData.Width = cccElement.ActualWidth + ScaleX;


                    Canvas.SetTop(cccElement, Canvas.GetTop(cccElement) + nextTop);
                    Canvas.SetLeft(cccElement, Canvas.GetLeft(cccElement) + nextLeft);
                }
            }


        }
    }
}
