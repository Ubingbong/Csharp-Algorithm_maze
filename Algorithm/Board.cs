using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{

    class MyList<T>
    {
        // 초기 동적 배열 크기
        const int DEFAULT_SIZE = 1;
        // 예약된 데이터의 모음
        T[] _data = new T[DEFAULT_SIZE];

        // 실제로 사용중인 데이터 개수
        public int Count = 0;
        // 예약된 데이터 개수
        public int Capacity { get { return _data.Length; } }

        // 데이터 추가
        // 시간 복잡도: O(1)  /  if절의 for문은 잘 실행되지 않는 예외 케이스이니 무시한다.
        public void Add(T item)
        {
            // 1. 공간이 충분히 남아있는지 확인
            
            // 공간이 충분하지 않다면
            if (Count >= Capacity)
            {
                // 사용중인 데이터의 수의 2배만큼의 공간을 새로 확보
                T[] newArray = new T[Count * 2]; 

                //  데이터 이사
                for (int i = 0; i < Count; i++)
                {
                    newArray[i] = _data[i];             
                }
                // 이사한 곳이 이제 우리 집이다 이말이야
                _data = newArray;                    
                
            }

            // 2. 공간에다가 데이터를 넣어준다
            _data[Count] = item;
            Count++;
        }

        // 값 가져오기(get), 값 설정하기(set) => 인덱서
        // 시간 복잡도: O(1)
        public T this[int index]
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        // 시간 복잡도: O(N)
        public void RemoveAt(int index)
        {
            // 101 102 103 104 105 105
            for (int i = 0; i < Count - 1; i++)
            {
                _data[i] = _data[i + 1];
            }
            _data[Count - 1] = default(T);    // 맨 마지막의 값을 타입 T의 default 값으로 설정
            Count--;
        }
    }
    class Board
    {
        // 배열
        public int[] _data = new int[25];
        // 리스트 (동적 배열)
        public MyList<int> _data2 = new MyList<int>();
        // 연결 리스트
        public LinkedList<int> _data3 = new LinkedList<int>();


        public void Initialize() 
        {
            _data2.Add(101);
            _data2.Add(102);
            _data2.Add(103);
            _data2.Add(104);
            _data2.Add(105);

            int tmp = _data2[2];    // 103

            // 3번째 데이터 삭제
            _data2.RemoveAt(2);  

        }
    }
}
