using System.Collections.Generic;
using System.Linq;

namespace Refactoring.Conditionals.Polymorphism
{
    public static class OrderExtensions
    {
        private static List<IShippingCalculator> _calculators = new List<IShippingCalculator>()
        {
            new NormalShippingCalculator(),
            new MediumOrderShippingCalculator(),
            new PriorityShippingCalculator(),
            new FreeShippingCalculator()
        };

        public static double Calculate(this Order o)
        {
            return _calculators.Single(x => x.CanCalculateForOrder(o)).Calculate(o);
        }
    }
}