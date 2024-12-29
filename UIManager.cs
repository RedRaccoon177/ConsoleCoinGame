using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public void CoinNotConcludedList
            (Coin[] coin, LinkedList<BuyCoinNotConcluded> buyCoinNotConcludeds, Stopwatch stopwatch, GameManager gameManager,
            ref bool changeUI0, ref bool changeUI1,ref bool changeUI2, ref bool changeUI3)
        {
            //미체결 코인 클래스 배열화
            BuyCoinNotConcluded[] notConcluded = buyCoinNotConcludeds.ToArray();

            for (int i = 0; i < notConcluded.Length; i++)
            {
                Console.WriteLine($"미체결된 코인: {coin[notConcluded[i].WhatCoin].Name}");
                Console.WriteLine($"미체결된 가격: ${notConcluded[i].HowMuchLock}");
                Console.WriteLine($"미체결된 갯수: {notConcluded[i].HowManyLock}개");
                Console.WriteLine($"삭제 번호: {notConcluded[i].MuchManyWhere}");
                Console.WriteLine("--------------------------------------------");
            }

            Console.WriteLine("Q를 눌러 차트표로 돌아가실 수 있습니다.");
            Console.WriteLine("삭제하시고 싶은 미체결 상품의 번호를 입력하시면 삭제가 가능합니다.");

            //시간 정지
            stopwatch.Stop();

            //Q를 입력 시 게임 종료, 숫자를 입력하면 지정된 좌표의 미체결 상품이 삭제
            var isQ = Console.ReadLine();
            if (isQ == "q" || isQ == "Q")
            {
                changeUI0 = false;
                changeUI1 = false;
                changeUI2 = false;
                changeUI3 = false;
                stopwatch.Start();
            }

            //삭제하고 싶은 숫자일 경우
            bool asd = int.TryParse(isQ, out int temp);
            if (asd == true)
            {
                gameManager.RemoveByName(buyCoinNotConcludeds, temp);
                changeUI0 = false;
                changeUI1 = false;
                changeUI2 = false; 
                changeUI3 = false;
                stopwatch.Start();
            }
        }

        //int x = 0;
        //int y = 0;

        //게임 진행 중 계속 출력 되는 변동값
        public void InGameViewAllTime
            (ref bool changeUI0, ref bool changeUI1, ref bool changeUI2, ref bool changeUI3, int temp,
            int theTime, int dayby, Market market, LinkedList<Coin> coinList, Player player, Coin[] coinArray, int _candleCount
            , LinkedList<BuyCoinNotConcluded> buyCoinNotConcludeds, Stopwatch stopwatch, GameManager gameManager, ref int showCoin
            , List<List<float>> mostHL, List<float> oneSpaces, List<List<float>> CVolatilityValues,
            List<List<float>> highValues, List<int[]> howSpaces, List<List<float>> changeColor
            )
        {
            ClearConsole0();
            Console.SetCursorPosition(0, 0);

            if (changeUI0 == false && changeUI1 == false && changeUI2 == false && changeUI3 == false)
            {
                foreach (var coin in coinList)
                {
                    market.UpAndDown(coin._isCorrect);
                    Console.Write($"{coin.Name}의 가격은: {coin.CoinPrice}");
                    Console.WriteLine($"        ) {coin.CoinCount} 개 보유 중");
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine($"{(theTime) / 11}일이 지났습니다...");
                Console.WriteLine($"{dayby} / 10");
                Console.WriteLine($"나의 예수금 : {player.PlayerMoney}");
                Console.WriteLine($"나의 코인 총액 : {player.PlayerCoinAllMoney}");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("1번. 코인 매수");
                Console.WriteLine("2번. 코인 매도");
                Console.WriteLine("3번. 미체결 확인하기");
                Console.WriteLine("4번. 캔들 차트표 보기");
                Console.WriteLine("------------------------------------------------");
            }
            else if (changeUI0 == false && changeUI1 == false && changeUI2 == false && changeUI3 == true)
            {
                int i = 1;
                foreach (var coin in coinList)
                {
                    Console.Write($"{i}. ");
                    market.UpAndDown(coin._isCorrect);
                    Console.Write($"{coin.Name}의 가격은: {coin.CoinPrice}");
                    Console.WriteLine($"        ) {coin.CoinCount} 개 보유 중");
                    Console.WriteLine();
                    i = i + 1;
                }
                Console.WriteLine();
                Console.WriteLine($"{(theTime) / 11}일이 지났습니다...");
                Console.WriteLine($"{dayby} / 10");
                Console.WriteLine($"나의 예수금 : {player.PlayerMoney}");
                Console.WriteLine($"나의 코인 총액 : {player.PlayerCoinAllMoney}");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("매수하고자 코인의 번호를 입력하시오.");
                Console.WriteLine("------------------------------------------------");

            }
            else if (changeUI0 == false && changeUI1 == false && changeUI2 == true && changeUI3 == false)
            {
                int i = 1;
                foreach (var coin in coinList)
                {
                    Console.Write($"{i}. ");
                    market.UpAndDown(coin._isCorrect);
                    Console.Write($"{coin.Name}의 가격은: {coin.CoinPrice}");
                    Console.WriteLine($"        ) {coin.CoinCount} 개 보유 중");
                    Console.WriteLine();
                    i = i + 1;
                }
                Console.WriteLine();
                Console.WriteLine($"{(theTime) / 11}일이 지났습니다...");
                Console.WriteLine($"{dayby} / 10");
                Console.WriteLine($"나의 예수금 : {player.PlayerMoney}");
                Console.WriteLine($"나의 코인 총액 : {player.PlayerCoinAllMoney}");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("매도하고자 코인의 번호를 입력하시오.");
                Console.WriteLine("------------------------------------------------");
            }
            else if (changeUI0 == true && changeUI1 == true && changeUI2 == true && changeUI2 == true)
            {
                int i = 1;
                foreach (var coin in coinList)
                {
                    Console.Write($"{i}. ");
                    market.UpAndDown(coin._isCorrect);
                    Console.Write($"{coin.Name}의 가격은: {coin.CoinPrice}");
                    Console.WriteLine($"        ) {coin.CoinCount} 개 보유 중");
                    Console.WriteLine();
                    i = i + 1;
                }
                Console.WriteLine("캔들 차트를 확인하고 싶은 코인의 번호를 입력하시오.");
                Console.WriteLine("------------------------------------------------");
            }


            if (changeUI0 == false && changeUI1 == true && changeUI2 == false && changeUI2 == false)
            {
                Console.WriteLine($"{(theTime) / 4}일이 지났습니다.");
                Console.WriteLine();
                CoinNotConcludedList(coinArray, buyCoinNotConcludeds, stopwatch, gameManager ,ref changeUI0, ref changeUI1, ref changeUI2, ref changeUI2);
            }

            if (changeUI0 == true && changeUI1 == true && changeUI2 == true && changeUI3 == false)
            {
                DisplayCandleChart
                    (showCoin, mostHL, oneSpaces, CVolatilityValues,
                     highValues, howSpaces, changeColor, stopwatch, gameManager, coinArray);
            }
        }

        //화면 오류 출력
        public void ErrorUI()
        {
            Console.WriteLine("올바른 입력값이 아닙니다.");
        }

        //화면 지우기
        public void ClearConsole0()
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

        //캔들 차트표 화면에 출력
        public void DisplayCandleChart
            (int showCoin, List<List<float>> mostHL, List<float> oneSpaces,List<List<float>> CVolatilityValues,
            List<List<float>> highValues,List<int[]> howSpaces, List<List<float>> changeColor,Stopwatch stopwatch, GameManager gameManager, Coin[] coinArray)
        {
            if (showCoin >= 1 && showCoin <= mostHL.Count)
            {
                // 콘솔 출력 위치 좌표 초기화
                ClearConsole0();

                // 앞줄 가격 표시
                int lenght = 0;
                for (int i = 20; i >= 0; i--)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(0, lenght);
                    Console.Write($"{mostHL[showCoin - 1][0] + gameManager.Trunf(oneSpaces[showCoin - 1] * i)}");
                    lenght++;
                }

                // 캔들 차트 출력
                int x = 13;
                int y = 0;
                int location = 0;

                Console.SetCursorPosition(x, y);
                for (int i = 0; i < CVolatilityValues[showCoin - 1].Count; i++)
                {
                    // 위치 정하는 값
                    int forLocation = (int)Math.Ceiling((highValues[showCoin - 1][i] - mostHL[showCoin - 1][0]) / oneSpaces[showCoin - 1]);
                    if (forLocation == 21)
                    {
                        forLocation = 20;
                    }
                    else if (21 < location)
                    {
                        stopwatch.Stop();
                        break; // 안전 종료
                    }

                    location = 20 - forLocation;

                    // 지정된 값만큼 출력하는 칸
                    for (int j = 0; j < location; j++)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write(' ');
                        y++;
                    }
                    for (int j = 0; j < howSpaces[showCoin - 1][i]; j++)
                    {
                        TrunColor(changeColor[showCoin - 1][i]);
                        Console.SetCursorPosition(x, y);
                        Console.Write('█');
                        y++;
                    }
                    for (int j = 0; j < 20 - location - howSpaces[showCoin - 1][i]; j++)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write(' ');
                        y++;
                    }
                    x++;
                    y = 0;
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine($"{coinArray[showCoin-1].Name}의 캔들차트 입니다.");
                Console.WriteLine("0을 입력하시면 다시 메인화면으로 돌아갑니다.");
            }
            else
            {
                Console.WriteLine("Invalid playerBuyCoin value.");
            }
        }

        //캔틀차트표 상승 하강 색깔변환
        public void TrunColor(float changeCandleColor)
        {
            //값이 음수면 상승 빨강
            if (changeCandleColor < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            //값이 양수면 하락 파랑
            else if (0 < changeCandleColor)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
        }


    }
}
