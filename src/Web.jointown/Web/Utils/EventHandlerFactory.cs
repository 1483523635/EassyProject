using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Web.Domains;
using Web.EventHandlers;
using Web.Events;
using Web.Infrastructure;
using Web.Storages;
using Web.Utils.Reflactor;

namespace Web.Utils
{
    public class EventHandlerFactory : IEventHandlerFactory
    {
        private IServiceProvider _services;
        public EventHandlerFactory(IServiceProvider serviceProvider)
        {
            _services = serviceProvider;

        }

        public IEventHandler<T> GetHandler<T>() where T : Event
        {
            var types = GetHanderType<T>().ToList();
            //这里处理的并不优雅
            //需要加判断语句
            IEventHandler<T> handler = default;
            if (types.First().FullName.Contains("Enterprise"))
                handler = ReflactorTools.GetInstance<IEventHandler<T>>(GetHanderType<T>().ToList().First().FullName,
                                                     _services.GetService(typeof(IRepository<EnterpriseEntity>)));
            if (handler == null) throw new Exception($"The handler was not Registered {nameof(IEventHandler<T>)}");
            return handler;
        }

        private static IEnumerable<Type> GetHanderType<T>() where T : Event
        {
            var handels = typeof(IEventHandler<>).Assembly.GetExportedTypes()
                            .Where(x => x.GetInterfaces()
                                         .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(IEventHandler<>))
                                         ).Where(h => h.GetInterfaces().Any(ii => ii.GetGenericArguments().Any(aa => aa == typeof(T)))).ToList();
            return handels;
        }
    }
}
