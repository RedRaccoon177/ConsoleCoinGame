using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12_Project_GameDevleop
{
    internal class UIManager
    {
        // 타이틀 이름
        public void Title()
        {
            Console.Title = "코인 가즈아아아아앗!!!";
        }

        //코인 시작 화면
        public void GameStart()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("|                                                              |");
                Console.WriteLine("|                        *************                         |");
                Console.WriteLine("|                    ****             ****                     |");
                Console.WriteLine("|                  ***      ██████       ***                   |");
                Console.WriteLine("|                ***        ██    ██       ***                 |");
                Console.WriteLine("|              ***          ██     ██        ***               |");
                Console.WriteLine("|              ***          ████████         ***               |");
                Console.WriteLine("|              ***          ██     ██        ***               |");
                Console.WriteLine("|                ***        ██    ██       ***                 |");
                Console.WriteLine("|                  ***      ██████       ***                   |");
                Console.WriteLine("|                    ****             ****                     |");
                Console.WriteLine("|                        *************                         |");
                Console.WriteLine("|                                                              |");
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("1번을 눌러 게임을 시작하시오.");
                Console.WriteLine("1. 게임 시작");

                bool isStirng = false;
                int pressStart = 0;
                isStirng = int.TryParse(Console.ReadLine(), out pressStart);
                if (pressStart == 1 && isStirng == true)
                {
                    Console.Clear();
                    break;
                }
            }
        }

        //게임 시작 시 인 게임 화면 
        public void InGameView()
        {
            //Console.Clear();
            //Console.WriteLine($"현재 보유 금액:$ {myMoney}");
            //Console.WriteLine($"코인 보유 금액:$ {myCoinMoney}");
            //Console.WriteLine("----------------------------------------------------------------");
            //Console.WriteLine("|                                                              |");
            //Console.WriteLine("|                                                              |");
            //Console.WriteLine("|                                                              |");
            //Console.WriteLine("|                                                              |");
            //Console.WriteLine("|                     여기 안에 코인 차트                       |");
            //Console.WriteLine("|                                                              |");
            //Console.WriteLine("|                                                              |");
            //Console.WriteLine("|                                                              |");
            //Console.WriteLine("|                                                              |");
            //Console.WriteLine("|                                                              |");
            //Console.WriteLine("----------------------------------------------------------------");

            //Console.WriteLine("@@@1~4번의 선택지를 선택하시오.@@@");

            //Console.WriteLine("1. 주식 매수");
            //Console.WriteLine("2. 주식 매도");
            //Console.WriteLine("3. 돈 벌기!!");
            //Console.WriteLine("4. 뉴스 보기");
        }

        // 게임 시작 시 예수금 출력 값
        public void PlayerMoney(float myMoney, float myCoinMoney)
        {
            Console.WriteLine($"나의 예수금 : {myMoney}");
            Console.WriteLine($"나의 코인 총액 : {myCoinMoney}");
        }

        // 게임 시작 시 차트 출력 처음 값
        public void GameStartChart(Player player, LinkedList<Coin> coinList)
        {
            foreach (var coin in coinList)
            {
                Console.Write($"현재 {coin.Name}의 가격은: {coin.CoinPrice}");
                Console.WriteLine($"        ) {coin.CoinCount} 개 보유 중");

                //일단 코인 금액 다 더한 모든 총액 만들어주기
                player.PlayerCoinAllMoney = player.PlayerCoinAllMoney + player.PlayerCoinMoney;
            }
            Console.WriteLine();
            Console.WriteLine($"0일이 지났습니다...");
            Console.WriteLine($"0 / 3");
        }

    }
}
