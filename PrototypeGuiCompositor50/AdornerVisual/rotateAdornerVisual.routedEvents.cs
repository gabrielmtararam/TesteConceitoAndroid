using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PrototypeGuiCompositor30
{
    public partial class RotateAdornerVisual : UserControl
    {
        public static readonly RoutedEvent RotateRoutedEvent =
      EventManager.RegisterRoutedEvent(
     "Rotate",
     RoutingStrategy.Bubble,
     typeof(RoutedEventHandler),
     typeof(RotateAdornerVisual));

        public event RoutedEventHandler Rotate
        {
            add { AddHandler(RotateRoutedEvent, value); }
            remove { RemoveHandler(RotateRoutedEvent, value); }
        }



        public static readonly RoutedEvent RotateFinishRoutedEvent =
              EventManager.RegisterRoutedEvent(
             "RotateFinish",
             RoutingStrategy.Bubble,
             typeof(RoutedEventHandler),
             typeof(RotateAdornerVisual));

        public event RoutedEventHandler RotateFinish
        {
            add { AddHandler(RotateFinishRoutedEvent, value); }
            remove { RemoveHandler(RotateFinishRoutedEvent, value); }
        }
    }
}
