using System;
namespace Layer.Util
{
    static class MathUtil
    {
        public static double Max(double[] values)
        {
            var max = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                if (max < values[i]) max = values[i];
            }
            return max;
        }

        public static double Max(double[,] values)
        {
            var max = values[0, 0];
            for (int i = 0; i < values.GetLength(0); i++)
            {
                for (int j = 0; j < values.GetLength(1); j++)
                {
                    if (max < values[i, j]) max = values[i, j];
                }
            }
            return max;
        }
    }
}
