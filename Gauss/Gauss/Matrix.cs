using System;

namespace Gauss
{
    public class Matrix
    {
        private float[,] large_matrix;
        private float[,] matrix;
        private int x_number;
        private int lines_number;

        public void MatrixInput()
        { 
            Console.Write("Введите количество переменных: ");
            x_number = byte.Parse(Console.ReadLine());
            Console.Write("Введите количество строк: ");
            lines_number = byte.Parse(Console.ReadLine());

            matrix = new float[lines_number, x_number];
            large_matrix = new float[lines_number, x_number + 1];

            Console.WriteLine("Введите коэффициенты при переменных");            
            for (int i = 0; i < lines_number; i++)
            {
                Console.WriteLine("{0} линия: ", i+1);
                for(int j = 0; j < x_number; j++)
                {
                    Console.Write("X{0} * ", j + 1);
                    large_matrix[i, j] = float.Parse(Console.ReadLine());
                    matrix[i, j] = large_matrix[i, j];
                    if (j == (x_number - 1)) Console.Write('\n');
                }
            }

            Console.WriteLine("Введите матрицу свободных переменных");
            for (int i = 0; i < lines_number; i++)
            {
                large_matrix[i, x_number] = float.Parse(Console.ReadLine());
            }

            MatrixOutput();
        }

        public void MatrixOutput()
        {
            int i = 0;
            foreach (int elem in large_matrix)
            {
                i++;
                if (i % (x_number + 1) == 0) Console.Write($"| {elem}\n");
                else Console.Write($"{elem} ");
            }
        }

        public float[,] GetMatrix(bool large)
        {
            if (large) return large_matrix;
            else return matrix;
        }
    }
}