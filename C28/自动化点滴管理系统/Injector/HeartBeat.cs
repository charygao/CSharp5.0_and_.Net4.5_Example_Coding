using System;
using System.Threading;
using System.Configuration;
namespace WCF.CaseStudy
{
    internal class HeartBeat:IDisposable
    {
        //心跳定时器
        private Timer _hbTimer;
        //心跳周期
        public static readonly TimeSpan HBInterval = TimeSpan.FromSeconds(1);
        //服务代理引用
        private ServiceProxy _proxy;
        //床号
        private int _bedNo;
        //窗体引用
        private InjectorConsole _console;
        //禁止公共的无参构造
        private HeartBeat() { }
        /// <summary>
        /// 构造方法
        /// </summary>
        public HeartBeat(ServiceProxy proxy, InjectorConsole console)
        {
            _proxy = proxy;
            String bedNoValue = ConfigurationManager.AppSettings["bedNo"];
            if (!Int32.TryParse(bedNoValue, out _bedNo))
            {
                throw new ConfigurationErrorsException("床号配置错误！");
            }
            _console = console;
            _hbTimer = new Timer(new TimerCallback(HB), null, 0, (long)HBInterval.TotalMilliseconds);
        }
        /// <summary>
        /// 定期发送心跳
        /// </summary>
        private void HB(object sender)
        {
            _proxy.HeartBeat(_bedNo, _console.GetStatus());
        }
        //释放定时器
        public void Dispose()
        {
            _hbTimer.Dispose();
            _proxy = null;
        }
    }
}
