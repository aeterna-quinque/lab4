using System;

namespace Gauss
{
    static class Gauss
    {
        private static void SubstractRow(float[,] M, int k)
        {
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

        private static bool TriangleMatrix(float [,] M)
        {
            for (int i = 1; i < M.GetLength(0); i++)
            {
                SelectLeading(M, i - 1);
                if (Math.Abs(M[i - 1, i - 1]) > 0.0001)
                    SubstractRow(M, i - 1);
                else
                    return false;

            }
            return true;
        }

        public static float [] Solve(float [,] M)
        {
            if (!TriangleMatrix(M))
                return null;
            float[] v = new float[M.GetLength(0)];
            int Nb = M.GetLength(1) - 1;
            for(int n = v.Length - 1; n >= 0; n--)
            {
                float sum = 0;
                for (int i = n + 1; i < Nb; i++)
                    sum += v[i] * M[n, i];
                v[n] = (M[n, Nb] - sum) / M[n, n];
            }
            return v;
        }

        private static void SelectLeading(float [,] M, int n)
        {
            int iMax = n;
            for (int i = n + 1; i < M.GetLength(0); i++)
                if (Math.Abs(M[iMax, n]) < Math.Abs(M[i, n]))
                    iMax = i;

            if (iMax != n)
                for (int i = n; i < M.GetLength(1); i++)
                {
                    float t = M[n, i];
                    M[n, i] = M[iMax, i];
                    M[iMax, i] = t;
                }
        }
    }
}
