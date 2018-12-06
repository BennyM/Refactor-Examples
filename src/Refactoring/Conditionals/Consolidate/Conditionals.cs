namespace Refactoring.Conditionals.Consolidate
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

        public double CalculateShippingCharge(Order o)
        {
            double shipping = 0;
            if (o.IsPriority)
            {
                shipping = _courierService.GetQuote(o.PackageWeigth);
            }
            else if (IsHolidaySeason(o) || IsLargeOrder(o))
            {
                shipping = 0;
            }
            else if (IsMediumOrder(o))
            {
                shipping = 20;
            }
            else
            {
                shipping = o.PackageWeigth * 0.2;
            }
            return shipping;
        }
    }
}