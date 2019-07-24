namespace AspectOrientedProgramming.Aspect
{
    public interface IAfterAspect : IAspect
    {
        object OnAfter(object value);
    }
}
