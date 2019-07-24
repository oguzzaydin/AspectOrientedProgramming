using System;

namespace AspectOrientedProgramming.Aspect
{
    public class CacheAttribute : AspectBase, IBeforeAspect, IAfterVoidAspect
    {
        public int DurationInMinute { get; set; }
        public object OnBefore()
        {
            string cacheKey = string.Format("{0}-{1}", AspectContext.Instance.MethodName, string.Join("_", AspectContext.Instance.Arguments));
            if (true)
            {
                Console.WriteLine("{0} isimli cache key ile cache üzerinden geliyorum!", cacheKey);
                return true;
            }
        }

        public void OnAfter(object value)
        {
            string cacheKey = string.Format("{0}_{1}", AspectContext.Instance.MethodName, string.Join("_", AspectContext.Instance.Arguments));

        }
    }
}
