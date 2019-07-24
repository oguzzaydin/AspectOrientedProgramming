using System;
using System.Text;

namespace AspectOrientedProgramming.Aspect
{
    public class LogAttribute : AspectBase, IBeforeVoidAspect, IAfterVoidAspect
    {
        public void OnBefore()
        {
            StringBuilder sbLogMessage = new StringBuilder();

            sbLogMessage.AppendLine(string.Format("Method Name: {0}", AspectContext.Instance.MethodName));
            sbLogMessage.AppendLine(string.Format("Arguments: {0}",
                string.Join(",", AspectContext.Instance.Arguments)));

            Console.WriteLine("Loging: {0}", sbLogMessage.ToString());

        }

        public void OnAfter(object value)
        {
            // After
        }
    }
}
