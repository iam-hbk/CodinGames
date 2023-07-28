using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Don't let the machines win. You are humanity's last hope...
 **/
class Player
{
    static void Main(string[] args)
    {
        // Func<int, int, bool> is_a_dot_fx = (r, c) => char.IsPunctuation(nodes[r, c].ToCharArray()[0]);




        int width = int.Parse(Console.ReadLine()); // the number of cells on the X axis
        int height = int.Parse(Console.ReadLine()); // the number of cells on the Y axis


        string[,] nodes = new string[width, height];
        for (int i = 0; i < height; i++)
        {
            string line = Console.ReadLine(); // width characters, each either 0 or .
            for (int c_index = 0; c_index < line.Length; c_index++)
            {
                nodes[c_index, i] = $"{line[c_index]}";
            }


        }

        //Loop through the 2D array

        int rows = nodes.GetLength(0);
        int cols = nodes.GetLength(1);

        for (int col = 0; col < cols; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                Console.Error.Write(nodes[row, col]);
            }
            Console.Error.WriteLine();
        }

        Console.Error.WriteLine($"Rows [{rows}]");
        Console.Error.WriteLine($"Cols [{cols}]");

        Func<int, int, bool> is_a_dot_fx = (r, c) => char.IsPunctuation(nodes[r, c].ToCharArray()[0]);

        Tuple<int, int> FindClosest(int r, int c, string direction, int counter)
        {
            Console.Error.WriteLine($"Recursion Counter:{counter}");
            if (rows - r == 0 && direction == "r" || cols - c == 0 && direction == "b")
            {
                return Tuple.Create(-1, -1);
            }
            else if (!is_a_dot_fx(r, c))
            {
                return Tuple.Create(r, c);
            }
            else
            {
                r = direction == "r" ? r + 1 : r;
                c = direction == "b" ? c + 1 : c;
                return FindClosest(r, c, direction, counter + 1);
            }

        }

        for (int col = 0; col < cols; col++)
        {
            for (int row = 0; row < rows; row++)
            {

                string right;
                string bottom;
                // bool is_a_dot = char.IsPunctuation(nodes[row,col].ToCharArray()[0]);
                // check if current is an empty cell (dot)
                if (is_a_dot_fx(row, col))
                {
                    continue;
                }


                // string current = $"{nodes[row, col]} -> ({row},{col})";
                string current = $"{row} {col}";
               
                // HORIZONTAL
                Tuple<int, int> closestH = FindClosest(row + 1, col, "r", 1);
                right = $"{closestH.Item1} {closestH.Item2}";

                // VERTICAL
                Tuple<int, int> closestV = FindClosest(row, col + 1, "b", 1);

                bottom = $"{closestV.Item1} {closestV.Item2}";

                Console.WriteLine($"{current} {right} {bottom}");

            }
        }


        // Three coordinates: a node, its right neighbor, its bottom neighbor
        // Console.WriteLine("0 0 1 0 0 1");
    }

}
