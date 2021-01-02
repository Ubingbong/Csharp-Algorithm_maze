using System;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.Initialize();

            // 콘솔의 커서를 보이지 않게 함
            Console.CursorVisible = false;

            // 마지막으로 측정한 시간 저장 (마지막으로 화면이 갱신된 시간)
            int lastTick = 0;

            // WAIT_TICK 마다 화면을 갱신
            const int WAIT_TICK = 1000 / 30;
            // ●
            const char CIRCLE = '\u25cf';

            while (true)
            {
                #region 프레임 관리 : 1/30초마다 한번씩 while 실행 (화면 실행)

                // 시스템이 시작된 이후 지금까지 경과한 시간 저장
                // (TickCount 는 시스템이 시작된 이후 경과시간을 ms단위로 반환)
                int currentTick = System.Environment.TickCount; 
                
                // 현재 화면이 갱신된지 1/30초가 안됐다면 처음으로 돌아감
                if (currentTick - lastTick < WAIT_TICK)
                    continue;

                // 현재 화면이 갱신된지 1/30초가 지났다면 시간 측정
                lastTick = currentTick;

                #endregion

                /* 렌더링 */

                // 커서의 위치를 0, 0 으로 설정
                Console.SetCursorPosition(0, 0);

                // 25x25로 ●를 출력
                for (int i = 0; i < 25; i++)
                {
                    for (int j = 0; j < 25; j++)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(CIRCLE);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
