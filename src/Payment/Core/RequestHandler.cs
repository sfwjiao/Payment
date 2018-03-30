using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace Payment.Core
{
    internal sealed class RequestHandler
    {
        private static IDictionary<Type, IDictionary<string, Type>> _instance;

        public static IDictionary<Type, IDictionary<string, Type>> Instance => _instance ?? (_instance = new Dictionary<Type, IDictionary<string, Type>>());

        public static void AddOrUpdate<TInterface, TImpl>(string gateWayName, string requestName)
            where TInterface : IRequest
            where TImpl : class, TInterface
        {
            var interfaceType = typeof(TInterface);
            var implType = typeof(TImpl);
            var name = GetDictionaryKeyName(gateWayName, requestName);

            if (Instance.ContainsKey(interfaceType))
            {
                if (Instance[interfaceType] == null) Instance[interfaceType] = new Dictionary<string, Type>();
                var impldic = Instance[interfaceType];

                if (impldic.ContainsKey(name))
                {
                    impldic[name] = implType;
                }
                else
                {
                    impldic.Add(name, implType);
                }
            }
            else
            {
                Instance.Add(interfaceType, new Dictionary<string, Type> { { name, implType } });
            }
        }

        public static T Get<T>(string gateWayName, string requestName, object[] args = null) where T : IRequest
        {
            var interfaceType = typeof(T);
            if (!Instance.ContainsKey(interfaceType)) return default(T);
            var impldic = Instance[interfaceType];

            var name = GetDictionaryKeyName(gateWayName, requestName);
            if (!impldic.ContainsKey(name)) return default(T);

            var implType = impldic[name];

            if (implType.FullName == null) throw new InvalidOperationException();
            var impl = implType.Assembly.CreateInstance(implType.FullName, false, BindingFlags.Default, null, args, CultureInfo.CurrentCulture, null);
            if (impl == null) throw new NotImplementedRequestException(gateWayName, interfaceType, implType.FullName, $"未能正确实例化类型{implType.FullName}");
            if (!(impl is T)) throw new NotImplementedRequestException(gateWayName, interfaceType, implType.FullName, $"未能正确实例化类型{implType.FullName}");

            return (T)impl;
        }

        public static IRequest Get(Type type, string gateWayName, string requestName, object[] args = null)
        {
            if (!Instance.ContainsKey(type)) return null;
            var impldic = Instance[type];

            var name = GetDictionaryKeyName(gateWayName, requestName);
            if (!impldic.ContainsKey(name)) return null;

            var implType = impldic[name];

            if (implType.FullName == null) throw new InvalidOperationException();
            var impl = implType.Assembly.CreateInstance(implType.FullName);
            if (impl == null) throw new NotImplementedRequestException(gateWayName, type, implType.FullName, $"未能正确实例化类型{implType.FullName}");
            if (!(impl is IRequest)) throw new NotImplementedRequestException(gateWayName, type, implType.FullName, $"未能正确实例化类型{implType.FullName}");

            return (IRequest)impl;
        }

        private static string GetDictionaryKeyName(string gateWayName, string requestName)
        {
            return $"{gateWayName}-{requestName}";
        }
    }
}
