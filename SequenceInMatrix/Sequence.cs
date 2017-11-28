namespace SequenceInMatrix
{
    using System;
    using System.Linq;

    class Sequence
    {
        static string[,] matrix;
        static int currentSequence;
        static int maxSequence = int.MinValue;

        static void Main()
        {
            int[] dims = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            matrix = new string[dims[0], dims[1]];

            for (int i = 0; i < dims[0]; i++)
            {
                var input = Console.ReadLine().Split(' ').ToArray();
                for (int j = 0; j < dims[1]; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            for (int i = 0; i < dims[0]; i++)
            {
                for (int j = 0; j < dims[1]; j++)
                {
                    currentSequence = 0;
                    CheckElement(matrix, matrix[i, j], i, j);

                    if (currentSequence > maxSequence)
                    {
                        maxSequence = currentSequence;
                    }
                }
            }
            Console.WriteLine(maxSequence);
        }

        static void CheckElement(string[,] matrix, string value, int row, int col, string direction = "all")
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
                return;

            if (matrix[row, col] != value)
                return;

            currentSequence++;

            switch (direction)
            {
                case "all":
                    CheckElement(matrix, value, row, col + 1, "r");
                    CheckElement(matrix, value, row + 1, col + 1, "dr");
                    CheckElement(matrix, value, row + 1, col, "d");
                    CheckElement(matrix, value, row + 1, col - 1, "dl");
                    break;

                case "r":
                    CheckElement(matrix, value, row, col + 1, "r");
                    break;

                case "dr":
                    CheckElement(matrix, value, row + 1, col + 1, "dr");
                    break;

                case "d":
                    CheckElement(matrix, value, row + 1, col, "d");
                    break;

                case "dl":
                    CheckElement(matrix, value, row + 1, col - 1, "dl");
                    break;

                default:
                    throw new ArgumentException();
            }
        }
    }
}
