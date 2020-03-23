using System;

namespace Gauss
{
    public class Matrix
    {
        private float[,] large_matrix;
        private int x_number;
        private int lines_number;

        public void MatrixInput()
        { 
            Console.Write("Введите количество переменных: ");
            x_number = byte.Parse(Console.ReadLine());
            Console.Write("Введите количество строк: ");
            lines_number = byte.Parse(Console.ReadLine());
            Console.Write('\n');

            large_matrix = new float[lines_number, x_number + 1];

            Console.WriteLine("Введите коэффициенты при переменных");            
            for (int i = 0; i < lines_number; i++)
            {
                Console.WriteLine("{0} линия: ", i+1);
                for(int j = 0; j < x_number; j++)
                {
                    Console.Write("X{0} * ", j + 1);
                    large_matrix[i, j] = float.Parse(Console.ReadLine());
                    if (j == (x_number - 1)) Console.Write('\n');
                }
            }

            Console.WriteLine("Введите матрицу свободных переменных");
            for (int i = 0; i < lines_number; i++)
            {
                large_matrix[i, x_number] = float.Parse(Console.ReadLine());
            }
            Console.Write('\n');

            MatrixOutput();
        }

        public void MatrixOutput()
        {
            for (int i = 0; i < large_matrix.GetLength(0); i++)
            {
                for (int j = 0; j < large_matrix.GetLength(1); j++)
                {
                    if (j == large_matrix.GetLength(0))
                        Console.Write("|\t");

                    Console.Write("{0}\t", large_matrix[i, j]);

                    if ((j == large_matrix.GetLength(1) - 1) 
                        && (i != large_matrix.GetLength(0) - 1))
                    {
                        Console.Write('\n');
                        for (int k = 0; k < x_number; k++)
                            Console.Write('\t');
                        Console.Write("|\n");
                    }
                }
            }
            Console.WriteLine('\n');                
        }

        public void Answer()
        {
            float[,] M = large_matrix;
            bool s = false;

            float[] x = Gauss.Solve(M);

            foreach (float elem in x)
            {
                if ((elem > float.MaxValue) || (elem < float.MinValue) || (elem == float.NaN))
                    s = true;

            }

            if ((x != null) && (s == false)) 
                for (int i = 0; i < x.Length; i++)
                    Console.WriteLine($"X{i+1} = {x[i]}");

            else
                Console.WriteLine("Единственного решения системы нет.");
        }
    }
}