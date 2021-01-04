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
            if (size % 2 == 0)
                return;

            _tile = new TileType[size, size];
            _size = size;

            GenetateByBinaryTree();

        }

        void GenetateByBinaryTree()
        {
            //  _tile[짝수, 짝수]를 벽으로 설정 (_size가 홀수면 외곽을 벽으로 설정할 수 있음)
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (j % 2 == 0 || i % 2 == 0)
                        _tile[i, j] = TileType.Wall;
                    else
                        _tile[i, j] = TileType.Empty;
                }
            }

            // 랜덤으로 우측 혹은 아래로 길을 터줌
            Random rand = new Random();
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    // 벽이면 길트기 실행 x
                    if (j % 2 == 0 || i % 2 == 0)
                        continue;

                    //  [_size - 2 , _size -2] 의 경우 길트기 진행 안함
                    if (i == _size - 2 && j == _size - 2)
                        continue;


                    //  맨 하단 쪽으로 길이 트이지 않게 함
                    if (i == _size - 2)
                    {
                        _tile[i, j + 1] = TileType.Empty;
                        continue;
                    }

                    // 맨 우측 쪽으로 길이 트이지 않게 함
                    if (j == _size - 2)
                    {
                        _tile[i + 1, j] = TileType.Empty;
                        continue;
                    }

                    // 위 두 조건에서 만약 [_size - 2 , _size -2] 의 경우엔 오른쪽으로 트이는 문제가 발생한다.
                    // 이것을 막기 위해  [_size - 2 , _size -2] 일 때 길트기를 진행하지 않는 if문을 추가한다.


                    // 랜덤으로 0과 1을 뽑아 0이면 우측으로 1이면 아래쪽으로 길을 틈
                    if (rand.Next(0, 2) == 0)
                        _tile[i, j + 1] = TileType.Empty;
                    else
                        _tile[i + 1, j] = TileType.Empty;

                }
            }
        }

        public void Render()
        {
            /* 렌더링 */
            // 이전의 화면 색상 저장
            ConsoleColor prevColor = Console.ForegroundColor;

            // _size x _size로 ●를 출력
            for (int i = 0; i < _size; i++)
            { 
                for (int j = 0; j < _size; j++)
                {
                    // 색상을 결정하고 ●을 그림 
                    Console.ForegroundColor =  GetTileColor(_tile[i, j]);
                    Console.Write(CIRCLE);

                }
                // 줄바꿈
                Console.WriteLine();
            }
            // 이전의 화면 색상 다시 적용
            Console.ForegroundColor = prevColor;
        }


        // 벽은 회색 길은 시안색으로 칠하기
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
