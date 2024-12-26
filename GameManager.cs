using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Day12_Project_GameDevleop.Program;

namespace Day12_Project_GameDevleop
{
    class GameManager : Coin
    {
        Random random = new Random();

        //GetInputNum 클래스 선언
        GetInputNum getInputNum = new GetInputNum();

        #region (함수) 매수 시스템
        public void Buy
            (ref Coin[] coin, ref Player player, ref int playerBuyCoin, ref bool changeUI0, ref bool changeUI1, ref bool changeUI2,
            LinkedList<BuyCoinNotConcluded> buyCoinNotConcludeds)
        {
            //존재하는 코인을 구매 할려고 시도 할 경우
            while (coin.Length + 1 > playerBuyCoin && playerBuyCoin > 0)
            {
                Console.WriteLine($"{coin[playerBuyCoin - 1].Name}의 매수 가격을 입력하시오.");
                bool asd0 = int.TryParse(Console.ReadLine(), out int howMuchBuy);

                Console.WriteLine($"{coin[playerBuyCoin - 1].Name}의 매수 수량을 입력하시오.");
                bool asd1 = int.TryParse(Console.ReadLine(), out int howManyBuy);

                //코인의 위치 파악을 위한 것
                int whereIsTheCoin = 0;
                whereIsTheCoin += 1;

                //걸어둔 코인의 정보들(얼마에, 몇개를, 어디에, 무슨코인을)
                buyCoinNotConcludeds.AddLast(new BuyCoinNotConcluded(howMuchBuy, howManyBuy, whereIsTheCoin, (playerBuyCoin-1)));

                changeUI0 = false;
                changeUI1 = false;
                changeUI2 = false;
                break;
            }
        }
        #endregion

        #region (함수) 매수 코인 선택 시 매수 체결 시스템
        public void BuyACoin(ref Coin[] coin, ref Player player, LinkedList<BuyCoinNotConcluded> buyCoinNotConcludeds, BuyCoinNotConcluded[] notConcluded)
        {
            //배열 중간에 삭제 시킬 것이므로 클론 화 추후에 진행
            for (int i = 0; i < buyCoinNotConcludeds.Count; i++)
            {
                //걸어둔 가격이 현재 시가보다 높을 경우
                if (coin[notConcluded[i].WhatCoin].CoinPrice <= notConcluded[i].HowMuchBuy)
                {
                    //-10~10%의 변동성 사이에서 체결
                    int asd = random.Next(-10, 10);
                    notConcluded[i].HowMuchBuy = notConcluded[i].HowMuchBuy + (notConcluded[i].HowMuchBuy * asd * 0.01f);

                    //변동된 매수의 가격의 전체 코인이 예수금보다 이하일 때 체결
                    if (player.PlayerMoney >= (notConcluded[i].HowMuchBuy * notConcluded[i].HowManyBuy))
                    {
                        Console.WriteLine($"{coin[notConcluded[i].WhatCoin].Name}이 ${notConcluded[i].HowMuchBuy}의 금액으로 체결되었습니다.");

                        //매수 되었으니 코인의 갯수 증가
                        coin[notConcluded[i].WhatCoin].CoinCount = coin[notConcluded[i].WhatCoin].CoinCount + (int)notConcluded[i].HowManyBuy;

                        //매수 되었으니 예수금 감소
                        player.PlayerMoney = player.PlayerMoney - (coin[notConcluded[i].WhatCoin].CoinPrice * (int)notConcluded[i].HowManyBuy);

                        //매수걸어뒀던 코인 리스트에서 삭제

                    }
                }
            }
        }
        #endregion

        #region(함수) 매도 시스템
        public Coin[] Sell(Coin[] coin, int inputA, ref float divideMoney, ref float myMoneys, ref int howManySell)
        {
            while (coin.Length + 1 > inputA)
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
                /*
                if (playerBuyCoin == 1)                    //1번 코인의 매도를 선택했을 경우
                {
                    if (coin[playerBuyCoin - 1].CoinCount > 0)
                    {
                        Console.WriteLine($"{coin[playerBuyCoin - 1].Name}은 최대 {coin[playerBuyCoin - 1].CoinCount} 개 매도 가능합니다.");
                        while (true)
                        {
                            bool coco = int.TryParse(Console.ReadLine(), out howManySell);
                            SellACoin(coin, ref howManySell, ref myMoneys, (playerBuyCoin - 1));
                            break;
                        }
                        break;
                    }
                    else if (coin[playerBuyCoin - 1].CoinCount <= 0)
                    {
                        Console.WriteLine($"{coin[playerBuyCoin - 1].Name}은 현재 {coin[playerBuyCoin - 1].CoinCount}개 보유중 이므로 매도가 불가합니다.");
                        break;
                    }
                }
                else if (playerBuyCoin == 2)                    //1번 코인의 매도를 선택했을 경우
                {
                    if (coin[playerBuyCoin - 1].CoinCount > 0)
                    {
                        Console.WriteLine($"{coin[playerBuyCoin - 1].Name}은 최대 {coin[playerBuyCoin - 1].CoinCount} 개 매도 가능합니다.");
                        while (true)
                        {
                            bool coco = int.TryParse(Console.ReadLine(), out howManySell);
                            SellACoin(coin, ref howManySell, ref myMoneys, (playerBuyCoin - 1));
                            break;
                        }
                        break;
                    }
                    else if (coin[playerBuyCoin - 1].CoinCount <= 0)
                    {
                        Console.WriteLine($"{coin[playerBuyCoin - 1].Name}은 현재 {coin[playerBuyCoin - 1].CoinCount}개 보유중 이므로 매도가 불가합니다.");
                        break;
                    }
                }
                else if (playerBuyCoin == 3)                    //1번 코인의 매도를 선택했을 경우
                {
                    if (coin[playerBuyCoin - 1].CoinCount > 0)
                    {
                        Console.WriteLine($"{coin[playerBuyCoin - 1].Name}은 최대 {coin[playerBuyCoin - 1].CoinCount} 개 매도 가능합니다.");
                        while (true)
                        {
                            bool coco = int.TryParse(Console.ReadLine(), out howManySell);
                            SellACoin(coin, ref howManySell, ref myMoneys, (playerBuyCoin - 1));
                            break;
                        }
                        break;
                    }
                    else if (coin[playerBuyCoin - 1].CoinCount <= 0)
                    {
                        Console.WriteLine($"{coin[playerBuyCoin - 1].Name}은 현재 {coin[playerBuyCoin - 1].CoinCount}개 보유중 이므로 매도가 불가합니다.");
                        break;
                    }
                }
                else if (playerBuyCoin == 4)                    //1번 코인의 매도를 선택했을 경우
                {
                    if (coin[playerBuyCoin - 1].CoinCount > 0)
                    {
                        Console.WriteLine($"{coin[playerBuyCoin - 1].Name}은 최대 {coin[playerBuyCoin - 1].CoinCount} 개 매도 가능합니다.");
                        while (true)
                        {
                            bool coco = int.TryParse(Console.ReadLine(), out howManySell);
                            SellACoin(coin, ref howManySell, ref myMoneys, (playerBuyCoin - 1));
                            break;
                        }
                        break;
                    }
                    else if (coin[playerBuyCoin - 1].CoinCount <= 0)
                    {
                        Console.WriteLine($"{coin[playerBuyCoin - 1].Name}은 현재 {coin[playerBuyCoin - 1].CoinCount}개 보유중 이므로 매도가 불가합니다.");
                        break;
                    }
                }
                else if (playerBuyCoin == 5)                    //1번 코인의 매도를 선택했을 경우
                {
                    if (coin[playerBuyCoin - 1].CoinCount > 0)
                    {
                        Console.WriteLine($"{coin[playerBuyCoin - 1].Name}은 최대 {coin[playerBuyCoin - 1].CoinCount} 개 매도 가능합니다.");
                        while (true)
                        {
                            bool coco = int.TryParse(Console.ReadLine(), out howManySell);
                            SellACoin(coin, ref howManySell, ref myMoneys, (playerBuyCoin - 1));
                            break;
                        }
                        break;
                    }
                    else if (coin[playerBuyCoin - 1].CoinCount <= 0)
                    {
                        Console.WriteLine($"{coin[playerBuyCoin - 1].Name}은 현재 {coin[playerBuyCoin - 1].CoinCount}개 보유중 이므로 매도가 불가합니다.");
                        break;
                    }
                }
                else if (playerBuyCoin == 6)                    //1번 코인의 매도를 선택했을 경우
                {
                    if (coin[playerBuyCoin - 1].CoinCount > 0)
                    {
                        Console.WriteLine($"{coin[playerBuyCoin - 1].Name}은 최대 {coin[playerBuyCoin - 1].CoinCount} 개 매도 가능합니다.");
                        while (true)
                        {
                            bool coco = int.TryParse(Console.ReadLine(), out howManySell);
                            SellACoin(coin, ref howManySell, ref myMoneys, (playerBuyCoin - 1));
                            break;
                        }
                        break;
                    }
                    else if (coin[playerBuyCoin - 1].CoinCount <= 0)
                    {
                        Console.WriteLine($"{coin[playerBuyCoin - 1].Name}은 현재 {coin[playerBuyCoin - 1].CoinCount}개 보유중 이므로 매도가 불가합니다.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine($"1번부터 ~ {coin.Length}번까지의 선택지 중 한가지를 선택하시오.");
                    break;
                }
                */
            }
            return coin;
        }
        #endregion

        #region(함수) 매도 코인 선택 시 매도 체결 시스템
        public Coin[] SellACoin(Coin[] coin, ref int howManySellCoin, ref float myMoneys, int needint)
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

        #region(함수) 매수 매도할 코인 선택 시
        public void GetKeyInputWhatCoinBuy
            (LinkedList<Coin> coinList, Coin[] coinArray, Player player, GameManager gameManager, ref int playerBuyCoin, LinkedList<BuyCoinNotConcluded> buyCoinNotConcludeds,
            ref bool changeUI0, ref bool changeUI1 ,ref bool changeUI2)
        {
            bool playerKeydown = int.TryParse(Console.ReadLine(), out playerBuyCoin);

            gameManager.Buy(ref coinArray, ref player, ref playerBuyCoin, ref changeUI0, ref changeUI1, ref changeUI2, buyCoinNotConcludeds);
        }


        public void GetKeyInputWhatCoinSell(LinkedList<Coin> coinList, Coin[] coinArray, Player player, GameManager gameManager)
        {
            bool playerKeydown1 = false;
            int playerBuyBtn = 0;               //1~코인갯수 중 무슨 코인을 매수 할거야?
            int playerHowManyBuy = 0;           //얼마만큼 코인 매수할거냐?
            float PriceDivideMyMoney = 0;       //몇개 매수 가능한지 정수

            playerKeydown1 = int.TryParse(Console.ReadLine(), out playerBuyBtn);
            PriceDivideMyMoney = (player.PlayerMoney / coinArray[playerBuyBtn - 1].CoinPrice);
            PriceDivideMyMoney = (int)PriceDivideMyMoney;

            gameManager.Sell(coinArray, playerBuyBtn, ref PriceDivideMyMoney, ref player.PlayerMoney, ref playerHowManyBuy);
        }
        #endregion

        #region (함수) 코인 상승 혹은 하락 시
        public void CoinUPORDown(bool isCorrect, Coin[] coinArray, int i)
        {
            //코인 상승 시
            if (isCorrect == true)
            {
                coinArray[i].CoinPrice = (float)(coinArray[i].CoinPrice + coinArray[i].TrunChangPrice);

            }

            //코인 하락시
            else if (isCorrect == false)
            {
                coinArray[i].CoinPrice = (float)(coinArray[i].CoinPrice - coinArray[i].TrunChangPrice);
            }
        }
        #endregion


        //키 입력 받음 1~4번 선택해야함.
        public void GetKeyInputOneToFour
        (ref bool changeUI0, ref bool changeUI1, ref bool changeUI2, 
            LinkedList<Coin> coinList, Coin[] coinArray, Player player,GameManager gameManager)
        {
            bool playerKeydown0 = false;
            
            //▼ 1~4번 중 무슨 선택할거냐?(매수, 매도, 뉴스, 돈벌기)
            int playerInput = 0;

            playerKeydown0 = int.TryParse(Console.ReadLine(), out playerInput);

            //숫자일 경우 => 1~4번 중 하나를 선택할 경우
            if (playerKeydown0 == true)
            {
                switch (playerInput)
                {
                    //매수 선택 시
                    case 1:
                        //여기서 캔들 차트표로 이동시켜야 함.
                        changeUI0 = false;
                        changeUI1 = false;
                        changeUI2 = true;
                        break;

                    //매도 선택 시
                    case 2:
                        //여기서 캔들 차트표로 이동시켜야 함.
                        changeUI0 = false;
                        changeUI1 = true;
                        changeUI2 = true;
                        break;

                    case 3:
                        changeUI0 = true;
                        changeUI1 = false;
                        changeUI2 = true;
                        Console.WriteLine("미체결 창으로 이동");
                        Console.WriteLine("미체결 된 리스트 중 선택 삭제 기능도 추가");
                        Console.WriteLine("자동으로 몇일 지났을 경우 삭제 기능도 추가");
                        break;

                    case 4:
                        Console.WriteLine("체결 창으로 이동");
                        Console.WriteLine("자동으로 몇일 지났을 경우 삭제 기능도 추가");
                        break;

                    default:
                        Console.WriteLine("1~4번안의 선택지만 선택하시오.");
                        break;
                }
            }
        }

        //코인 상승 혹은 하락 시
        
    
    }
}
