using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Day12_Project_GameDevleop.Program;

namespace Day12_Project_GameDevleop
{
    class Market
    {
        #region (함수) 입력된 코인의 값을 변동
        public Coin[] PlusChangeCoin(ref Coin[] coins)       // 입력된 코인의 값을 바꿔줌
        {
            int coinChangePercent;                          // 코인 퍼센트의 확률 0 ~ 100%
            float[] coinPercentResult = new float[coins.Count()];       // 코인의 퍼센트 값 ex) $ 7.2
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

            for (int i = 0; i < coins.Length; i++)
            {
                coins[i].ChangePrice = coinPercentResult[i];
            }

            return coins;
        }
        #endregion

        #region (함수) 55:45 확률 만들기
        public bool MinusOrPlus(Random randomD)
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
        public void UpAndDown(bool isCorrect)
        {
            if (isCorrect == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("▲  )");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (isCorrect == false)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("▼  )");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        #endregion

    }
}
