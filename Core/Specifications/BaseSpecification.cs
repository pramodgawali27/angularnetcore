using Core.Interfaces;

namespace Core.Specifications
{
    public class BaseSpecification : ISpecification<T>
    {
        public System.Linq.Expressions.Expression<System.Func<T, bool>> Criteria => throw new System.NotImplementedException();

        public System.Collections.Generic.List<System.Linq.Expressions.Expression<System.Func<T, object>>> Includes => throw new System.NotImplementedException();
    }
}