using System;
using System.Collections.Generic;
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

namespace WPFbase1_Lesson6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    class WeatherControl:DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;
        //public static readonly DependencyProperty WindProperty;
        private string wind;
        //public static readonly DependencyProperty WindvelocityProperty;
        private int windvelocity;
        //public static readonly DependencyProperty WheathertypeProperty;
        private int wheathertype;
        enum whewheathertype
        {
            sunny=0,
            cloudy=1,
            rainy=2,
            snowly=3
        }

        public int Temperature
        {
            get => (int) GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }
        public string Wind
        {
            get => wind;
            set => wind = value;
        }
        public int Windvelocity
        {
            get => windvelocity;
            set => windvelocity = value;
        }
        public int Wheathertype
        {
            get => wheathertype;
            set => wheathertype = value;
        }
        public WeatherControl(int temperature, string wind, int windvelocity, int wheathertype)
        {
            this.Temperature = temperature;
            this.Wind = wind;
            this.Windvelocity = windvelocity;
            this.Wheathertype = wheathertype;
        }
        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender |
                    FrameworkPropertyMetadataOptions.Journal,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                    new ValidateValueCallback(ValidateTemperature));
        }

        private static bool ValidateTemperature(object value)
        {
            int t = (int)value;
            if (t >= -50 && t <= 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int t = (int)baseValue;
            if (t >= -50 && t <= 50)
            {
                return t;
            }
            else
            {
                if (t < -50)
                {
                    return -50;
                }
                return 50;
            }
        }
        public string Print()
        {
            return $"{Temperature} {Wind} {Windvelocity} {Wheathertype}";
        }

    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            


        }
    }
}
