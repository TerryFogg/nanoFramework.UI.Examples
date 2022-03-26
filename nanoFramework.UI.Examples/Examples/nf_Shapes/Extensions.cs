using System;

namespace nf_Shapes
{
    public static class Extensions
    {
        public static int Next(this Random rand, int min, int max)
        {
            if (max - min == 0)
                return min;
            return min + rand.Next(max-min);
        }
    }
}
