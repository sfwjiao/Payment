using System.Security.Cryptography.X509Certificates;

namespace Payment.Http
{
    /// <summary>
    /// 用于创建证书
    /// 使用单例并在创建时锁定Creater，避免同时读取X509Store引起的内存错误
    /// </summary>
    public sealed class CertCreater
    {
        /// <summary>
        /// 单例对象，用于X509Store对象证书操作的同步访问
        /// </summary>
        private static readonly CertCreater Creater = new CertCreater();

        /// <summary>
        /// 似有化构造函数
        /// </summary>
        private CertCreater() { }

        /// <summary>
        /// 根据指纹创建证书
        /// </summary>
        /// <param name="thumbprint"></param>
        /// <returns></returns>
        public static X509Certificate2 GetCertByThumbprint(string thumbprint)
        {
            X509Certificate2 cert = null;

            lock (Creater)
            {
                var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                foreach (var item in store.Certificates)
                {
                    if (item.Thumbprint != thumbprint) continue;
                    cert = item;
                    break;
                }
                store.Close();
            }

            return cert;
        }
    }
}
