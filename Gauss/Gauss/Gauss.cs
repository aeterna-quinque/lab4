using System;

namespace Gauss
{
    static class Gauss
    {
        public static void SubstractRow(Matrix m1, int k)
        {
            float[,] M = m1.GetMatrix(true);
            float m = M[k, k];
            for (int i = k+1; i < M.GetLength(0); i++)
            {
                float t = M[i, k] / m;
                for (int j=k; j < M.GetLength(1); j++)
                {
                    M[i, j] = M[i, j] - M[k, j] * t;
                }
            }
        }
    }
}
