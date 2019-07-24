namespace AspectOrientedProgramming.Aspect
{
    public interface IBeforeAspect : IAspect
    {
        object OnBefore();
    }
}
