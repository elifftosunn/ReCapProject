using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; } //ÖNCE LOGLAMA SONRA VALİDATİON GİBİ ÖNCELİK SIRALAMASI YAPAR

        public virtual void Intercept(IInvocation invocation) //invocation => method
        {
            // IInvocation => çağrılan metot ile ilgili tüm bilgileri içerisinde barındırmakta.
        }
       
    }
}
