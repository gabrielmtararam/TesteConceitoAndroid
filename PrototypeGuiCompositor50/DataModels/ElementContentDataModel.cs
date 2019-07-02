using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Windows.Media;
using PrototypeGuiCompositor30.Annotations;
using Color = System.Drawing.Color;
using FontFamily = System.Drawing.FontFamily;

namespace PrototypeGuiCompositor30.DataModels
{
    public class ElementContentDataModel
    {
        public ImageSource ImageSource
        {
            get { return this.ImageSourceProp; }
            set
            {
                if (value != this.ImageSourceProp)
                {
                    this.ImageSourceProp = (ImageSource) value;
                    OnPropertyChanged();
                }
            }
        }

        public ImageSource ImageSourceProp;

        [Category("Text")]
        public Double FontSize
        {
            get { return this.FontSizeProp; }
            set
            {
                if (value != this.FontSizeProp)
                {
                    this.FontSizeProp = (Double) value;
                    OnPropertyChanged();
                }
            }
        }

        public Double FontSizeProp;

        [Category("Text")]
        public String Text
        {
            get { return this.TextProp; }
            set
            {
                if (value != this.TextProp)
                {
                    this.TextProp = (String) value;
                    OnPropertyChanged();
                }
            }

        }

        public String TextProp;


        public String Name
        {
            get { return this.NameProp; }
            set
            {
                if (value != this.NameProp)
                {
                    this.NameProp = (String) value;
                    OnPropertyChanged();
                }
            }

        }

        public String NameProp;

        [Category("Text")]
        public System.Windows.Media.Color FontColor
        {
            get { return this.FontColorProp; }
            set
            {
                if (value != this.FontColorProp)
                {
                    this.FontColorProp = (System.Windows.Media.Color)value;
                    OnPropertyChanged();
                }
            }
        }

        public System.Windows.Media.Color FontColorProp;

        [Category("Text")]
        public System.Windows.Media.FontFamily FontFamily
        {
            get { return this.FontFamilyProp; }
            set
            {
                if (value != this.FontFamilyProp)
                {
                    this.FontFamilyProp = (System.Windows.Media.FontFamily) value;
                    OnPropertyChanged();
                }
            }
        }
        public System.Windows.Media.FontFamily FontFamilyProp;


        [Category("Text")]
        public System.Windows.FontStyle FontStyles
        {
            get { return this.FontStyleProp; }
            set
            {
                if (value != this.FontStyleProp)
                {
                    this.FontStyleProp = (System.Windows.FontStyle) value;
                    OnPropertyChanged();
                }
            }
        }

        public System.Windows.FontStyle FontStyleProp;

        [Category("Text")]
        public System.Windows.FontWeight FontWeight
        {
            get { return this.FontWeightProp; }
            set
            {
                if (value != this.FontWeightProp)
                {
                    this.FontWeightProp = (System.Windows.FontWeight) value;
                    OnPropertyChanged();
                }
            }
        }

        public System.Windows.FontWeight FontWeightProp;

        [Category("Text")]
        public HorizontalAlignment TextHorizontalAligment
        {
            get { return this.TextHorizontalAligmentProp; }
            set
            {
                if (value != this.TextHorizontalAligmentProp)
                {
                    this.TextHorizontalAligmentProp = (HorizontalAlignment) value;
                    OnPropertyChanged();
                }
            }
        }

        public HorizontalAlignment TextHorizontalAligmentProp;

        [Category("Text")]
        public VerticalAlignment TextVerticalAligment
        {
            get { return this.TextVerticalAligmentProp; }
            set
            {
                if (value != this.TextVerticalAligmentProp)
                {
                    this.TextVerticalAligmentProp = (VerticalAlignment) value;
                    OnPropertyChanged();
                }
            }
        }

        public VerticalAlignment TextVerticalAligmentProp;

        public System.Windows.Media.Color BackgroundColor
        {
            get { return this.BackgroundColorProp; }
            set
            {
                if (value != this.BackgroundColorProp)
                {
                    this.BackgroundColorProp = (System.Windows.Media.Color) value;
                    OnPropertyChanged();
                }
            }
        }

        public System.Windows.Media.Color BackgroundColorProp;

        public Double Height
        {
            get { return this.HeightProp; }
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


        public Double XPos
        {
            get { return this.XPosProp; }
            set
            {
                if (value != this.XPosProp)
                {
                    this.XPosProp = value;
                    OnPropertyChanged();
                }
            }
        }

        public Double XPosProp = new Double();



        public Double YPos
        {
            get { return this.YPosProp; }
            set
            {
                if (value != this.YPosProp)
                {
                    this.YPosProp = value;
                    OnPropertyChanged();
                }
            }
        }

        public Double YPosProp = new Double();


        public Double Width
        {
            get { return this.WidthProp; }
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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
