using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12_Project_GameDevleop
{
    class Player : Coin
    {
        //플레이어 예수금
        private float _playerMoney;

        //플레이어 코인 총액수
        private float _playerCoinAllMoney;

        //플레이어 예수금
        public ref float PlayerMoney => ref _playerMoney;

        //플레이어 코인 총 액수
        public float PlayerCoinAllMoney
        {
            get => _playerCoinAllMoney;
            set => _playerCoinAllMoney = value;
        }

        //플레리어 생성자
        public Player()
        {
            _playerMoney = 10000f;
            _playerCoinAllMoney = 0f;
        }


    }
}
