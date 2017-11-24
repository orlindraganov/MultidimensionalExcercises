namespace FillTheMatrix
{
    using System;

    class FillTheMatrix
    {
        static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            var type = char.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            var counter = 1;

            switch (type)
            {
                case 'a':

                    for (int col = 0; col < size; col++)
                    {
                        for (int row = 0; row < size; row++)
                        {
                            matrix[row, col] = counter;
                            counter++;
                        }
                    }

                    break;

                case 'b':

                    for (int col = 0; col < size; col++)
                    {
                        for (int i = 0; i < size; i++)
                        {
                            int row;

                            if (col % 2 == 0)
                            {
                                row = i;
                            }
                            else
                            {
                                row = size - i - 1;
                            }
                            matrix[row, col] = counter;
                            counter++;
                        }
                    }

                    break;

                case 'c':

                    for (int i = 0; i < size * 2 - 1; i++)
                    {
                        int row;
                        int col;
                        if (i < size)
                        {
                            row = size - i - 1;
                            col = 0;

                            for (int j = 0; j <= i; j++)
                            {
                                matrix[row, col] = counter;
                                counter++;

                                row++;
                                col++;
                            }
                        }
                        else
                        {
                            row = 0;
                            col = i - size + 1;

                            for (int j = 0; j < 2 * size - i - 1; j++)
                            {
                                matrix[row, col] = counter;
                                counter++;

                                row++;
                                col++;
                            }
                        }
                    }

                    break;

                case 'd':

                    var direction = "down";
                    int[] position = { 0, 0 };

                    for (int i = 0; i < size * size; i++)
                    {
                        matrix[position[0], position[1]] = counter;
                        counter++;

                        switch (direction)
                        {
                            case "down":

                                if ((position[0] + 1 < size) && (matrix[position[0] + 1, position[1]] == 0))
                                {
                                    position[0]++;
                                }
                                else
                                {
                                    direction = "right";
                                    position[1]++;
                                }

                                break;

                            case "right":

                                if ((position[1] + 1 < size) && (matrix[position[0], position[1] + 1] == 0))
                                {
                                    position[1]++;
                                }
                                else
                                {
                                    direction = "up";
                                    position[0]--;
                                }

                                break;

                            case "up":
                                if ((position[0] > 0) && (matrix[position[0] - 1, position[1]] == 0))
                                {
                                    position[0]--;
                                }
                                else
                                {
                                    direction = "left";
                                    position[1]--;
                                }

                                break;

                            case "left":

                                if ((position[1] > 0) && (matrix[position[0], position[1] - 1] == 0))
                                {
                                    position[1]--;
                                }
                                else
                                {
                                    direction = "down";
                                    position[0]++;
                                }

                                break;

                            default:
                                break;
                        }
                    }
                    break;

                default:
                    break;
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size - 1; col++)
                {
                    Console.Write(matrix[row, col]);
                    Console.Write(" ");
                }
                Console.WriteLine(matrix[row, size - 1]);
            }
        }
    }
}
