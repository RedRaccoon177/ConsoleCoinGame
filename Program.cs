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

            //코인 게임 타이틀
            //uIManager.Title();
            
            //코인 게임 시작 화면
            //uIManager.GameStart();
            
            //차트 상승 혹은 하락장의 확률 선언
            Random randomD = new Random();

            coinList.AddFirst(new Coin("비트코인",100));
            coinList.AddLast(new Coin("이더리움", 100));
            coinList.AddLast(new Coin("리플코인", 100));
            coinList.AddLast(new Coin("경일코인", 100));
            coinList.AddLast(new Coin("도지코인", 100));
            coinList.AddLast(new Coin("계엄코인", 100));
            
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
                        UpAndDown(coin._isCorrect);
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

                                    Buy(coinArray, playerBuyBtn, ref PriceDivideMyMoney, ref player.PlayerMoney, ref playerHowManyBuy);

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

                                    Sell(coinArray, playerBuyBtn, ref PriceDivideMyMoney, ref player.PlayerMoney, ref playerHowManyBuy);

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
                        PlusChangeCoin(ref coinArray);

                        // 소수점 둘째 자리까지만 남기는 작업
                        coinArray[i].TrunChangPrice = (coinArray[i].ChangePrice * 10) / 10;

                        // 상승 혹은 하락 장 확률 함수
                        bool isCorrect = MinusOrPlus(randomD);                                 

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

        #region (함수) 입력된 코인의 값을 변동
        static Coin[] PlusChangeCoin(ref Coin[] coins)       // 입력된 코인의 값을 바꿔줌
        {
            int coinChangePercent;                          // 코인 퍼센트의 확률 0 ~ 100%
            float[] coinPercentResult = new float[6];       // 코인의 퍼센트 값 ex) $ 7.2
            float[] coinChangePrice = new float[6];         // 얼마나 변할 건지 퍼센트 값 ex) 7.2 %

            Random[] coinPriceRandom = new Random[6];       // 코인의 가격이 랜덤으로 상승하는 Random 생성
            for (int i = 0; i < coinPriceRandom.Length; i++)
            {
                coinPriceRandom[i] = new Random();
            }

            for (int i = 0; i < coins.Length; i++)
            {
                Random coinPercent = new Random();
                coinChangePercent = coinPercent.Next(0, 101);

                coinChangePrice[0] = coinPriceRandom[0].Next(0, 50);
                coinChangePrice[1] = coinPriceRandom[1].Next(55, 100);
                coinChangePrice[2] = coinPriceRandom[2].Next(100, 200);
                coinChangePrice[3] = coinPriceRandom[3].Next(200, 300);
                coinChangePrice[4] = coinPriceRandom[4].Next(300, 400);
                coinChangePrice[5] = coinPriceRandom[5].Next(400, 999);

                coinPercentResult[i] = coins[i].CoinPrice;

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

            for(int i = 0; i < coins.Length; i++)
            {
                coins[i].ChangePrice = coinPercentResult[i];
            }

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
        static Coin[] Buy(Coin[] coin, int inputA, ref float divideMoney, ref float myMoneys, ref int howManyBuy)
        {
            while (true)
            {
                if (inputA == 1)
                {
                    Console.WriteLine($"{coin[inputA - 1].Name}은 최대 {divideMoney} 개 매수 가능합니다.");
                    if (divideMoney == 0)
                    {
                        Console.WriteLine("0개는 매수가 불가능 합니다. (매수 불가능 기능 추가)");
                    }
                    else
                    {
                        while (true)
                        {
                            bool coco = int.TryParse(Console.ReadLine(), out howManyBuy);

                            BuyACoin(coin, ref howManyBuy, ref divideMoney, ref myMoneys, (inputA - 1));

                            break;
                        }
                    }
                    break;
                }
                else if (inputA == 2)
                {
                    Console.WriteLine($"{coin[inputA - 1].Name}은 최대 {divideMoney} 개 매수 가능합니다.");
                    if (divideMoney == 0)
                    {
                        Console.WriteLine("0개는 매수가 불가능 합니다. (매수 불가능 기능 추가)");
                    }
                    else
                    {
                        while (true)
                        {
                            bool coco = int.TryParse(Console.ReadLine(), out howManyBuy);

                            BuyACoin(coin, ref howManyBuy, ref divideMoney, ref myMoneys, (inputA - 1));

                            break;
                        }
                    }
                    break;
                }
                else if (inputA == 3)
                {
                    Console.WriteLine($"{coin[inputA - 1].Name}은 최대 {divideMoney} 개 매수 가능합니다.");
                    if (divideMoney == 0)
                    {
                        Console.WriteLine("0개는 매수가 불가능 합니다. (매수 불가능 기능 추가)");
                    }
                    else
                    {
                        while (true)
                        {
                            bool coco = int.TryParse(Console.ReadLine(), out howManyBuy);

                            BuyACoin(coin, ref howManyBuy, ref divideMoney, ref myMoneys, (inputA - 1));

                            break;
                        }
                    }
                    break;
                }
                else if (inputA == 4)
                {
                    Console.WriteLine($"{coin[inputA - 1].Name}은 최대 {divideMoney} 개 매수 가능합니다.");
                    if (divideMoney == 0)
                    {
                        Console.WriteLine("0개는 매수가 불가능 합니다. (매수 불가능 기능 추가)");
                    }
                    else
                    {
                        while (true)
                        {
                            bool coco = int.TryParse(Console.ReadLine(), out howManyBuy);

                            BuyACoin(coin, ref howManyBuy, ref divideMoney, ref myMoneys, (inputA - 1));

                            break;
                        }
                    }
                    break;
                }
                else if (inputA == 5)
                {
                    Console.WriteLine($"{coin[inputA - 1].Name}은 최대 {divideMoney} 개 매수 가능합니다.");
                    if (divideMoney == 0)
                    {
                        Console.WriteLine("0개는 매수가 불가능 합니다. (매수 불가능 기능 추가)");
                    }
                    else
                    {
                        while (true)
                        {
                            bool coco = int.TryParse(Console.ReadLine(), out howManyBuy);

                            BuyACoin(coin, ref howManyBuy, ref divideMoney, ref myMoneys, (inputA - 1));

                            break;
                        }
                    }
                    break;
                }
                else if (inputA == 6)
                {
                    Console.WriteLine($"{coin[inputA - 1].Name}은 최대 {divideMoney} 개 매수 가능합니다.");
                    if (divideMoney == 0)
                    {
                        Console.WriteLine("0개는 매수가 불가능 합니다. (매수 불가능 기능 추가)");
                    }
                    else
                    {
                        while (true)
                        {
                            bool coco = int.TryParse(Console.ReadLine(), out howManyBuy);

                            BuyACoin(coin, ref howManyBuy, ref divideMoney, ref myMoneys, (inputA - 1));

                            break;
                        }
                    }
                    break;
                }
                else
                {
                    Console.WriteLine($"1번부터 ~ {coin.Length}번까지의 선택지 중 한가지를 선택하시오.");
                }
            }
            return coin;
        }
        #endregion
        #region (함수) 매수 코인 선택 시 매수 체결 시스템
        static Coin[] BuyACoin(Coin[] coinss, ref int howManyCoin, ref float PriceDivideMyMoney1, ref float myMoneys, int needint)
        {
            if (howManyCoin == 0)                          //매수 가능 갯수를 0이 아니라고 했을 때
            {
                Console.WriteLine("0 혹은 글자를 입력한 듯");
            }
            else if (howManyCoin > PriceDivideMyMoney1)     //매수 가능 갯수를 초과 했을 경우 
            {
                Console.WriteLine("매수 가능 갯수를 초과하셨습니다. 다시 입력하시오.");
            }
            else if (1 <= howManyCoin && howManyCoin <= PriceDivideMyMoney1)
            {
                Console.WriteLine($"{coinss[needint].Name}매수 되었습니다.");
                //코인 갯수 증가
                coinss[needint].CoinCount = coinss[needint].CoinCount + howManyCoin;

                //예수금 감소
                myMoneys = myMoneys - (coinss[needint].CoinPrice * howManyCoin);
            }
            return coinss;
        }
        #endregion
        #region(함수) 매도 시스템
        static Coin[] Sell(Coin[] coin, int inputA, ref float divideMoney, ref float myMoneys, ref int howManySell)
        {
            while (true)
            {
                if (inputA == 1)                    //1번 코인의 매도를 선택했을 경우
                {
                    if (coin[inputA - 1].CoinCount > 0)
                    {
                        Console.WriteLine($"{coin[inputA - 1].Name}은 최대 {coin[inputA -1].CoinCount} 개 매도 가능합니다.");
                        while (true)
                        {
                            bool coco = int.TryParse(Console.ReadLine(), out howManySell);
                            SellACoin(coin, ref howManySell, ref myMoneys, (inputA - 1));
                            break;
                        }
                        break;
                    }
                    else if (coin[inputA - 1].CoinCount <= 0)
                    {
                        Console.WriteLine($"{coin[inputA - 1].Name}은 현재 {coin[inputA - 1].CoinCount}개 보유중 이므로 매도가 불가합니다.");
                        break;
                    }
                }
                else if (inputA == 2)                    //1번 코인의 매도를 선택했을 경우
                {
                    if (coin[inputA - 1].CoinCount > 0)
                    {
                        Console.WriteLine($"{coin[inputA - 1].Name}은 최대 {coin[inputA - 1].CoinCount} 개 매도 가능합니다.");
                        while (true)
                        {
                            bool coco = int.TryParse(Console.ReadLine(), out howManySell);
                            SellACoin(coin, ref howManySell, ref myMoneys, (inputA - 1));
                            break;
                        }
                        break;
                    }
                    else if (coin[inputA - 1].CoinCount <= 0)
                    {
                        Console.WriteLine($"{coin[inputA - 1].Name}은 현재 {coin[inputA - 1].CoinCount}개 보유중 이므로 매도가 불가합니다.");
                        break;
                    }
                }
                else if (inputA == 3)                    //1번 코인의 매도를 선택했을 경우
                {
                    if (coin[inputA - 1].CoinCount > 0)
                    {
                        Console.WriteLine($"{coin[inputA - 1].Name}은 최대 {coin[inputA - 1].CoinCount} 개 매도 가능합니다.");
                        while (true)
                        {
                            bool coco = int.TryParse(Console.ReadLine(), out howManySell);
                            SellACoin(coin, ref howManySell, ref myMoneys, (inputA - 1));
                            break;
                        }
                        break;
                    }
                    else if (coin[inputA - 1].CoinCount <= 0)
                    {
                        Console.WriteLine($"{coin[inputA - 1].Name}은 현재 {coin[inputA - 1].CoinCount}개 보유중 이므로 매도가 불가합니다.");
                        break;
                    }
                }
                else if (inputA == 4)                    //1번 코인의 매도를 선택했을 경우
                {
                    if (coin[inputA - 1].CoinCount > 0)
                    {
                        Console.WriteLine($"{coin[inputA - 1].Name}은 최대 {coin[inputA - 1].CoinCount} 개 매도 가능합니다.");
                        while (true)
                        {
                            bool coco = int.TryParse(Console.ReadLine(), out howManySell);
                            SellACoin(coin, ref howManySell, ref myMoneys, (inputA - 1));
                            break;
                        }
                        break;
                    }
                    else if (coin[inputA - 1].CoinCount <= 0)
                    {
                        Console.WriteLine($"{coin[inputA - 1].Name}은 현재 {coin[inputA - 1].CoinCount}개 보유중 이므로 매도가 불가합니다.");
                        break;
                    }
                }
                else if (inputA == 5)                    //1번 코인의 매도를 선택했을 경우
                {
                    if (coin[inputA - 1].CoinCount > 0)
                    {
                        Console.WriteLine($"{coin[inputA - 1].Name}은 최대 {coin[inputA - 1].CoinCount} 개 매도 가능합니다.");
                        while (true)
                        {
                            bool coco = int.TryParse(Console.ReadLine(), out howManySell);
                            SellACoin(coin, ref howManySell, ref myMoneys, (inputA - 1));
                            break;
                        }
                        break;
                    }
                    else if (coin[inputA - 1].CoinCount <= 0)
                    {
                        Console.WriteLine($"{coin[inputA - 1].Name}은 현재 {coin[inputA - 1].CoinCount}개 보유중 이므로 매도가 불가합니다.");
                        break;
                    }
                }
                else if (inputA == 6)                    //1번 코인의 매도를 선택했을 경우
                {
                    if (coin[inputA - 1].CoinCount > 0)
                    {
                        Console.WriteLine($"{coin[inputA - 1].Name}은 최대 {coin[inputA - 1].CoinCount} 개 매도 가능합니다.");
                        while (true)
                        {
                            bool coco = int.TryParse(Console.ReadLine(), out howManySell);
                            SellACoin(coin, ref howManySell, ref myMoneys, (inputA - 1));
                            break;
                        }
                        break;
                    }
                    else if (coin[inputA - 1].CoinCount <= 0)
                    {
                        Console.WriteLine($"{coin[inputA - 1].Name}은 현재 {coin[inputA - 1].CoinCount}개 보유중 이므로 매도가 불가합니다.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine($"1번부터 ~ {coin.Length}번까지의 선택지 중 한가지를 선택하시오.");
                    break;
                }
            }
            return coin;
        }
        #endregion
        #region(함수) 매도 코인 선택 시 매도 체결 시스템
        static Coin[] SellACoin(Coin[] coin, ref int howManySellCoin, ref float myMoneys, int needint)
        {
            if (howManySellCoin == 0)                          //매수 가능 갯수를 0이 아니라고 했을 때
            {
                Console.WriteLine("0 혹은 글자를 입력한 듯");
            }
            else if (howManySellCoin > coin[needint].CoinCount)     //매수 가능 갯수를 초과 했을 경우 
            {
                Console.WriteLine("매도 가능 갯수를 초과하셨습니다. 다시 입력하시오.");
            }
            else if (1 <= howManySellCoin && howManySellCoin <= coin[needint].CoinCount)
            {
                Console.WriteLine($"{coin[needint].Name}이 {howManySellCoin}개 매도 되었습니다.");
                //코인 갯수 감소
                coin[needint].CoinCount = coin[needint].CoinCount - howManySellCoin;

                //예수금 감소
                myMoneys = myMoneys + (coin[needint].CoinPrice * howManySellCoin);
            }
            return coin;
        }
        #endregion
    }
}
