namespace LP.University.Core.Spec
{
    public class AndSpec : ISpec
    {
        private readonly ISpec _a;
        private readonly ISpec _b;

        public string Description => $"Both conditions must be satisfied: '{_a.Description}' AND '{_b.Description}'.";

        public AndSpec(ISpec a, ISpec b)
        {
            _a = a;
            _b = b;
        }

        public bool IsSatisfied()
        {
            return _a.IsSatisfied() && _b.IsSatisfied();
        }
    }
}
