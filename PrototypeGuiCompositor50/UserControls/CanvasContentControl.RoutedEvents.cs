using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PrototypeGuiCompositor30
{
    public partial class CanvasContentControl : UserControl
    {

        public static readonly RoutedEvent MoveRoutedEvent =
              EventManager.RegisterRoutedEvent(
                  "Move",
                  RoutingStrategy.Bubble,
                  typeof(RoutedEventHandler),
                  typeof(MoveScaleAdornerVisual));

        public event RoutedEventHandler Move
        {
            add { AddHandler(MoveRoutedEvent, value); }
            remove { RemoveHandler(MoveRoutedEvent, value); }
        }


        public static readonly RoutedEvent MoveRoutedFinishEvent =
       EventManager.RegisterRoutedEvent(
           "MoveFinish",
           RoutingStrategy.Bubble,
           typeof(RoutedEventHandler),
           typeof(MoveScaleAdornerVisual));

        public event RoutedEventHandler MoveFinish
        {
            add { AddHandler(MoveRoutedFinishEvent, value); }
            remove { RemoveHandler(MoveRoutedFinishEvent, value); }
        }
    }
}
