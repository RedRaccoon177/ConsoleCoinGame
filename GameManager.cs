using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Day12_Project_GameDevleop.Program;

namespace Day12_Project_GameDevleop
{
    class GameManager
    {
        /*
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
        */
    }
}
