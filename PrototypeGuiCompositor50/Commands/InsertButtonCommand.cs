using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using PrototypeGuiCompositor30.elements;

namespace PrototypeGuiCompositor30
{
    class InsertButtonCommand:ICommand
    {
        double _top;
        double _left;
        IScreen _screen;
        IContent _element;
        UserControl _canvasContainerControl;
        CanvasContentControl _contentControl;
        

        public InsertButtonCommand(IScreen screen, UserControl canvasContainerControl, double left, double top)
        {
            _screen = screen;
            _top = top;
            _left = left;
            _element = new SimpleTextImageElement();
            _canvasContainerControl = canvasContainerControl;
            _contentControl = (_element as IContent).CanvasContetControlInstance as CanvasContentControl;

            //_contentControl.Content2SimpleButton = ControlsFactory.LoadDefaultButton(_contentControl);
           // _contentControl.Content2 = _contentControl.Content2SimpleButton.controle;


            _contentControl.MinHeight = 40;
            _contentControl.MinWidth =40;
            Execute();
        }
        public void Execute()
        {
            _screen.Elements.Add(_element);
            (_canvasContainerControl.Content as Canvas).Children.Add(((_element as IContent).CanvasContetControlInstance as CanvasContentControl));
            Canvas.SetTop(_contentControl, _top);
            Canvas.SetLeft(_contentControl, _left);
        }
        public void Undo()
        {
            _screen.Elements.Remove(_element);
            (_canvasContainerControl.Content as Canvas).Children.Remove(((_element as IContent).CanvasContetControlInstance as CanvasContentControl));
        }
        public void Redo()
        {
            Execute();
        }
    }
}
