using System;

namespace Refactoring.Conditionals
{
    public class Order
    {
        public DateTime OrderDate { get; set; }
        public bool IsPriority { get; set; }
        public double OrderTotal { get; set; }

        public double PackageWeigth { get; set; }
    }
}