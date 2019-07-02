using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PrototypeGuiCompositor30
{
    class ScaleElementCommand:ICommand
    {
        FrameworkElement _element;
        List<double> _scaleChanges;
        List<double> _scaleBefore;
      
        public ScaleElementCommand(FrameworkElement element, List<double> scaleChanges, List<double> scaleBefore)
        {
            _element = element;
            _scaleChanges = scaleChanges;
            _scaleBefore = scaleBefore;
            Execute();
        }
        public void Execute()
        {
            Canvas.SetTop(_element, _scaleChanges[2]);
            Canvas.SetLeft(_element, _scaleChanges[3]);
       //     _element.Width = _scaleChanges[1];
            ((CanvasContentControl) _element).Height = _scaleChanges[0];
            ((CanvasContentControl)_element).Width = _scaleChanges[1];
            // _element.Height = _scaleChanges[0];
        }
        public void Undo()
        {
            Canvas.SetTop(_element, _scaleBefore[2]);
            Canvas.SetLeft(_element, _scaleBefore[3]);
            ((CanvasContentControl)_element).Height = _scaleBefore[0];
            ((CanvasContentControl)_element).Width = _scaleBefore[1];
        }
        public void Redo()
        {
            Execute();
        }
    }
}
