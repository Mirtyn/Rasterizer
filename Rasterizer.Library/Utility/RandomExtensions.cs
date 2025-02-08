using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rasterizer.Library.Utility
{
    public static class RandomExtensions
    {
        public static bool NextBool(this Random random)
        {
            return random.Next(0, 2) == 0;
        }

        //public static float NextSingle2(this Random random)
        //{
        //    return random.NextSingle(0f, 1f);
        //}

        public static float NextSingle(this Random random, float max)
        {
            return random.NextSingle(0f, max);
        }

        public static float NextSingle(this Random random, float min, float max)
        {
            return min + (max - min) * (float)random.NextDouble();
        }
    }
}
