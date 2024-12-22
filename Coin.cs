using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12_Project_GameDevleop
{
    class Coin
    {
        public string Name;             //코인의 이름
        public int coinCount;           //코인의 갯수
        public float changePrice;       //변동되는 값
        public float afterPrice;        //후의 코인 가격
        public float beforePrice;       //전의 코인 가격    
        public float trunChangPrice;    //소수점 컷 수들
    }
}
