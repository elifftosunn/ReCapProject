using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { } //invocation => BENİM  GÖNDERDİĞİM METHOD
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            //METHODLARI ÇALIŞTIRMADAN ÖNCE HEPSİ BU KURALLARDAN GEÇİCEK
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
                //istek yapılan metodu çağırmak istersek IInvocation tipi içerisinde bulunan Proceed
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally //İSTER ÇALIŞSIN İSTER HATA VERSİN FİNALLY ÇALIŞIR
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}
