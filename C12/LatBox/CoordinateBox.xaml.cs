using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace LatBox
{
    /// <summary>
    /// Interaction logic for CoordinateBox.xaml
    /// </summary>

    public partial class CoordinateBox : System.Windows.Controls.UserControl
    {
        public CoordinateBox()
        {
            InitializeComponent();
        }

        //声明并注册依赖属性
        public static DependencyProperty ValueProperty = DependencyProperty.Register("Value",
            typeof(Coordinate), typeof(CoordinateBox),
            new FrameworkPropertyMetadata(null,
            FrameworkPropertyMetadataOptions.AffectsMeasure |
            FrameworkPropertyMetadataOptions.AffectsRender |
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | 
            FrameworkPropertyMetadataOptions.Inherits,
            new PropertyChangedCallback(OnValueChanged),
            new CoerceValueCallback(CoerceValue)));
        //使用标准.NET属性包装依赖属性
        public Coordinate Value
        {
            get { return (Coordinate)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        //定义强制值回调，限制输入的数据不可以小于0，大于90，小于-180，大于180.
        static object CoerceValue(DependencyObject sender, object value)
        {
            Coordinate val = value as Coordinate;
            //如果值不为空，判断经纬度的大小，调整用户的输入，使其为特定值
            if (val != null)
            {
                if (val.Latitude < 0)
                {
                    val.Latitude = 0;
                }
                else if (val.Latitude > 90)
                {
                    val.Latitude = 90;
                }
                if (val.Longitude < -180)
                {
                    val.Longitude = -180;
                }
                else if (val.Longitude > 180)
                {
                    val.Longitude = 180;
                }
            }
            return val;
        }
        //属性值变更时，触发用户界面的更新，并更新用户界面
        static void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            CoordinateBox box = sender as CoordinateBox;
            //更新文本框的值
            box.UpdateValue();
            //定义路由事件参数
            RoutedPropertyChangedEventArgs<Coordinate> e = new RoutedPropertyChangedEventArgs<Coordinate>(
                (Coordinate)args.OldValue, (Coordinate)args.NewValue, ValueChangedEvent);
            //触发路由事件
            box.OnValueChanged(e);
        }
        //更新文本框
        private void UpdateValue()
        {
            this.Lat.Text = Value.Latitude.ToString();
            this.Lon.Text = Value.Longitude.ToString();
        }
        //触发事件
        private void OnValueChanged(RoutedPropertyChangedEventArgs<Coordinate> e)
        {
            RaiseEvent(e);
        }
        //定义并注册路由事件
        public static readonly RoutedEvent ValueChangedEvent = EventManager.RegisterRoutedEvent(
           "ValueChanged", RoutingStrategy.Bubble,
           typeof(RoutedPropertyChangedEventHandler<Coordinate>), typeof(CoordinateBox));
        //定义标准的事件属性
        public event RoutedPropertyChangedEventHandler<Coordinate> ValueChanged
        {
            add { AddHandler(ValueChangedEvent, value); }
            remove { RemoveHandler(ValueChangedEvent, value); }
        }
        //当文本框内容改变时，为用户控件的Value属性赋值
        void onTextChanged(object sender, TextChangedEventArgs e)
        {
            double lat = 0;
            double lon = 0;
            if (double.TryParse(Lat.Text == String.Empty ? "0" : Lat.Text, out lat) &
                double.TryParse(Lon.Text == String.Empty ? "0" : Lon.Text, out lon))
            {
                Value = new Coordinate(lat, lon);
            }
            else
            {
                UpdateValue();
            }
        }

       
    }
    /// <summary>
    /// 定义依赖属性的类型，为了支持绑定更新功能，该类实现了INotifyPropertyChanged接口
    /// </summary>
    public class Coordinate : INotifyPropertyChanged
    {
        //构造函数
        public Coordinate(double lat, double lon)
        {
            this.Latitude = lat;
            this.Longitude = lon;
        }
        private double m_lat;
        //定义纬度
        public double Latitude
        {
            get { return m_lat; }
            set { 
                m_lat = value; 
                FirePropertyChanged("Latitude");
            }
        }
        private double m_long;
        //定义经度
        public double Longitude
        {
            get { return m_long; }
            set { 
                m_long = value; 
                FirePropertyChanged("Longitude"); 
            }
        }	
        #region INotifyPropertyChanged Members
        //用于触发事件的辅助方法
        internal void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        //定义事件，供调用方订阅此事件
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}