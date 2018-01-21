using System.Collections.Generic;
using System.Linq;

namespace LP.University.Core.Spec
{
    public abstract class SpecList : ISpec
    {
        private List<ISpec> _specs;

        protected List<ISpec> Specs
        {
            get
            {
                if (_specs == null)
                    _specs = Specifications()?.ToList() ?? new List<ISpec>();

                return _specs;
            }
        }

        public virtual string Description =>
            $"The following conditions must be satisfied:\n{string.Join("\n", Specs.Select(x => x.Description))}";

        protected abstract IEnumerable<ISpec> Specifications();

        public bool IsSatisfied()
        {
            var satisfied = true;

            foreach (var spec in Specs)
            {
                if (!spec.IsSatisfied())
                {
                    satisfied = false;
                    break;
                }
            }

            return satisfied;

        }
    }
}
