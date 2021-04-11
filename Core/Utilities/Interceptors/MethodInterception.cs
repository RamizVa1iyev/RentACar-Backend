using System;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception:MethodInterceptionBaseAttribute
    {
        public override void Intercept(IInvocation invocation)
        {
            OnBefore(invocation);
            bool isSucceed = true;
            try
            {
                invocation.Proceed();
            }
            catch (Exception exception)
            {
                isSucceed = false;
                OnException(invocation, exception);
            }
            finally
            {
                if (isSucceed)
                {
                    OnSucceed(invocation);
                }
            }
            OnAfter(invocation);
        }

        protected virtual void OnSucceed(IInvocation invocation) { }

        protected virtual void OnAfter(IInvocation invocation) { }

        protected virtual void OnException(IInvocation invocation, Exception exception) { }

        protected virtual void OnBefore(IInvocation invocation) { }
    }

}
