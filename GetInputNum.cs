using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12_Project_GameDevleop
{
    class GetInputNum
    {
        //입력 받는 값의 함수
        public void GetInput(ref int getNum0) 
        {
            //문자열 일경우 제외
            //숫자인데 0일경우 제외
            bool isNum = false;
            int getNum1 = 0;

            while (isNum == false && getNum1 == 0)
            {
                isNum = int.TryParse(Console.ReadLine(), out getNum0);
                getNum1 = getNum0;
            }

            getNum0 = getNum1;
        }
    }
}
