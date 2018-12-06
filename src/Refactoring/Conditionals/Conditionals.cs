using System;

namespace Refactoring.Conditionals
{
    public class Conditionals
    {
        private CourierService _courierService;
        public Conditionals()
        {
            _courierService = new CourierService();
        }
        public double CalculateShippingCharge(Order o)
        {
            double shipping;
            if (o.IsPriority)
            {
                shipping = _courierService.GetQuote(o.PackageWeigth);
            }
            else if (o.OrderDate.Day >= 20 && o.OrderDate.Month == 12 && o.OrderDate.Day <= 25)
            {
                shipping = 0;
            }
            else
            {
                if (o.OrderTotal < 50)
                {
                    shipping = o.PackageWeigth * 0.2;
                }
                else if (o.OrderTotal < 100)
                {
                    shipping = 20;
                }
                else
                {
                    shipping = 0;
                }
            }
            return shipping;
        }
    }
}