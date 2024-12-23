using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Day12_Project_GameDevleop.Program;

namespace Day12_Project_GameDevleop
{
    internal class Program
    {
        #region  (구조체) 코인
        /*
        public struct Coin            //코인 구조체
        {
            public string Name;             //코인의 이름
            public int CoinCount;           //코인의 갯수
            public float ChangePrice;       //변동되는 값
            public float CoinPrice;        //변동되는 코인 가격
            public float TrunChangPrice;    //소수점 컷 수들
        }*/
        #endregion

        static void Main(string[] args)
        {

            //UI클래스 선언
            UIManager uIManager = new UIManager();
            //Coin클래스 선언
            LinkedList<Coin> coinList = new LinkedList<Coin>();
            //Player클래스 선언
            Player player = new Player();
            //Market클래스 선언
            Market market = new Market();
            //GameManager클래스 선언
            GameManager gameManager = new GameManager();


            //코인 게임 타이틀
            //uIManager.Title();
            
            //코인 게임 시작 화면
            //uIManager.GameStart();
            
            //차트 상승 혹은 하락장의 확률 선언
            Random randomD = new Random();

            coinList.AddFirst(new Coin("비트코인",10000));
            coinList.AddLast(new Coin("이더리움", 10000));
            coinList.AddLast(new Coin("리플코인", 10000));
            coinList.AddLast(new Coin("경일코인", 10000));
            coinList.AddLast(new Coin("도지코인", 10000));
            coinList.AddLast(new Coin("계엄코인", 10000));
            coinList.AddLast(new Coin("계엄2코인", 10000));
            
            Coin[] coinArray = coinList.ToArray();

            //게임 시작 시 차트 출력 처음 값
            uIManager.GameStartChart(player, coinList);

            // 게임 시작 시 예수금 출력 값
            uIManager.PlayerMoney(player.PlayerMoney, player.PlayerCoinAllMoney);


            #region 게임이 계속 진행 되도록 하는 while문!
            //시간 선언
            Stopwatch stopwatch = new Stopwatch();
            //시간 흐름 시작
            stopwatch.Start();

            // 마지막 실행 시간을 저장할 변수
            int lastExecutionTime0 = 0;                   
            int lastExecutedTime1 = 0;

            int theTime = 0;
            int dayby = 1;
            while (true)
            {
                //stopwatch.ElapsedMilliseconds 실제 시간 흐르는 것 1000 = 1초
                int second = (int)stopwatch.ElapsedMilliseconds / 1000;     //1초의 흐름 시간 선언

                if (second - lastExecutedTime1 >= 1)
                {
                    #region 실시간 차트, 예수금, 코인총액, 날짜 변경 출력창
                    Console.Clear();
                    foreach (var coin in coinList)
                    {
                        market.UpAndDown(coin._isCorrect);
                        Console.Write($"현재 {coin.Name}의 가격은: {coin.CoinPrice} ");
                        Console.WriteLine($"        ) {coin.CoinCount} 개 보유 중");
                    }

                    theTime = +second;
                    Console.WriteLine();
                    Console.WriteLine($"{theTime / 3}일이 지났습니다...");
                    Console.WriteLine($"{dayby} / 3");
                    Console.WriteLine($"나의 예수금 : {player.PlayerMoney}");
                    Console.WriteLine($"나의 코인 총액 : {player.PlayerCoinAllMoney}");

                    Console.WriteLine("1번. 코인 매수");
                    Console.WriteLine("2번. 코인 매도");
                    Console.WriteLine("3번. 코인 뉴스");
                    Console.WriteLine("4번. 예수금 벌기");

                    dayby++;
                    if (dayby > 3)
                    {
                        dayby = 1;
                    }
                    #endregion
                    

                    // 1~4번 선택 할 시 !!!! (매수 매도 등등)
                    if (Console.KeyAvailable)
                    {
                        stopwatch.Stop();                   //시간 잠시 멈춰!!!!
                        bool playerKeydown0 = false;
                        bool playerKeydown1 = false;
                        int playerInput = 0;                //1~4번 중 무슨 선택할거냐?(매수, 매도, 뉴스, 돈벌기)
                        int playerBuyBtn = 0;               //1~코인갯수 중 무슨 코인을 매수 할거야?
                        int playerHowManyBuy = 0;           //얼마만큼 코인 매수할거냐?
                        float PriceDivideMyMoney = 0;       //몇개 매수 가능한지 정수

                        playerKeydown0 = int.TryParse(Console.ReadLine(), out playerInput);

                        if (playerKeydown0 == true)

                        {
                            switch (playerInput)
                            {
                                case 1:
                                    for (int i = 0; i < coinList.Count; i++)
                                    {
                                        Console.WriteLine($"{i + 1}번. {coinArray[i].Name}의 현재 시세는 {coinArray[i].CoinPrice}입니다. 매수 하시겠습니까?");
                                    }
                                    Console.WriteLine("무슨 코인을 매수 할 것인가?");
                                    playerKeydown1 = int.TryParse(Console.ReadLine(), out playerBuyBtn);

                                    PriceDivideMyMoney = (player.PlayerMoney / coinArray[playerBuyBtn - 1].CoinPrice);
                                    
                                    PriceDivideMyMoney = (int)PriceDivideMyMoney;
                                    
                                    gameManager.Buy(coinArray, playerBuyBtn, ref PriceDivideMyMoney, ref player.PlayerMoney, ref playerHowManyBuy);

                                    break;
                                
                                case 2:
                                    for (int i = 0; i < coinList.Count; i++)
                                    {
                                        Console.WriteLine($"{i + 1}. {coinArray[i].Name}의 현재 시세는 {coinArray[i].CoinPrice}입니다. 매도 하시겠습니까?");
                                    }

                                    Console.WriteLine("무슨 코인을 매도 할 것인가?");

                                    playerKeydown1 = int.TryParse(Console.ReadLine(), out playerBuyBtn);

                                    PriceDivideMyMoney = (player.PlayerMoney / coinArray[playerBuyBtn-1].CoinPrice);
                                    
                                    PriceDivideMyMoney = (int)PriceDivideMyMoney;

                                    gameManager.Sell(coinArray, playerBuyBtn, ref PriceDivideMyMoney, ref player.PlayerMoney, ref playerHowManyBuy);

                                    break;

                                #region(추후 진행) 뉴스, 돈벌기 시스템 아직
                                case 3:
                                    Console.WriteLine("3번 뉴스 창으로 이동");
                                    break;

                                case 4:
                                    Console.WriteLine("4번 예수금 벌기 창으로 이동");
                                    break;
                                    #endregion
                            }
                        }
                        stopwatch.Start();   //시간 다시 작동해!!!!
                    }

                    //플레이어가 보유한 모든 코인 총액
                    for (int i = 0; i < coinList.Count; i++)
                    {
                         player.PlayerCoinAllMoney = player.PlayerCoinAllMoney +coinArray[i].PlayerCoinMoney;
                    }

                    //마지막 실행 시간을 현재 시간으로 갱신
                    lastExecutedTime1 = second;
                }

                if (second - lastExecutionTime0 >= 3)     // 3초가 흐를 때 마다 차트 변경
                {
                    for (int i = 0; i < coinList.Count; i++)
                    {
                        coinArray[i].ChangePrice = 100;
                        market.PlusChangeCoin(ref coinArray);
                        

                        // 소수점 둘째 자리까지만 남기는 작업
                        coinArray[i].TrunChangPrice = (coinArray[i].ChangePrice * 10) / 10;

                        // 상승 혹은 하락 장 확률 함수
                        bool isCorrect = market.MinusOrPlus(randomD);                                 

                        //▼ 코인 상승시
                        if (isCorrect == true)
                        {
                            // 코인 CoinPrice만 있게 하기
                            coinArray[i].CoinPrice = (float)(coinArray[i].CoinPrice + coinArray[i].TrunChangPrice);
                            
                        }
                        //▼ 코인 하락시
                        else if (isCorrect == false)
                        {
                            // 코인 CoinPrice만 있게 하기
                            coinArray[i].CoinPrice = (float)(coinArray[i].CoinPrice - coinArray[i].TrunChangPrice);      
                        }
                        coinArray[i]._isCorrect = isCorrect;
                    }
                    //▼ 마지막 실행 시간을 현재 시간으로 갱신
                    lastExecutionTime0 = second;
                }
            }
            #endregion
        }

    }
}
