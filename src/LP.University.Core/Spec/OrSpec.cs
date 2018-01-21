namespace LP.University.Core.Spec
{
    public class OrSpec : ISpec
    {
        public string Description => $"One condition must be satisfied: '{_a.Description}' OR '{_b.Description}'.";

        private readonly ISpec _a;
        private readonly ISpec _b;

        public OrSpec(ISpec a, ISpec b)
        {
            _a = a;
            _b = b;
        }

        public bool IsSatisfied()
        {
            return _a.IsSatisfied() || _b.IsSatisfied();
        }
    }
}
