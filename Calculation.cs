using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tamrin8API
{
    public class Calculation
    {
        public double PriceCalculation()
        {
            var Data = ReadAPI.ReadAPI1();
            double max = Data.Result.high;
            double min = Data.Result.low;
            double y = max - min;
            double k = y / 2;
            double z = k + y;
            double price = min + z;
            return price;
        }
        public double PriceCalculation2(double max, double min)
        {
            double y = max - min;
            double k = y / 2;
            double z = k + y;
            double price2 = min + z;
            return price2;
        }
        public double PriceCalculation3(double x, double y)
        {
            double sum = x + y;
            double j = sum * 10;
            double q = j / 3;
            double z = q / 1000;
            double k = z + x;
            return k;
        }
        public double PriceCalculation4(double pricenow3, double price)
        {
            double x1 = pricenow3 - price;
            double y1 = x1 / price;
            double y2 = y1 * 100;
            return y2;

        }
    }
}
