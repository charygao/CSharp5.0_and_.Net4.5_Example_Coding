using System;
using System.ServiceModel;
using System.Threading;
using System.Security.Principal;
using System.Security.Permissions;
namespace WCF.Fifth
{
    /// <summary>
    /// 服务契约
    /// </summary>
    [ServiceContract]
    public interface IService
    {
        /// <summary>
        /// 公共操作，无需认证和授权
        /// </summary>
        [OperationContract]
        void PublicOperation();
        /// <summary>
        /// 受限操作，需要特殊的权限才能操作
        /// </summary>
        [OperationContract]
        void RestrictedOperation();
        /// <summary>
        /// 管理员操作，只有管理员才能访问
        /// </summary>
        [OperationContract]
        void AdminOperation();
    }
    /// <summary>
    /// 服务的实现
    /// </summary>
    public class Service : IService
    {
        /// <summary>
        /// 打印安全信息
        /// </summary>
        private void PrintInfo()
        {
            Console.WriteLine("Windows身份：{0}", WindowsIdentity.GetCurrent().Name);
            Console.WriteLine("线程当前身份：{0}", Thread.CurrentPrincipal.Identity.Name);
            Console.WriteLine("安全上下文主要身份：{0}", ServiceSecurityContext.Current.PrimaryIdentity.Name);
            Console.WriteLine("安全上下文Windows身份：{0}", ServiceSecurityContext.Current.WindowsIdentity.Name);
        }
        public void PublicOperation()
        {
            PrintInfo();
            Console.WriteLine("进入公共操作");
        }
        [PrincipalPermission(SecurityAction.Demand, Role = "Guests")]
        public void RestrictedOperation()
        {
            PrintInfo();
            Console.WriteLine("进入受限操作");
        }
        [PrincipalPermission(SecurityAction.Demand, Role = "Administrators")]
        public void AdminOperation()
        {
            PrintInfo();
            Console.WriteLine("进入管理员操作");
        }
    }
}

