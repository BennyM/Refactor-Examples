using System;

namespace Refactoring.Conditionals.Polymorphism
{
    public interface IShippingCalculator
    {
        bool CanCalculateForOrder(Order o);
        double Calculate(Order o);
    }

    public class MediumOrderShippingCalculator
        : IShippingCalculator
    {
        public double Calculate(Order o)
        {
            return 20;
        }

        public bool CanCalculateForOrder(Order o)
        {
            return o.OrderTotal >= 50 && o.OrderTotal < 100;
        }
    }

    public class FreeShippingCalculator
        : IShippingCalculator
    {
        private static bool IsHolidaySeason(Order o)
        {
            return o.OrderDate.Day >= 20 && o.OrderDate.Month == 12 && o.OrderDate.Day <= 25;
        }

        private static bool IsLargeOrder(Order o)
        {
            return o.OrderTotal > 100;
        }
        public double Calculate(Order o)
        {
            return 0;
        }

        public bool CanCalculateForOrder(Order o)
        {
            return IsHolidaySeason(o) || IsLargeOrder(o);
        }
    }

    public class NormalShippingCalculator
        : IShippingCalculator
    {

        public double Calculate(Order o)
        {
            return o.PackageWeigth * 0.2;
        }

        public bool CanCalculateForOrder(Order o)
        {
            return o.OrderTotal < 50;
        }
    }

    public class PriorityShippingCalculator
        : IShippingCalculator
    {
        private CourierService _courierService;
        public PriorityShippingCalculator()
        {
            _courierService = new CourierService();
        }
        public double Calculate(Order o)
        {
            return _courierService.GetQuote(o.PackageWeigth);
        }

        public bool CanCalculateForOrder(Order o)
        {
            return o.IsPriority;
        }
    }
}