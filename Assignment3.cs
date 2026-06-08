using System;

public class ProbabilityMatrixChecker
{
    public static bool IsProbMatrix(double[][] matrix)
    {
        if (matrix == null || matrix.Length == 0)
        {
            return false;
        }

        int rows = matrix.Length;

        for (int i = 0; i < rows; i++)
        {
            if (matrix[i].Length != rows)
            {
                return false;
            }

            double rowSum = 0;

            for (int j = 0; j < matrix[i].Length; j++)
            {
                double entry = matrix[i][j];

                if (entry < 0.0 || entry > 1.0)
                {
                    return false;
                }

                rowSum += entry;
            }

            if (Math.Abs(rowSum - 1.0) > 1e-6)
            {
                return false;
            }
        }

        return true;
    }

    public static void Main()
    {
        Console.Write("Enter the number of rows for the matrix: ");
        if (!int.TryParse(Console.ReadLine(), out int rows) || rows <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer.");
            return;
        }

        double[][] matrix = new double[rows][];

        for (int i = 0; i < rows; i++)
        {
            Console.Write($"Enter the elements for row {i + 1} separated by spaces: ");
            string[] inputLine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            matrix[i] = new double[inputLine.Length];

            for (int j = 0; j < inputLine.Length; j++)
            {
                if (double.TryParse(inputLine[j], out double value))
                {
                    matrix[i][j] = value;
                }
                else
                {
                    Console.WriteLine("Invalid number detected. Exiting.");
                    return;
                }
            }
        }

        Console.WriteLine($"\nIs Probability Matrix: {IsProbMatrix(matrix)}");
    }
}