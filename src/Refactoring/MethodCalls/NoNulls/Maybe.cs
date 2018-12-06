using System;
using System.Collections.Generic;
using System.Linq;

namespace Refactoring.MethodCalls.NoNulls
{
    /// <summary>
    /// See https://www.pluralsight.com/tech-blog/maybe
    /// </summary>
    public struct Maybe<T>
    {
        readonly IEnumerable<T> values;

        public static Maybe<T> Some(T value)
        {
            if (value == null)
            {
                throw new InvalidOperationException();
            }

            return new Maybe<T>(new[] { value });
        }

        public static Maybe<T> None => new Maybe<T>(new T[0]);

        private Maybe(IEnumerable<T> values)
        {
            this.values = values;
        }

        public bool HasValue => values != null && values.Any();

        public T Value
        {
            get
            {
                if (!HasValue)
                {
                    throw new InvalidOperationException("Maybe does not have a value");
                }

                return values.Single();
            }
        }
    }
}