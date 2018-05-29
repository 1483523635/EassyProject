using Microsoft.AspNetCore.Builder;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.CommandHandlers;
using Web.Commands;
using Web.Utils.Reflactor;
using Web.Storages;

namespace Web.Utils
{
    public class CommandFactory : ICommandFactory
    {
        private IServiceProvider _services;

        public CommandFactory(IServiceProvider serviceProvider)
        {
            _services = serviceProvider;
        }

        public ICommandHandler<T> GetCommand<T>() where T : Command
        {
            var handler = ReflactorTools.GetInstance<ICommandHandler<T>>(GetHandlerTypes<T>().ToList().First().FullName, _services.GetService<IEventStorage>());
            if (handler == null) throw new InvalidOperationException($"the handler not registered {nameof(T)}");
            return handler;
        }
        private IEnumerable<Type> GetHandlerTypes<T>() where T : Command
        {
            var handlers = typeof(ICommandHandler<>).Assembly.GetExportedTypes()
                .Where(x => x.GetInterfaces()
                    .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(ICommandHandler<>)))
                    .Where(h => h.GetInterfaces()
                        .Any(ii => ii.GetGenericArguments()
                            .Any(aa => aa == typeof(T)))).ToList();


            return handlers;
        }
    }
}
