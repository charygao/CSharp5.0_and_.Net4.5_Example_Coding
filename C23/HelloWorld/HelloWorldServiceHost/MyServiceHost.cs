using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
namespace HelloWorldServiceHost
{
    //服务的宿主
    class ServiceHostMainClass
    {
        /// <summary>
        /// 入口方法
        /// </summary>
        static void Main(string[] args)
        {
            //由于MyHostService实现了IDisposable接口，所以使用using
            using (MySerivceHost host = new MySerivceHost())
            {
                host.Open();
                //等待客户端访问
                Console.Read();
            }
        }
    }

    /// <summary>
    /// 封装了ServiceHost和其构造过程
    /// </summary>
    public class MySerivceHost:IDisposable
    {
        //ServiceHost对象
        private ServiceHost _myHost;
        //基地址
        public const String BaseAddress = "net.pipe://192.168.1.102/";
        //可选地址
        public const String HelloWorldServiceAddress = "HelloWorldService";
        //服务契约定义类型
        public static readonly Type ContractType = typeof(HelloWorldService.IService);
        //服务契约实现类型
        public static readonly Type ServiceType = typeof(HelloWorldService.Service);
        //服务只定义了一个绑定
        public static readonly Binding HelloWorldBinding = new NetNamedPipeBinding();
        /// <summary>
        /// 构造ServiceHost对象
        /// </summary>
        protected void ConstructServiceHost()
        {
            //初始化ServiceHost对象
            _myHost = new ServiceHost(ServiceType, new Uri[] { new Uri(BaseAddress) });
            //添加一个终结点
            _myHost.AddServiceEndpoint(ContractType, HelloWorldBinding, HelloWorldServiceAddress);
        }
        /// <summary>
        /// ServiceHost只读属性
        /// </summary>
        public ServiceHost Host
        {
            get
            {
                return _myHost;
            }
        }
        /// <summary>
        /// 打开服务
        /// </summary>
        public void Open()
        {
            Console.WriteLine("开始启动服务。。。");
            _myHost.Open();
            Console.WriteLine("服务已经启动。。。");
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        public MySerivceHost()
        {
            ConstructServiceHost();
        }
        /// <summary>
        /// ServiceHost实现了IDisposable接口，这里调用它的Dispose方法
        /// </summary>
        public void Dispose()
        {
            //ServiceHost显示实现了IDisposable的Dispose方法，所以这里要先强制转换成IDisposable类型
            if (_myHost != null)
                (_myHost as IDisposable).Dispose();
        }
    }
}
