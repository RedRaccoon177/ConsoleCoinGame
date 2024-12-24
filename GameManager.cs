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
        #region (함수) 매수 시스템
        public Coin[] Buy(Coin[] coin, int inputA, ref float divideMoney, ref float myMoneys, ref int howManyBuy)
        {
            while (coin.Length + 1 > inputA)
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
            return coin;
        }
        #endregion

        #region (함수) 매수 코인 선택 시 매수 체결 시스템
        public Coin[] BuyACoin(Coin[] coin, ref int howManyCoin, ref float PriceDivideMyMoney1, ref float myMoneys, int needint)
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
                Console.WriteLine($"{coin[needint].Name}매수 되었습니다.");

                //코인 갯수 증가
                coin[needint].CoinCount = coin[needint].CoinCount + howManyCoin;

                //예수금 감소
                myMoneys = myMoneys - (coin[needint].CoinPrice * howManyCoin);
            }
            return coin;
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
                if (inputA == 1)                    //1번 코인의 매도를 선택했을 경우
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

        //키 입력 받음 1~4번 선택해야함.
        public void GetKeyInput(LinkedList<Coin> coinList, Coin[] coinArray, Player player,GameManager gameManager)
        {
            bool playerKeydown0 = false;
            bool playerKeydown1 = false;
            int playerInput = 0;                //1~4번 중 무슨 선택할거냐?(매수, 매도, 뉴스, 돈벌기)
            int playerBuyBtn = 0;               //1~코인갯수 중 무슨 코인을 매수 할거야?
            int playerHowManyBuy = 0;           //얼마만큼 코인 매수할거냐?
            float PriceDivideMyMoney = 0;       //몇개 매수 가능한지 정수

            playerKeydown0 = int.TryParse(Console.ReadLine(), out playerInput);

            //1~4번 중 하나를 선택할 경우
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

                        PriceDivideMyMoney = (player.PlayerMoney / coinArray[playerBuyBtn - 1].CoinPrice);

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
        }

        //코인 상승 혹은 하락 시
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
    
        
    
    }
}
