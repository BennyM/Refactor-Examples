using System;
using System.Collections.Generic;
using System.Linq;

namespace Refactoring.Conditionals.Polymorphism
{
    public class Conditionals
    {
        private CourierService _courierService;
        private List<(Func<Order, bool> AppliesTo, Func<Order, double> Calculate)> _strategies;
        public Conditionals()
        {
            _courierService = new CourierService();
            _strategies.Add((IsFreeShipping, o => 0));
            _strategies.Add((IsSmallOrder, CalculateNormalShipping));
            _strategies.Add((IsMediumOrder, o => 20));
            _strategies.Add((o => o.IsPriority, o => _courierService.GetQuote(o.PackageWeigth)));
        }

        private static bool IsHolidaySeason(Order o)
        {
            return o.OrderDate.Day >= 20 && o.OrderDate.Month == 12 && o.OrderDate.Day <= 25;
        }

        private static bool IsSmallOrder(Order o)
        {
            return o.OrderTotal < 50;
        }

        private static bool IsMediumOrder(Order o)
        {
            return o.OrderTotal >= 50 && o.OrderTotal < 100;
        }

        private static bool IsLargeOrder(Order o)
        {
            return o.OrderTotal > 100;
        }

        private double CalculateNormalShipping(Order o)
        {
            return o.PackageWeigth * 0.2;
        }

        public double CalculateShippingCharge(Order o)
        {
            return _strategies.Single(x => x.AppliesTo(o)).Calculate(o);
        }

        private static bool IsFreeShipping(Order o) => IsHolidaySeason(o) || IsLargeOrder(o);

    }

}