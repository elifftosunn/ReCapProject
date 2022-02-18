using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection; //MethodInfo
using System.Text;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute> //CLASSIN ATTRIBUTLERINI OKU, YANİ CASH,PERFORMANCE,VALIDATION,LOGGING GİBİ...
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name) //METHODUN ATTRIBUTLERINI OKU
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes); //CLASS VE METHOD ATTRIBUT'LERİNİ BİR LİSTEYE KOY
            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));

            return classAttributes.OrderBy(x => x.Priority).ToArray(); //ONLARI ONCELİK SIRASINA GÖRE SIRALA
        }
    }
}
