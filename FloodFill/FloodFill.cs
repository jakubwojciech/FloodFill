using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodFill
{
    class FloodFill
    {
        int width;
        int height;
        string image;
        char[,] map;

        public FloodFill(int width, int height, string image)
        {
            this.width = width;
            this.height = height;
            this.image = image;
            fillMap(width, height, image);
        }

        private void fillMap(int width, int height, string image)
        {
            this.map = new char[height, width];
            int charCouter = 0;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    map[i, j] = image[charCouter];
                    charCouter++;
                }
            }
        }

        public string Fill(int x, int y, char character)
        {
            char floorChar = map[x, y];

            checkNeighboursAndFill(x, y, floorChar, character);

            return convertMapToString();
        }

        private string convertMapToString()
        {
            string result = "";
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    result += map[i, j];
                }
            }
            return result;
        }

        private void checkNeighboursAndFill(int x, int y, char floorChar, char filling)
        {
            if (map[x, y] == floorChar)
            {
                map[x, y] = filling;
            }

            if (x < width - 1 && map[x + 1, y] == floorChar)
            {
                map[x + 1, y] = filling;
                checkNeighboursAndFill(x + 1, y, floorChar, filling);
            }

            if (x > 0 && map[x - 1, y] == floorChar)
            {
                map[x - 1, y] = filling;
                checkNeighboursAndFill(x - 1, y, floorChar, filling);
            }

            if (y < height - 1 && map[x, y + 1] == floorChar)
            {
                map[x, y + 1] = filling;
                checkNeighboursAndFill(x, y + 1, floorChar, filling);
            }

            if (y > 0 && map[x, y - 1] == floorChar)
            {
                map[x, y - 1] = filling;
                checkNeighboursAndFill(x, y - 1, floorChar, filling);
            }

        }

    }
}
