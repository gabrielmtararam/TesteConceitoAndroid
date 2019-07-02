using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GuiCompositorTry1.VisualAdroner
{
    public partial class MoveScaleAdornerVisual : System.Windows.Controls.UserControl
    {



        public static readonly RoutedEvent MoveScaleRoutedEvent =
       EventManager.RegisterRoutedEvent(
           "MoveScale",
           RoutingStrategy.Bubble,
           typeof(RoutedEventHandler),
           typeof(MoveScaleAdornerVisual));

        public event RoutedEventHandler MoveScale
        {
            add { AddHandler(MoveScaleRoutedEvent, value); }
            remove { RemoveHandler(MoveScaleRoutedEvent, value); }
        }


        public static readonly RoutedEvent MoveScaleFinishRoutedEvent =
    EventManager.RegisterRoutedEvent(
   "MoveScaleFinish",
   RoutingStrategy.Bubble,
   typeof(RoutedEventHandler),
   typeof(MoveScaleAdornerVisual));

        public event RoutedEventHandler MoveScaleFinish
        {
            add { AddHandler(MoveScaleFinishRoutedEvent, value); }
            remove { RemoveHandler(MoveScaleFinishRoutedEvent, value); }
        }

    }
}
