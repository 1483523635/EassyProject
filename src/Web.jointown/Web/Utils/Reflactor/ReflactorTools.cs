using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Utils.Reflactor
{
    public static  class ReflactorTools
    {
        public static T GetInstance<T>(string instanceFullName, params object[] param)
        {
            return (T)Assembly.Load(Assembly.GetAssembly(typeof(T)).GetName().Name).CreateInstance(instanceFullName, true, BindingFlags.CreateInstance, null, param, Thread.CurrentThread.CurrentCulture, null);
        }
    }
}
