namespace AspectOrientedProgramming.Aspect
{
    public interface IAfterVoidAspect : IAspect
    {
        void OnAfter(object value);
    }
}
