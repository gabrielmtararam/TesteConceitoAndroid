using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PrototypeGuiCompositor30.Annotations;
using PrototypeGuiCompositor30.DataModels;
using PrototypeGuiCompositor30.interfaces;

namespace PrototypeGuiCompositor30.elements
{
    public class SimpleTextImageElement:IContent
    {


        [Browsable(false)]
        public Panel Content { get; set; }

        [Browsable(false)] public  CanvasContentControl CanvasContetControlInstance { get; set; }

        [Browsable(false)] public Boolean IsSelected { get; set; }

        public ElementContentDataModel elementData { get; set; } = new ElementContentDataModel();

        public SimpleTextImageElement()
        {
            Grid stack = new Grid();
            elementData.Text = "";
            TextBlock TxtbAux = new TextBlock();

            TxtbAux.Text = elementData.Text;
            TxtbAux.TextWrapping = TextWrapping.Wrap;

            stack.Children.Add(TxtbAux);
            Content = stack;
            elementData.Height = 40;
            CanvasContetControlInstance = new CanvasContentControl();
            CanvasContetControlInstance.Content = Content;
            CanvasContetControlInstance.IContentFather = this;
            this.elementData.Name = this.GetHashCode()+"";
            elementData.PropertyChanged += OnPropertyChanged;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        
        protected  void OnPropertyChanged(Object sender, PropertyChangedEventArgs  _propertyName = null)
        {  
           
            String propertyName = (String) _propertyName.PropertyName;
            if (CanvasContetControlInstance != null)
            {

                ProgramManager.uptadePropertyGrid();
                switch (propertyName)
                {
                    case "BackgroundColor":
          
                        CanvasContetControlInstance.Background =(SolidColorBrush) new SolidColorBrush(elementData.BackgroundColor);
                        break;
                    case "FontColor":
                        ((TextBlock)(((Panel)Content).Children[0])).Foreground = new SolidColorBrush(elementData.FontColor);
                        break;
                    case "Height":
                        CanvasContetControlInstance.Height = elementData.Height;
                        break;
                    case "Width":
                        CanvasContetControlInstance.Width = elementData.Width;
                        break;
                    case "FontSize":
                        ((TextBlock)(((Panel)Content).Children[0])).FontSize = elementData.FontSize;
                        break;
                    case "Text":
                        ((TextBlock)(((Panel)Content).Children[0])).Text = elementData.Text;
                        break;
                    case "TextHorizontalAligment":
                        ((TextBlock)(((Panel)Content).Children[0])).HorizontalAlignment = (HorizontalAlignment) elementData.TextHorizontalAligment;
                        break;
                    case "TextVerticalAligment":
                        ((TextBlock)(((Panel)Content).Children[0])).VerticalAlignment =(VerticalAlignment) elementData.TextVerticalAligment;
                        break;
                    case "FontFamily":
                        ((TextBlock)(((Panel)Content).Children[0])).FontFamily = elementData.FontFamily;
                        break;
                    case "FontStyles":
                        ((TextBlock)(((Panel)Content).Children[0])).FontStyle =(FontStyle) elementData.FontStyles;
                        break;
                    case "FontWeight":
                        ((TextBlock)(((Panel)Content).Children[0])).FontWeight =(FontWeight) elementData.FontWeight;
                        break;
                    case "XPos":
                        Canvas.SetLeft(CanvasContetControlInstance, elementData.XPos);
                        break;
                    case "YPos":
                        Canvas.SetTop(CanvasContetControlInstance, elementData.YPos);
                        break;
                }
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
