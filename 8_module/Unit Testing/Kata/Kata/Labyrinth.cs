using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata
{
    public class Labyrinth
    {
        public bool FindExitFromLabyrinth(char[,] labyrinthMap, out string path)
        {
            var startIndexRow = 0;
            var startIndexCol = 0;

            for (int k = 0; k < labyrinthMap.GetLength(0); k++)
            {
                for (int m = 0; m < labyrinthMap.GetLength(0); m++)
                {
                    if (labyrinthMap[k, m] == 's')
                    {
                        startIndexRow = k;
                        startIndexCol = m;
                    }
                }
            }

            int i = startIndexRow;
            int j = startIndexCol;
            bool wayFound = true;
            path = "S ";

            while (true)
            {
                if ((labyrinthMap[i - 1, j] == 'e' && i > 0) || (j > 0 && labyrinthMap[i, j - 1] == 'e') || (i < 5 && labyrinthMap[i + 1, j] == 'e') || (j < 5 && labyrinthMap[i, j + 1] == 'e'))
                {
                    break;
                }

                if (i > 0 && labyrinthMap[i - 1, j] == '_')
                {
                    labyrinthMap[i - 1, j] = 'x';
                    i--;
                    path += "U ";
                }
                else if (j > 0 && labyrinthMap[i, j - 1] == '_')
                {
                    labyrinthMap[i, j - 1] = 'x';
                    j--;
                    path += "L ";
                }
                else if (i < 5 && labyrinthMap[i + 1, j] == '_')
                {
                    labyrinthMap[i + 1, j] = 'x';
                    i++;
                    path += "D ";
                }
                else if (j < 5 && labyrinthMap[i, j + 1] == '_')
                {
                    labyrinthMap[i, j + 1] = 'x';
                    j++;
                    path += "R ";
                }
                else
                {
                    wayFound = false;
                }

                if (!wayFound)
                {
                    if (labyrinthMap[i, j] == 'x')
                    {
                        labyrinthMap[i, j] = 'z';
                    }

                    if (i > 0 && (labyrinthMap[i - 1, j] == 'x' || labyrinthMap[i - 1, j] == 's'))
                    {
                        labyrinthMap[i - 1, j] = 'z';
                        i--;
                    }
                    else if (j > 0 && (labyrinthMap[i, j - 1] == 'x' || labyrinthMap[i, j - 1] == 's'))
                    {
                        labyrinthMap[i, j - 1] = 'z';
                        j--;
                    }
                    else if (i < 5 && (labyrinthMap[i + 1, j] == 'x' || labyrinthMap[i + 1, j] == 's'))
                    {
                        labyrinthMap[i + 1, j] = 'z';
                        i++;
                    }
                    else if (j < 5 && (labyrinthMap[i, j + 1] == 'x' || labyrinthMap[i, j + 1] == 's'))
                    {
                        labyrinthMap[i, j + 1] = 'z';
                        j++;
                    }

                    if (path.Length > 2)
                    {
                        path = path.Remove(path.Length - 2);
                    }
                }

                wayFound = true;

                if (labyrinthMap[startIndexRow, startIndexCol] == 'z')
                {
                    path = "No Way Found";
                    wayFound = false;
                    break;
                }
            }

            path = path.TrimEnd();
            return wayFound;
        }
    }
}
