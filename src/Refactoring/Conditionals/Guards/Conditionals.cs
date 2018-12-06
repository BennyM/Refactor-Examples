namespace Refactoring.Conditionals.Guards
{
    public class Conditionals
    {
        private CourierService _courierService;
        public Conditionals()
        {
            _courierService = new CourierService();
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
            if (o.IsPriority) return _courierService.GetQuote(o.PackageWeigth);
            if (IsFreeShipping(o)) return 0;
            if (IsMediumOrder(o)) return 20;
            return CalculateNormalShipping(o);
        }

        private static bool IsFreeShipping(Order o) => IsHolidaySeason(o) || IsLargeOrder(o);

    }
}