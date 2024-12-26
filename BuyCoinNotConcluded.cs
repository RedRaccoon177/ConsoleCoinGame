using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12_Project_GameDevleop
{
    class BuyCoinNotConcluded
    {
        //플레이어가 걸어둔 코인 금액
        private float _HowMuchBuy;
        //플레이어가 걸어둔 코인 수량
        private float _HowManyBuy;
        //걸어둔 코인의 위치 파악
        private int _muchManyWhere;
        //걸어둔 코인의 코인이 무엇인지
        private int _whatCoin;


        //플레이어가 걸어둔 코인 금액
        public float HowMuchBuy
        {
            get { return _HowMuchBuy; }
            set { _HowMuchBuy = value; }
        }
        //플레이어가 걸어둔 코인 수량
        public float HowManyBuy
        {
            get { return _HowManyBuy; }
            set { _HowManyBuy = value; }
        }
        //걸어둔 코인의 위치 파악
        public int MuchManyWhere
        {
            get { return _muchManyWhere; }
            set { _muchManyWhere = value; }
        }
        //무슨 코인인지 알기 위한 저장
        public int WhatCoin
        {
            get { return _whatCoin; }
            set { _whatCoin = value; }
        }

        public BuyCoinNotConcluded( float howMuchBuy, float howManyBuy, int muchManyWhere, int whatCoin)
        {
            HowMuchBuy = howMuchBuy;
            HowManyBuy = howManyBuy;
            MuchManyWhere = muchManyWhere;
            WhatCoin = whatCoin;
        }
    }
}
