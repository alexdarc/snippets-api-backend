namespace Common.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public class UpdateInstructions<T>
    {
        internal readonly Dictionary<Expression<Func<T, object>>, object> SetOperations;

        public UpdateInstructions()
        {
            this.SetOperations = new Dictionary<Expression<Func<T, object>>, object>();
        }

        public UpdateInstructions<T> Set(
            Expression<Func<T, object>> expression,
            object value)
        {
            this.SetOperations.Add(
                key: expression,
                value: value);

            return this;
        }

    }
}
