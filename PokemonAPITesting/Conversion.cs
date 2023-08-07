using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAPITesting
{
    public class Conversion
    {
        public static double FootConversion(double decimeter)
        {
            double answer = decimeter / 3.048;
            return answer;
        }
        public static double PoundConversion(double hectogram)
        {
            double answer = hectogram / 4.536;
            return answer;
        }
    }
}
