using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification() { }
        public BaseSpecification(Expression<System.Func<T, bool>> criteria){
            Criteria=criteria;
        }
        public Expression<System.Func<T, bool>> Criteria {get;}

        public List<Expression<System.Func<T, object>>> Includes{get;}= new List<Expression<System.Func<T, object>>>();

        protected void AddInclude(Expression<Func<T,object>> includeExpression){
            Includes.Add(includeExpression);
        }
    }
}