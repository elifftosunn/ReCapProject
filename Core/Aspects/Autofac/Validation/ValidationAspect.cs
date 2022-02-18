using Castle.DynamicProxy; //IInvocation
using Core.CrossCuttingConcerns.Validation; //ValidationTool.Validate
using Core.Utilities.Interceptors; //MethodInterception
using FluentValidation; //IValidator
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception //ValidationAspect => ATTRIBUTE
    {
        private Type _validatorType;  //ATTRIBUTE'LERIN TİPİNİ VER DİYORUZ
        public ValidationAspect(Type validatorType) 
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil.");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //Activator.CreateInstance => Çalışma anında yapılan şeyler
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //CarValidator'ın baseType(AbstractValidator)'ını bul onun generic argümanlarından(<T1,T2>) ilkini(Car) bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //onun parametrelerini bul ([Add(Car car)] => burada bir parametre var ama birden fazla olabilir) ve entityType(Car)'a eşit olanı 
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
