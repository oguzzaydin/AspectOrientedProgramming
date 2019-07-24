using System;

namespace AspectOrientedProgramming.Aspect
{
    public class AspectContext
    {
        private readonly static Lazy<AspectContext> _Instance = new Lazy<AspectContext>(() => new AspectContext());

        private AspectContext()
        {
        }

        public static AspectContext Instance
        {
            get { return _Instance.Value; }
        }

        public string MethodName { get; set; }
        public object[] Arguments { get; set; }
    }
}
