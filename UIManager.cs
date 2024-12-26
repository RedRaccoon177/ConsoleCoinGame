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

        //게임 시작 시 예수금 출력 값
        public void PlayerMoney(float myMoney, float myCoinMoney)
        {
            Console.WriteLine($"나의 예수금 : {myMoney}");
            Console.WriteLine($"나의 코인 총액 : {myCoinMoney}");
        }

        //게임 시작 시 차트 출력 처음 값
        public void GameStartChart(Player player, LinkedList<Coin> coinList)
        {
            foreach (var coin in coinList)
            {
                Console.WriteLine($"{coin.Name}의 가격은: {coin.CoinPrice}");
                Console.WriteLine($"        ) {coin.CoinCount} 개 보유 중");
                Console.WriteLine();

                //일단 코인 금액 다 더한 모든 총액 만들어주기
                player.PlayerCoinAllMoney = player.PlayerCoinAllMoney + player.PlayerCoinMoney;
            }
            Console.WriteLine();
            Console.WriteLine($"0일이 지났습니다...");
            Console.WriteLine($"0 / 3");
        }

        //게임 미체결창
        public void CoinNotConcludedList(LinkedList<BuyCoinNotConcluded> buyCoinNotConcludeds, BuyCoinNotConcluded[] notConcluded)
        {
            Console.WriteLine("이거 출력되고 있냐?");
            for (int i = 0; i < notConcluded.Length; i++)
            {
                Console.WriteLine($"무슨 코인이냐? {notConcluded[i].WhatCoin}");
                Console.WriteLine($"얼마에 살거냐? {notConcluded[i].HowMuchBuy}");
                Console.WriteLine($"얼마나 살거냐? {notConcluded[i].HowManyBuy}");
                Console.WriteLine($"어디 좌표에 있냐? {notConcluded[i].MuchManyWhere}");
                Console.WriteLine("--------------------------------------------");
            }
            Console.WriteLine("이거 출 이이이");
            bool isNum = int.TryParse(Console.ReadLine(), out int getNum0);
        }

        //게임 진행 중 계속 출력 되는 변동값
        public void InGameViewAllTime
        (bool changeUI0, bool changeUI1, bool changeUI2,
            int theTime, int dayby, Market market, LinkedList<Coin> coinList, Player player, Coin[] coinArray
            , LinkedList<BuyCoinNotConcluded> buyCoinNotConcludeds, BuyCoinNotConcluded[] notConcluded)
        {
            ClearConsole1();
            Console.SetCursorPosition(0, 0);
            int i = 1;

            if (changeUI0 == false && changeUI1 == false && changeUI2 == false)
            {
                foreach (var coin in coinList)
                {
                    market.UpAndDown(coin._isCorrect);
                    Console.Write($"{coin.Name}의 가격은: {coin.CoinPrice}");
                    Console.WriteLine($"        ) {coin.CoinCount} 개 보유 중");
                    Console.WriteLine();
                }
            }
            else if (changeUI0 == false && changeUI2 == true)
            {
                foreach (var coin in coinList)
                {
                    Console.Write($"{i}. ");
                    market.UpAndDown(coin._isCorrect);
                    Console.Write($"{coin.Name}의 가격은: {coin.CoinPrice}");
                    Console.WriteLine($"        ) {coin.CoinCount} 개 보유 중");
                    Console.WriteLine();
                    i = i + 1;
                }
            }
            
            if (changeUI0 == false)
            {
                Console.WriteLine();
                Console.WriteLine($"{(theTime) / 4}일이 지났습니다...");
                Console.WriteLine($"{dayby} / 3");
                Console.WriteLine($"나의 예수금 : {player.PlayerMoney}");
                Console.WriteLine($"나의 코인 총액 : {player.PlayerCoinAllMoney}");
            }
            
            if (changeUI0 == false && changeUI1 == false && changeUI2 == false)
            {
                Console.WriteLine("1번. 코인 매수");
                Console.WriteLine("2번. 코인 매도");
                Console.WriteLine("3번. 코인 뉴스");
                Console.WriteLine("4번. 예수금 벌기");
            }
            else if (changeUI0 == false && changeUI1 == false && changeUI2 == true)
            {
                Console.WriteLine("매수하고자 코인의 번호를 입력하시오.");
            }
            else if (changeUI0 == false && changeUI1 == true && changeUI2 == true)
            {
                Console.WriteLine("매도하고자 코인의 번호를 입력하시오.");
            }
            else if (changeUI0 == true && changeUI1 == false && changeUI2 == true)
            {
                CoinNotConcludedList(buyCoinNotConcludeds, notConcluded);
            }
        }


        //화면 지우기
        public void ClearConsole1()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("                                                                                                           ");
            Console.WriteLine("                                                                                                           ");
        }
    }
}
