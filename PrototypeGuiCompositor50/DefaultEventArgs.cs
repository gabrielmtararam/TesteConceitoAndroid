using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace PrototypeGuiCompositor30
{



    public class MoveScaleRoutedEventArgs : RoutedEventArgs
    {

        public MoveScaleRoutedEventArgs(RoutedEvent routedEvent, Object source, List<List<double>> result) : base(routedEvent, source)
        {
            MyProperty = result; ;

        }
        public List<List<double>> MyProperty { get; set; }

    }


    public class MoveRoutedEventArgs : RoutedEventArgs
    {
        public MoveRoutedEventArgs(RoutedEvent routedEvent, Object source, List<List<double>> result) : base(routedEvent, source)
        {
            MyProperty = result; ;

        }
        public List<List<double>> MyProperty { get; set; }

    }

    public class RotateRoutedEventArgs : RoutedEventArgs
    {
        public RotateRoutedEventArgs(RoutedEvent routedEvent, Object source, List<RotateTransform> result) : base(routedEvent, source)
        {
            MyProperty = result; ;

        }
        public List<RotateTransform> MyProperty { get; set; }

    }
}
