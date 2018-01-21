namespace LP.University.Core.Spec
{
    public interface ISpec
    {
        string Description { get; }
        bool IsSatisfied();
    }
}
