using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Day12_Project_GameDevleop
{
    class Coin
    {
        private string _name;              //코인의 이름
        private int _coinCount;           //플레이어가 보유한 코인의 갯수
        private float _changePrice;       //변동만 되는 값
        private float _coinPrice;          //코인의 실제 값
        private float _trunChangPrice;    //소수점 컷 수들
        private float _playerCoinMoney;    //플레이어가 보유한 코인 전체 가격
        
        public bool _isCorrect;

        public string Name
        {
            get {return _name;}
            set { _name = value; }
        }
        public int CoinCount 
        { 
            get { return _coinCount;} 
            set { _coinCount = value; } 
        }
        public float ChangePrice
        {
            get { return _changePrice; }
            set { _changePrice = value; }
        }
        public float CoinPrice 
        {
            get { return _coinPrice; }
            set { _coinPrice = value; }
        }
        public float TrunChangPrice
        {
            get { return _trunChangPrice; }
            set { _trunChangPrice = value; } 
        }
        public float PlayerCoinMoney
        {
            get { return _playerCoinMoney; }
            set { _playerCoinMoney = value; }
        }

        //코인의 생성자
        public Coin()
        {
            Name = "";              //코인의 이름
            CoinCount = 0;         //코인의 갯수
            ChangePrice = 0;       //변동되는 값
            CoinPrice = 0;            //변동되는 코인 가격
            TrunChangPrice = 0;    //소수점 컷 수들
        }

        //코인의 생성자
        public Coin(string name, float coinPrice)
        {
            Name = name;            //코인의 이름
            CoinCount = 0;  //코인의 갯수
            ChangePrice = 0;     //변동되는 값
            CoinPrice = coinPrice;  //변동되는 코인 가격
            TrunChangPrice = 0;  //소수점 컷 수들
        }
    }
}
