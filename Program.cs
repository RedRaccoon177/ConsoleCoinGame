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
        public struct Coin              //코인 구조체
        {
            public string Name;             //코인의 이름
            public int coinCount;           //코인의 갯수
            public float changePrice;       //변동되는 값
            public float afterPrice;        //후의 코인 가격
            public float beforePrice;       //전의 코인 가격    
            public float trunChangPrice;    //소수점 컷 수들
        }

        static void Main(string[] args)
        {

            #region 게임 시작 화면
            /*while (true)
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
            }*/
            #endregion
            Random randomD = new Random();
            
            Coin[] coin = new Coin[6];                    // Coin 구조체 선언

            float myMoney = 1000f;                                      //나의 현재 보유 금액
            float[] myCoinSMoney = new float[6];                        //전체 코인 보유 금액을 위한 작은 것
            for (int i = 0; i < coin.Length; i++)
            {
                myCoinSMoney[i] = 0;
            }
            float myCoinMoney = 0;

            #region 코인 6개 이름
            coin[0].Name = "비트코인";                     
            coin[1].Name = "이더리움";
            coin[2].Name = "리플코인";
            coin[3].Name = "경일코인";
            coin[4].Name = "도지코인";
            coin[5].Name = "계엄코인";
            #endregion

            #region 코인 구매 시 코인 소유 갯수 
            for (int i = 0; i < coin.Length; i++)        
            {
                coin[i].coinCount = 0;
            }
            #endregion

            #region 코인 처음 가격
            coin[0].afterPrice = 100;
            coin[1].afterPrice = 10000;
            coin[2].afterPrice = 10000;
            coin[3].afterPrice = 10000;
            coin[4].afterPrice = 10000;
            coin[5].afterPrice = 10000;
            #endregion

            Console.Title = "코인 가즈아아아아앗!!!";    // 타이틀 이름
            Console.SetWindowSize(100, 50);         // 가로, 세로 창 시작

            #region Console.WriteLine 인게임 화면 출력창
            //Console.Clear();
            //Console.WriteLine($"현재 보유 금액:$ {myMoney}");
            //Console.WriteLine($"코인 보유 금액:$ {myCoinMoney}");
            //Console.WriteLine("----------------------------------------------------------------");
            //Console.WriteLine("|                                                              |");
            //Console.WriteLine("|                                                              |");
            //Console.WriteLine("|                                                              |");
            //Console.WriteLine("|                                                              |");
            //Console.WriteLine("|                                                              |");
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
            #endregion

            #region 게임 시작 시 차트 출력 처음 값
            for (int i = 0; i < coin.Length; i++)
            {
                Console.Write($"현재 {coin[i].Name}의 가격은: {coin[i].afterPrice}");
                Console.WriteLine($"        ) {coin[i].coinCount} 개 보유 중");
            }
            Console.WriteLine();
            Console.WriteLine($"0일이 지났습니다...");
            Console.WriteLine($"0 / 3");
            #endregion

            #region 게임 시작 시 예수금 출력 값
            Console.WriteLine($"나의 예수금 : {myMoney}");
            Console.WriteLine($"나의 코인 총액 : {myCoinMoney}");
            #endregion

            #region 게임이 계속 진행 되도록 하는 while문! (안에 출력창있음)
            Stopwatch stopwatch = new Stopwatch();              //시간을 선언
            stopwatch.Start();                                  //시간이 흐르기 시작한다. 멈추고 싶으면 Stop해주면 됨
            int lastExecutionTime0 = 0;                          // 마지막 실행 시간을 저장할 변수
            int lastExecutedTime1 = 0;
            int lastExecutedTime2 = 0;
            bool[] inpu = new bool[6];

            int theTime = 0;
            int dayby = 1;
            while (true)
            {
                //stopwatch.ElapsedMilliseconds 실제 시간 흐르는 것 1000 = 1초
                int second = (int)stopwatch.ElapsedMilliseconds / 1000;     //1초의 흐름 시간 선언

                if (second - lastExecutedTime2 >= 1)
                {
                    #region 실시간 차트, 예수금, 코인총액, 날짜 변경 출력창
                    Console.Clear();
                    for (int i = 0; i < coin.Length; i++)
                    {
                        UpAndDown(inpu[i]);
                        Console.Write($"현재 {coin[i].Name}의 가격은: {coin[i].afterPrice} ");
                        Console.WriteLine($"        ) {coin[i].coinCount} 개 보유 중");
                    }

                    theTime = +second;
                    Console.WriteLine();
                    Console.WriteLine($"{theTime / 3}일이 지났습니다...");
                    Console.WriteLine($"{dayby} / 3");
                    Console.WriteLine($"나의 예수금 : {myMoney}");
                    Console.WriteLine($"나의 코인 총액 : {myCoinMoney}");

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

                        if(playerKeydown0 == true)

                        {
                            switch (playerInput) 
                            {
                                case 1:
                                    for (int i = 0; i < coin.Length; i++)
                                    {
                                        Console.WriteLine($"{i+1}. {coin[i].Name}의 현재 시세는 {coin[i].afterPrice}입니다. 매수 하실겁니까?");
                                    }

                                    Console.WriteLine("무슨 코인을 매수 할 것인가?");
                                    playerKeydown1 = int.TryParse(Console.ReadLine(), out playerBuyBtn);

                                    switch (playerBuyBtn)
                                    {
                                            case 1:
                                            PriceDivideMyMoney = (myMoney / coin[0].afterPrice);
                                            PriceDivideMyMoney = (int)PriceDivideMyMoney;
                                            Console.WriteLine($"{coin[0].Name}은 최대 {PriceDivideMyMoney} 개 매수 가능합니다.");
                                            if (PriceDivideMyMoney == 0)
                                            {
                                                Console.WriteLine("매수 불가능 기능 추가");
                                            }
                                            else
                                            {
                                                while (true)
                                                {
                                                    bool coco = int.TryParse(Console.ReadLine(),out playerHowManyBuy);
                                                   
                                                    if (playerHowManyBuy == 0)                          //매수 가능 갯수를 0이 아니라고 했을 때
                                                    {
                                                        Console.WriteLine("0 혹은 글자를 입력한 듯");
                                                    }
                                                    else if (playerHowManyBuy > PriceDivideMyMoney)     //매수 가능 갯수를 초과 했을 경우 
                                                    {
                                                        Console.WriteLine("매수 가능 갯수를 초과하셨습니다. 다시 입력하시오.");
                                                    }
                                                    else  if(1<= playerHowManyBuy && playerHowManyBuy <= PriceDivideMyMoney)
                                                    {
                                                        Console.WriteLine("매수 되었습니다. 기능 추가");
                                                        //코인 갯수 증가
                                                        coin[0].coinCount = coin[0].coinCount + playerHowManyBuy;
                                                        
                                                        //예수금 감소
                                                        myMoney = myMoney - (coin[0].afterPrice * playerHowManyBuy);

                                                        //총 코인 금액 = (코인 카운트 * 코인 실시간 가격)
                                                        

                                                        break;
                                                    }
                                                }
                                            }
                                            //BuyACoin();
                                            break;
                                    }

                                    break;
                                    case 2:
                                    Console.WriteLine("2번 매도 창으로 이동");
                                    break;
                                    case 3:
                                    Console.WriteLine("3번 뉴스 창으로 이동");
                                    break ;
                                    case 4:
                                    Console.WriteLine("4번 예수금 벌기 창으로 이동");
                                    break ;
                            }
                        }
                        stopwatch.Start();                  //시간 다시 작동해!!!!
                    }

                    for (int i = 0; i < coin.Length; i++)
                    {
                        myCoinSMoney[i] = coin[i].coinCount * coin[i].afterPrice;
                    }

                    myCoinMoney = myCoinSMoney[0] + myCoinSMoney[1] + myCoinSMoney[2] + myCoinSMoney[3] + myCoinSMoney[4] + myCoinSMoney[5];

                    //▼ 마지막 실행 시간을 현재 시간으로 갱신
                    lastExecutedTime2 = second;
                }

                if (second - lastExecutionTime0 >= 3)     // 3초가 흐를 때 마다 차트 변경
                {
                    for (int i = 0; i < coin.Length; i++)
                    {
                        coin[i].changePrice = 100;
                        PlusChangeCoin(ref coin);
                        coin[i].trunChangPrice = (coin[i].changePrice * 10) / 10;                // 소수점 둘째 자리까지만 남기는 작업

                        bool isCorrect = MinusOrPlus(randomD);                                   // 상승 혹은 하락 장 확률 함수

                        if (isCorrect == true)                                                      // 코인 상승!
                        {
                            coin[i].afterPrice = coin[i].afterPrice + coin[i].trunChangPrice;       // 코인 afterPrice만 있게 하기
                        }
                        else if (isCorrect == false)                                                // 코인 하락!
                        {
                            coin[i].afterPrice = coin[i].afterPrice - coin[i].trunChangPrice;       // 코인 afterPrice만 있게 하기
                        }
                        inpu[i] = isCorrect;
                    }

                    //▼ 마지막 실행 시간을 현재 시간으로 갱신
                    lastExecutionTime0 = second;
                }

            }
            #endregion
        }

        #region (함수) 입력된 코인의 값을 변동
        static Coin[] PlusChangeCoin(ref Coin[] coins)       // 입력된 코인의 값을 바꿔줌
        {
            int coinChangePercent;                                           // 코인 퍼센트의 확률 0 ~ 100%
            float[] coinPercentResult = new float[6];                        // 코인의 퍼센트 값 ex) $ 7.2
            float[] coinChangePrice = new float[6];                          // 얼마나 변할 건지 퍼센트 값 ex) 7.2 %

            Random[] coinPriceRandom = new Random[6];                 // 코인의 가격이 랜덤으로 상승하는 Random 생성
            for (int i = 0; i < coinPriceRandom.Length; i++)
            {
                coinPriceRandom[i] = new Random();
            }

            #region 차트 변동 값
            //  0~5% 변동 => 50%    
            // 5~10% 변동 => 25%   
            //10~20% 변동 => 10%  
            //20~30% 변동 => 5%
            //30~40% 변동 => 4%
            //40~99% 변동 => 1%
            #endregion

            int coinLenth = 6;                                    //코인 종목 횟수
            for (int i = 0; i < coinLenth; i++)
            {
                Random coinPercent = new Random();
                coinChangePercent = coinPercent.Next(0, 100);

                coinChangePrice[0] = coinPriceRandom[0].Next(0, 50);
                coinChangePrice[1] = coinPriceRandom[1].Next(51, 100);
                coinChangePrice[2] = coinPriceRandom[2].Next(101, 200);
                coinChangePrice[3] = coinPriceRandom[3].Next(201, 300);
                coinChangePrice[4] = coinPriceRandom[4].Next(301, 400);
                coinChangePrice[5] = coinPriceRandom[5].Next(401, 999);

                coinPercentResult[i] = coins[i].afterPrice;

                if (coinChangePercent <= 50)  //50 확률로 
                {
                    coinChangePrice[0] = coinChangePrice[0] * 0.1f;         //변할 확률% ex) 0~5%

                    coinPercentResult[i] = coinPercentResult[i] * coinChangePrice[0] * 0.01f;
                }
                else if (50 < coinChangePercent && coinChangePercent <= 75)
                {
                    coinChangePrice[1] = coinChangePrice[1] * 0.1f;           //변할 확률% ex) 5~10%

                    coinPercentResult[i] = coinPercentResult[i] * coinChangePrice[1] * 0.01f;
                }
                else if (75 < coinChangePercent && coinChangePercent <= 90)
                {
                    coinChangePrice[2] = coinChangePrice[2] * 0.1f;          //변할 확률% ex) 10~20%

                    coinPercentResult[i] = coinPercentResult[i] * coinChangePrice[2] * 0.01f;
                }
                else if (90 < coinChangePercent && coinChangePercent <= 95)
                {
                    coinChangePrice[3] = coinChangePrice[3] * 0.1f;            //변할 확률% ex) 20~30%

                    coinPercentResult[i] = coinPercentResult[i] * coinChangePrice[3] * 0.01f;
                }
                else if (95 < coinChangePercent && coinChangePercent <= 99)
                {
                    coinChangePrice[4] = coinChangePrice[4] * 0.1f;             //변할 확률% ex) 30~40%

                    coinPercentResult[i] = coinPercentResult[i] * coinChangePrice[4] * 0.01f;
                }
                else if (coinChangePercent == 100)
                {
                    coinChangePrice[5] = coinChangePrice[5] * 0.1f;            //변할 확률% ex) 40~99%

                    coinPercentResult[i] = coinPercentResult[i] * coinChangePrice[5] * 0.01f;
                }
                else
                {
                    //상장 폐지 만들까?
                }
            }
            coins[0].changePrice = coinPercentResult[0];
            coins[1].changePrice = coinPercentResult[1];
            coins[2].changePrice = coinPercentResult[2];
            coins[3].changePrice = coinPercentResult[3];
            coins[4].changePrice = coinPercentResult[4];
            coins[5].changePrice = coinPercentResult[5];
            return coins;
        }
        #endregion

        #region (함수) 55:45 확률 만들기
        static bool MinusOrPlus(Random randomD)
        {
            bool input = true;

            int temp0 = randomD.Next(0, 100);

            if (temp0 < 55)
            {
                input = true;
            }
            else if (temp0 >= 45)
            {
                input = false;
            }
            return input;
        }
        #endregion

        #region (함수) 양전 혹은 음전 시스템
        static void UpAndDown(bool inpuq)
        {
            if (inpuq == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("▲  )");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (inpuq == false)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("▼  )");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        #endregion

        #region (함수) 매수 시스템
        //static int BuyOrSell()
        //{

        //    return
        //}
        #endregion

        #region 매수 코인 선택 시 매수 체결 시스템
        //static int BuyACoin(int howManyCoin)
        //{
        //    Console.WriteLine("1번 코인을 몇개 매수하시겠습니까?");
        //    Console.WriteLine("현재 매수 가능한 최대 갯수: 몇개");
        //    Console.Write("입력하시오: ");
        //}
        #endregion
    }
}
