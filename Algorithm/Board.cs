using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{

    class Board
    {
        // ●
        const char CIRCLE = '\u25cf';
        // 배열
        public TileType[,] _tile;
        public int _size;

        public enum TileType
        {
            Empty,
            Wall,
        }


        public void Initialize(int size)
        {
            _tile = new TileType[size, size];
            _size = size;

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (j == 0 || j == _size - 1 || i == 0 || i == _size - 1)
                        _tile[i, j] = TileType.Wall;
                    else
                        _tile[i, j] = TileType.Empty;
                }
            }

        }

        public void Render()
        {
            /* 렌더링 */

            ConsoleColor prevColor = Console.ForegroundColor;
            // 25x25로 ●를 출력
            for (int i = 0; i < _size; i++)
            { 

                for (int j = 0; j < _size; j++)
                {
                   Console.ForegroundColor =  GetTileColor(_tile[i, j]);
                    Console.Write(CIRCLE);
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = prevColor;
        }

        ConsoleColor GetTileColor(TileType type)
        {
            switch (type)
            {
                case TileType.Empty:
                    return ConsoleColor.Cyan;

                case TileType.Wall:
                    return ConsoleColor.DarkGray;

                default:
                    return ConsoleColor.Cyan;
            }
        }

    }
}
