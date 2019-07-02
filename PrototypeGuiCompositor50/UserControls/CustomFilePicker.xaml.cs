using System;
using System.Collections.Generic;
using System.IO;
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
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace PrototypeGuiCompositor30.UserControls
{
    /// <summary>
    /// Interaction logic for CustomFilePicker.xaml
    /// </summary>
    public partial class CustomFilePicker : UserControl, ITypeEditor
    {
        public CustomFilePicker()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(string), typeof(CustomFilePicker),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Value = string.Empty;
        }

        public FrameworkElement ResolveEditor(Xceed.Wpf.Toolkit.PropertyGrid.PropertyItem propertyItem)
        {
            Binding binding = new Binding("Value");
            binding.Source = propertyItem;
            binding.Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay;
            BindingOperations.SetBinding(this, CustomFilePicker.ValueProperty, binding);
            return this;

          //  Button teste;
          //  teste
        }

        private void ChooseFile(object sender, RoutedEventArgs e)
        {


            var ofd = new Microsoft.Win32.OpenFileDialog() { Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif" };
            var result = ofd.ShowDialog();
            if (result == true)
            {
                Value = ofd.FileName;
                //  _layoutRoot.Background = new System.Windows.Media.ImageBrush(GetImageSource(dlg.FileName));
                //  ProgramManager.ActiveControl.ActiveControl.Content2SimpleButton.Background = new System.Windows.Media.ImageBrush(Value);
                BitmapImage glowIcon = new BitmapImage();

                glowIcon.BeginInit();
                glowIcon.UriSource = new Uri(Value);
                glowIcon.EndInit();

              ((SimpleTextImageElement)ProgramManager.ActiveScreen.Screen.ActiveElement).elementData.ImageSource = glowIcon;
              ProgramManager.ActiveScreen.Screen.ActiveElement.Content.Background = new System.Windows.Media.ImageBrush(glowIcon);
            }
            else
            {
                ProgramManager.ActiveScreen.Screen.ActiveElement.Content.Background = new SolidColorBrush(Colors.Transparent);

            }

            e.Handled=true;
        }

        private void ChooseFileByName(object sender, RoutedEventArgs e)
        {
            if (File.Exists(TextBox.Text))
            {
                BitmapImage glowIcon = new BitmapImage();

                glowIcon.BeginInit();
                glowIcon.UriSource = new Uri(TextBox.Text);
                glowIcon.EndInit();

                ((SimpleTextImageElement)ProgramManager.ActiveScreen.Screen.ActiveElement).elementData.ImageSource = glowIcon;
                ProgramManager.ActiveScreen.Screen.ActiveElement.Content.Background = new System.Windows.Media.ImageBrush(glowIcon);
            }
            else
            {
                ProgramManager.ActiveScreen.Screen.ActiveElement.Content.Background = new SolidColorBrush(Colors.Transparent);
            }
        }
    }
}
