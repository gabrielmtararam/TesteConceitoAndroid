using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;
using PrototypeGuiCompositor30.Annotations;
using PrototypeGuiCompositor30.interfaces;
using PrototypeGuiCompositor30.Properties;
using Color = System.Windows.Media.Color;
using FontFamily = System.Windows.Media.FontFamily;
using FontStyle = System.Drawing.FontStyle;
using Image = System.Windows.Controls.Image;


namespace PrototypeGuiCompositor30.UserControls
{
   public class SimpleButton:IController,INotifyPropertyChanged
    {
        [Browsable(false)]
        public Panel controle { get; set; }

        private CanvasContentControl contentControl;

        public Image imageContent;

     // public Image BtnImage { get; set; }

     public ImageSource ImageSource{
         get{
             return this.ImageSourceProp;}
         set{
             if (value != this.ImageSourceProp){
                 this.ImageSourceProp = (ImageSource)value;
                 OnPropertyChanged();
             }}}
     public ImageSource ImageSourceProp;

     [Category("Text")]
        public Double FontSize
     {
         get
         {
             return this.FontSizeProp;
         }
         set
         {
             if (value != this.FontSizeProp)
             {
                 this.FontSizeProp = (Double)value;
                 OnPropertyChanged();
             }
         }
     }
     public Double FontSizeProp;

     [Category("Text")]
        public String Text
        {
         get
         {
             return this.TextProp;
         }
         set
         {
             if (value != this.TextProp)
             {
                 this.TextProp = (String)value;
                 OnPropertyChanged();
             }
         }

     }
     public String TextProp;

     [Category("Text")]
        public Color FontColor
     {
         get
         {
             return this.FontColorProp;
         }
         set
         {
             if (value != this.FontColorProp)
             {
                 this.FontColorProp = (Color)value;
                 OnPropertyChanged();
             }
         }
     }
     public Color FontColorProp;

     [Category("Text")]
        public FontFamily FontFamily
     {
         get
         {
             return this.FontFamilyProp;
         }
         set
         {
             if (value != this.FontFamilyProp)
             {
                 this.FontFamilyProp = (FontFamily)value;
                 OnPropertyChanged();
             }
         }
     }
     public FontFamily FontFamilyProp;

     [Category("Text")]
        public System.Windows.FontStyle FontStyles { 
         get
         {
             return this.FontStyleProp;
         }
         set
         {
             if (value != this.FontStyleProp)
             {
                 this.FontStyleProp = (System.Windows.FontStyle)value;
                 OnPropertyChanged();
             }
         }
     }
     public System.Windows.FontStyle FontStyleProp;

     [Category("Text")]
        public System.Windows.FontWeight FontWeight
     {
         get
         {
             return this.FontWeightProp;
         }
         set
         {
             if (value != this.FontWeightProp)
             {
                 this.FontWeightProp = (System.Windows.FontWeight)value;
                 OnPropertyChanged();
             }
         }
     }
     public System.Windows.FontWeight FontWeightProp;

     [Category("Text")]
        public HorizontalAlignment TextHorizontalAligment
        {
         get
         {
             return this.TextHorizontalAligmentProp;
         }
         set
         {
             if (value != this.TextHorizontalAligmentProp)
             {
                 this.TextHorizontalAligmentProp = (HorizontalAlignment)value;
                 OnPropertyChanged();
             }
         }
     }

     public HorizontalAlignment TextHorizontalAligmentProp;
     [Category("Text")]
        public VerticalAlignment TextVerticalAligment
     {
         get
         {
             return this.TextVerticalAligmentProp;
         }
         set
         {
             if (value != this.TextVerticalAligmentProp)
             {
                 this.TextVerticalAligmentProp = (VerticalAlignment)value;
                 OnPropertyChanged();
             }
         }
     }
        public VerticalAlignment TextVerticalAligmentProp;

        public Color BackgroundColor
        {
            get
            {
                return this.BackgroundColorProp;
            }
            set
            {
                if (value != this.BackgroundColorProp)
                {
                    this.BackgroundColorProp = (Color)value;
                    OnPropertyChanged();
                }
            }
        }
        public Color BackgroundColorProp;

        public Double Height
        {
            get
            {
                return this.HeightProp;
            }
            set
            {
                if (value != this.HeightProp)
                {
                    this.HeightProp = value;
                    OnPropertyChanged();
                }
            }
        }
        public Double HeightProp = new Double();

        public Double Width
        {
            get
            {
                return this.WidthProp;
            }
            set
            {
                if (value != this.WidthProp)
                {
                    this.WidthProp = value;
                    OnPropertyChanged();
                }
            }
        }
        public Double WidthProp = new Double();


        public SimpleButton(CanvasContentControl ccc)
        {
            Grid stack = new Grid();
            Text = "";
            TextBlock TxtbAux = new TextBlock();
            
            
            

            TxtbAux.Text = Text;
            TxtbAux.TextWrapping = TextWrapping.Wrap;

            stack.Children.Add(TxtbAux);
            controle = stack;
            Height = 40;
            contentControl = ccc;
            


        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (contentControl != null)
            {
                switch (propertyName)
                {
                    case "BackgroundColor":
                        contentControl.Background = new SolidColorBrush(BackgroundColor);
                        break;
                    case "FontColor":
                        ((TextBlock) (((Panel) controle).Children[0])).Foreground = new SolidColorBrush(FontColor);
                        break;
                    case "Height":
                            contentControl.Height = Height;
                        break;
                    case "Width":
                        contentControl.Width = Width;
                        break;
                    case "FontSize":
                            ((TextBlock) (((Panel) controle).Children[0])).FontSize = FontSize;
                        break;
                    case "Text":
                        ((TextBlock)(((Panel)controle).Children[0])).Text = Text;
                        break;
                    case "TextHorizontalAligment":
                        ((TextBlock)(((Panel)controle).Children[0])).HorizontalAlignment = TextHorizontalAligment;
                        break;
                    case "TextVerticalAligment":
                        ((TextBlock)(((Panel)controle).Children[0])).VerticalAlignment = TextVerticalAligment;
                        break; 
                    case "FontFamily":
                        ((TextBlock)(((Panel)controle).Children[0])).FontFamily = FontFamily;
                        break; 
                    case "FontStyles":
                        ((TextBlock)(((Panel)controle).Children[0])).FontStyle = FontStyles;
                        break;
                    case "FontWeight":
                        ((TextBlock)(((Panel)controle).Children[0])).FontWeight = FontWeight;
                        break;
                }
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
