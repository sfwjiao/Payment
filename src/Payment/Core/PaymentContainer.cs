using System;
using System.Collections.Generic;

namespace Payment.Core
{
    public class PaymentContainer<T>
    {
        /// <summary>
        /// 
        /// </summary>
        private static Dictionary<string, Func<T, IGateWay>> _gateWayFuncs;

        protected static Dictionary<string, Func<T, IGateWay>> GateWayFuncs => _gateWayFuncs ?? (_gateWayFuncs = new Dictionary<string, Func<T, IGateWay>>());

        /// <summary>
        /// 初始化网关
        /// </summary>
        /// <param name="gateWay"></param>
        /// <param name="gateWayName"></param>
        public static void InitGateWay(IGateWay gateWay, string gateWayName)
        {
            InitGateWay(o => gateWay, gateWayName);
        }

        public static void InitGateWay(Func<T, IGateWay> gateWayFunc, string gateWayName)
        {
            if (gateWayFunc == null) return;

            if (GateWayFuncs.ContainsKey(gateWayName))
            {
                GateWayFuncs[gateWayName] = gateWayFunc;
            }
            else
            {
                GateWayFuncs.Add(gateWayName, gateWayFunc);
            }
        }

        /// <summary>
        /// 获取网关
        /// </summary>
        /// <param name="gateWayName"></param>
        /// <returns></returns>
        public static IGateWay GetGateWay(string gateWayName)
        {
            return GetGateWay(default(T), gateWayName);
        }

        /// <summary>
        /// 获取网关
        /// </summary>
        /// <param name="initParamaters"></param>
        /// <param name="gateWayName"></param>
        /// <returns></returns>
        public static IGateWay GetGateWay(T initParamaters, string gateWayName)
        {
            if (!GateWayFuncs.ContainsKey(gateWayName)) return null;

            var gateWay = GateWayFuncs[gateWayName].Invoke(initParamaters);
            if (gateWay != null) gateWay.Name = gateWayName;
            return gateWay;
        }

        /// <summary>
        /// 注册请求
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <typeparam name="TImpl"></typeparam>
        /// <param name="gateWayName"></param>
        /// <param name="requestName"></param>
        public static void InjectRequest<TInterface, TImpl>(string gateWayName, string requestName = null)
            where TInterface : IRequest
            where TImpl : class, TInterface
        {
            requestName = requestName ?? typeof(TInterface).FullName;
            RequestHandler.AddOrUpdate<TInterface, TImpl>(gateWayName, requestName);
        }

        /// <summary>
        /// 获取请求
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <param name="initParamaters"></param>
        /// <param name="gateWayName"></param>
        /// <param name="requestName"></param>
        /// <returns></returns>
        public static TRequest GetRequest<TRequest>(T initParamaters, string gateWayName, string requestName = null) where TRequest : IRequest
        {
            var gateWay = GetGateWay(initParamaters, gateWayName);
            if (gateWay == null) return default(TRequest);

            requestName = requestName ?? typeof(TRequest).FullName;
            return gateWay.GetRequest<TRequest>(requestName);
        }

        /// <summary>
        /// 获取请求
        /// </summary>
        /// <param name="type"></param>
        /// <param name="initParamaters"></param>
        /// <param name="gateWayName"></param>
        /// <param name="requestName"></param>
        /// <returns></returns>
        public static IRequest GetRequest(Type type, T initParamaters, string gateWayName, string requestName = null)
        {
            var gateWay = GetGateWay(initParamaters, gateWayName);
            if (gateWay == null) return null;

            requestName = requestName ?? type.FullName;
            return gateWay.GetRequest(type, requestName);
        }
    }
}
