using System;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using AspectOrientedProgramming.Aspect;

namespace AspectOrientedProgramming
{
    public class TransparentProxy<T, TI> : RealProxy where T : TI, new()
    {
        private TransparentProxy() : base(typeof(TI)) { }

        public static TI GenerateProxy()
        {
            var instance = new TransparentProxy<T, TI>();
            return (TI) instance.GetTransparentProxy();
        }

        public override IMessage Invoke(IMessage msg)
        {
            var methodCallMessage = msg as IMethodCallMessage;
            ReturnMessage returnMessage = null;

            try
            {
                var realType = typeof(T);
                var mInfo = realType.GetMethod(methodCallMessage.MethodName);
                var aspects = mInfo.GetCustomAttributes(typeof(IAspect), true);
                FillAspectContext(methodCallMessage);
                object response = null;
                CheckAfterAspect(response, aspects);
                object result = null;
                if (response != null)
                {
                    returnMessage = new ReturnMessage(response, null, 0, methodCallMessage.LogicalCallContext,
                        methodCallMessage);
                }
                else
                {
                    result = methodCallMessage.MethodBase.Invoke(new T(), methodCallMessage.InArgs);
                    returnMessage = new ReturnMessage(result, null, 0, methodCallMessage.LogicalCallContext,
                        methodCallMessage);
                }

                CheckAfterAspect(result, aspects);

                return returnMessage;

            }
            catch (Exception ex)
            {
                return new ReturnMessage(ex, methodCallMessage);
            }
        }

        private void FillAspectContext(IMethodCallMessage methodCallMessage)
        {
            AspectContext.Instance.MethodName = methodCallMessage.MethodName;
            AspectContext.Instance.Arguments = methodCallMessage.InArgs;
        }

        private void CheckBeforeAspect(object response, object[] aspects)
        {
            foreach (IAspect loopAttribute in aspects)
            {
                if (loopAttribute is IBeforeVoidAspect)
                {
                    ((IBeforeVoidAspect)loopAttribute).OnBefore();
                }
                else if (loopAttribute is IBeforeAspect)
                {
                    response = ((IBeforeAspect) loopAttribute).OnBefore();
                }
            }
        }

        private void CheckAfterAspect(object result, object[] aspects)
        {
            foreach (IAspect loopAttribute in aspects)
            {
                if (loopAttribute is IAfterVoidAspect)
                {
                    ((IAfterVoidAspect)loopAttribute).OnAfter(result);
                }
            }
        }
    }
}
