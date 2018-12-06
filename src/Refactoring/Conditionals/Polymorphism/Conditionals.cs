using System;
using System.Collections.Generic;
using System.Linq;

namespace Refactoring.Conditionals.Polymorphism
{
    public class Conditionals
    {


        public double CalculateShippingCharge(Order o)
        {
            return o.Calculate();
        }



    }

}