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
        private float _howMuchLock;
        //플레이어가 걸어둔 코인 수량
        private float _howManyLock;
        //걸어둔 코인의 위치 파악
        private int _muchManyWhere;
        //걸어둔 코인의 코인이 무엇인지
        private int _whatCoin;
        //매수인지 매도인지
        private bool _buyORSell;


        //플레이어가 걸어둔 코인 금액
        public float HowMuchLock
        {
            get { return _howMuchLock; }
            set { _howMuchLock = value; }
        }
        //플레이어가 걸어둔 코인 수량
        public float HowManyLock
        {
            get { return _howManyLock; }
            set { _howManyLock = value; }
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
        //매수인지 매도인지
        public bool BuyORSell
        {
            get { return _buyORSell; }
            set { _buyORSell = value; }
        }

        //BuyCoinNotConcluded의 생성자
        public BuyCoinNotConcluded
            ( float howMuchLock, float howManyLock, int muchManyWhere, int whatCoin, bool buyORSell)
        {
            HowMuchLock = howMuchLock;
            HowManyLock = howManyLock;
            MuchManyWhere = muchManyWhere;
            WhatCoin = whatCoin;
            BuyORSell = buyORSell;
        }
    }
}
