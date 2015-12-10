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

        //������ע����������
        public static DependencyProperty ValueProperty = DependencyProperty.Register("Value",
            typeof(Coordinate), typeof(CoordinateBox),
            new FrameworkPropertyMetadata(null,
            FrameworkPropertyMetadataOptions.AffectsMeasure |
            FrameworkPropertyMetadataOptions.AffectsRender |
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | 
            FrameworkPropertyMetadataOptions.Inherits,
            new PropertyChangedCallback(OnValueChanged),
            new CoerceValueCallback(CoerceValue)));
        //ʹ�ñ�׼.NET���԰�װ��������
        public Coordinate Value
        {
            get { return (Coordinate)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        //����ǿ��ֵ�ص���������������ݲ�����С��0������90��С��-180������180.
        static object CoerceValue(DependencyObject sender, object value)
        {
            Coordinate val = value as Coordinate;
            //���ֵ��Ϊ�գ��жϾ�γ�ȵĴ�С�������û������룬ʹ��Ϊ�ض�ֵ
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
        //����ֵ���ʱ�������û�����ĸ��£��������û�����
        static void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            CoordinateBox box = sender as CoordinateBox;
            //�����ı����ֵ
            box.UpdateValue();
            //����·���¼�����
            RoutedPropertyChangedEventArgs<Coordinate> e = new RoutedPropertyChangedEventArgs<Coordinate>(
                (Coordinate)args.OldValue, (Coordinate)args.NewValue, ValueChangedEvent);
            //����·���¼�
            box.OnValueChanged(e);
        }
        //�����ı���
        private void UpdateValue()
        {
            this.Lat.Text = Value.Latitude.ToString();
            this.Lon.Text = Value.Longitude.ToString();
        }
        //�����¼�
        private void OnValueChanged(RoutedPropertyChangedEventArgs<Coordinate> e)
        {
            RaiseEvent(e);
        }
        //���岢ע��·���¼�
        public static readonly RoutedEvent ValueChangedEvent = EventManager.RegisterRoutedEvent(
           "ValueChanged", RoutingStrategy.Bubble,
           typeof(RoutedPropertyChangedEventHandler<Coordinate>), typeof(CoordinateBox));
        //�����׼���¼�����
        public event RoutedPropertyChangedEventHandler<Coordinate> ValueChanged
        {
            add { AddHandler(ValueChangedEvent, value); }
            remove { RemoveHandler(ValueChangedEvent, value); }
        }
        //���ı������ݸı�ʱ��Ϊ�û��ؼ���Value���Ը�ֵ
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
    /// �����������Ե����ͣ�Ϊ��֧�ְ󶨸��¹��ܣ�����ʵ����INotifyPropertyChanged�ӿ�
    /// </summary>
    public class Coordinate : INotifyPropertyChanged
    {
        //���캯��
        public Coordinate(double lat, double lon)
        {
            this.Latitude = lat;
            this.Longitude = lon;
        }
        private double m_lat;
        //����γ��
        public double Latitude
        {
            get { return m_lat; }
            set { 
                m_lat = value; 
                FirePropertyChanged("Latitude");
            }
        }
        private double m_long;
        //���徭��
        public double Longitude
        {
            get { return m_long; }
            set { 
                m_long = value; 
                FirePropertyChanged("Longitude"); 
            }
        }	
        #region INotifyPropertyChanged Members
        //���ڴ����¼��ĸ�������
        internal void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        //�����¼��������÷����Ĵ��¼�
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}