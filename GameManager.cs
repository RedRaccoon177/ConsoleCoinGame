using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Day12_Project_GameDevleop.Program;

namespace Day12_Project_GameDevleop
{
    class GameManager : Coin
    {
        Random random = new Random();

        public void SelectCoin(ref int showCoin, Coin[] coin, ref bool changeUI0, ref bool changeUI1, ref bool changeUI2, ref bool changeUI3)
        {
            //무슨 코인을 선택 할 것이냐?
            bool playerKeydown = int.TryParse(Console.ReadLine(), out int showCoin1);

            showCoin = showCoin1;

            if (0 < showCoin && showCoin < coin.Length + 1)
            {
                changeUI0 = true;
                changeUI1 = true;
                changeUI2 = true;
                changeUI3 = false;
            }
            else if(showCoin == 0)
            {
                changeUI0 = false;
                changeUI1 = false;
                changeUI2 = false;
                changeUI3 = false;
            }
        }



        #region 매수 시스템
        public void Buy
            (ref Coin[] coin, ref bool changeUI0, ref bool changeUI1, ref bool changeUI2, ref bool changeUI3
            , LinkedList<BuyCoinNotConcluded> buyCoinNotConcludeds, ref int whereIsTheCoin)
        {
            //무슨 코인을 선택 할 것이냐?
            bool playerKeydown = int.TryParse(Console.ReadLine(), out int playerBuyCoin);

            while (1 <= playerBuyCoin && playerBuyCoin <= coin.Length)
            {
                //존재하는 코인을 구매 할려고 시도 할 경우
                Console.WriteLine($"{coin[playerBuyCoin - 1].Name}의 매수 가격을 입력하시오.");
                bool asd0 = int.TryParse(Console.ReadLine(), out int howMuchBuy);

                Console.WriteLine($"{coin[playerBuyCoin - 1].Name}의 매수 수량을 입력하시오.");
                bool asd1 = int.TryParse(Console.ReadLine(), out int howManyBuy);

                //매수 혹은 매도 확인
                bool buyORSell = false;

                //걸어둔 코인의 정보들(얼마에, 몇개를, 어디에, 무슨코인을, 매수 혹은 매도 확인)
                buyCoinNotConcludeds.AddLast(new BuyCoinNotConcluded(howMuchBuy, howManyBuy, whereIsTheCoin, (playerBuyCoin - 1), buyORSell));

                //코인의 위치 파악을 위한 +1

                whereIsTheCoin += 1;

                break;
            }

            changeUI0 = false;
            changeUI1 = false;
            changeUI2 = false;
            changeUI3 = false;
        }
        #endregion

        #region 매도 시스템
        public void Sell
            (ref Coin[] coin, ref bool changeUI0, ref bool changeUI1, ref bool changeUI2,
            LinkedList<BuyCoinNotConcluded> buyCoinNotConcludeds, ref int whereIsTheCoin)
        {
            //무슨 코인을 매도 할 것이냐?
            bool playerKeydown = int.TryParse(Console.ReadLine(), out int playerBuyCoin);

            //존재하는 코인을 매도 할려고 시도 할 경우
            while (1 <= playerBuyCoin && playerBuyCoin <= coin.Length)
            {
                //매도 하려는 코인의 수량이 존재 할 경우
                if (0 < coin[playerBuyCoin - 1].CoinCount)
                {
                    Console.WriteLine($"{coin[playerBuyCoin - 1].Name}의 매도 가격을 입력하시오.");
                    bool asd0 = int.TryParse(Console.ReadLine(), out int howMuchBuy);

                    Console.WriteLine($"{coin[playerBuyCoin - 1].Name}의 매도 수량을 입력하시오.");
                    bool asd1 = int.TryParse(Console.ReadLine(), out int howManyBuy);

                    //매도 하려는 갯수가 보유 갯수이하 일 경우
                    if (coin[playerBuyCoin - 1].CoinCount >= howManyBuy)
                    {
                        //매수 혹은 매도 확인
                        bool buyORSell = true;

                        //걸어둔 코인의 정보들(얼마에, 몇개를, 어디에, 무슨코인을)
                        buyCoinNotConcludeds.AddLast(new BuyCoinNotConcluded(howMuchBuy, howManyBuy, whereIsTheCoin, (playerBuyCoin - 1), buyORSell));

                        //코인의 위치 파악을 위한 +1
                        whereIsTheCoin += 1;
                    }
                    else if (coin[playerBuyCoin - 1].CoinCount < howManyBuy)
                    {
                        Console.WriteLine($"{coin[playerBuyCoin - 1].Name}의 보유하신 수량을 초과하셨습니다.");
                    }
                }
                else
                {
                    Console.WriteLine($"{coin[playerBuyCoin - 1].Name}을 보유하고 계시지 않습니다.");
                }
                break;
            }
            changeUI0 = false;
            changeUI1 = false;
            changeUI2 = false;
        }
        #endregion

        #region  매수 혹은 매도 코인 선택 시 체결 시스템
        public void BuyORSellACoin(ref Coin[] coin, ref Player player, LinkedList<BuyCoinNotConcluded> buyCoinNotConcludeds)
        {
            float[] temp0 = new float[coin.Length];

            //미체결 코인 클래스 배열화
            BuyCoinNotConcluded[] notConcluded = buyCoinNotConcludeds.ToArray();

            //배열 중간에 삭제 시킬 것이므로 클론 화 추후에 진행
            for (int i = 0; i < buyCoinNotConcludeds.Count; i++)
            {
                //매수 일 경우
                if(notConcluded[i].BuyORSell == false)
                {
                    //걸어둔 가격이 현재 시가보다 높을 경우
                    if (coin[notConcluded[i].WhatCoin].CoinPrice <= notConcluded[i].HowMuchLock)
                    {
                        //-5~5%의 변동성 사이에서 체결
                        int closingChange = random.Next(-5, 5);
                        temp0[i] = coin[notConcluded[i].WhatCoin].CoinPrice + (coin[notConcluded[i].WhatCoin].CoinPrice * closingChange * 0.01f);


                        //변동된 매수의 가격의 전체 코인이 예수금보다 이하일 때 체결
                        if (player.PlayerMoney >= (temp0[i] * notConcluded[i].HowManyLock))
                        {
                            notConcluded[i].HowMuchLock = temp0[i];

                            Console.WriteLine($"{coin[notConcluded[i].WhatCoin].Name}이 ${temp0[i]}의 금액으로 체결되었습니다.");

                            //매수 되었으니 코인의 갯수 증가
                            coin[notConcluded[i].WhatCoin].CoinCount = coin[notConcluded[i].WhatCoin].CoinCount + (int)notConcluded[i].HowManyLock;

                            //매수 되었으니 예수금 감소
                            player.PlayerMoney = player.PlayerMoney - (temp0[i] * (int)notConcluded[i].HowManyLock);

                            //코인의 좌표값을 입력 받고
                            int temp = notConcluded[i].MuchManyWhere;
                            // 그 입력 받은 좌표값으로 삭제
                            RemoveByName(buyCoinNotConcludeds, temp);

                        }
                    }
                }
                //매도 일 경우
                else if (notConcluded[i].BuyORSell == true)
                {
                    //걸어둔 가격이 현재 시가보다 낮을 경우
                    if (coin[notConcluded[i].WhatCoin].CoinPrice >= notConcluded[i].HowMuchLock)
                    {
                        //-5~5%의 변동성 사이에서 체결
                        int closingChange = random.Next(-5, 5);
                        temp0[i] = coin[notConcluded[i].WhatCoin].CoinPrice + (coin[notConcluded[i].WhatCoin].CoinPrice * closingChange * 0.01f);


                        //변동된 매도의 가격의 전체 코인이 예수금보다 이하일 때 체결
                        if (player.PlayerMoney >= (temp0[i] * notConcluded[i].HowManyLock))
                        {
                            notConcluded[i].HowMuchLock = temp0[i];

                            Console.WriteLine($"{coin[notConcluded[i].WhatCoin].Name}이 ${temp0[i]}의 금액으로 체결되었습니다.");

                            //매도 되었으니 코인의 갯수 감소
                            coin[notConcluded[i].WhatCoin].CoinCount = coin[notConcluded[i].WhatCoin].CoinCount - (int)notConcluded[i].HowManyLock;

                            //매도 되었으니 예수금 증가
                            player.PlayerMoney = player.PlayerMoney + (temp0[i] * (int)notConcluded[i].HowManyLock);

                            //코인의 좌표값을 입력 받고
                            int temp = notConcluded[i].MuchManyWhere;
                            // 그 입력 받은 좌표값으로 삭제
                            RemoveByName(buyCoinNotConcludeds, temp);

                        }
                    }
                }
            }
        
        }
        #endregion

        #region 걸어뒀던 코인 리스트에서 삭제
        public void RemoveByName(LinkedList<BuyCoinNotConcluded> buyCoinNotConcludeds, int temp)
        {
            // 첫 번째 노드부터 시작
            LinkedListNode<BuyCoinNotConcluded> current = buyCoinNotConcludeds.First;

            while (current != null)
            {
                if (current.Value.MuchManyWhere == temp)
                {
                    buyCoinNotConcludeds.Remove(current); // 해당 노드 삭제
                    break; // 삭제 후 종료
                }
                current = current.Next; // 다음 노드로 이동
            }
        }
        #endregion

        #region 코인 상승 혹은 하락 시
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

        #region 미체결 코인 지정 삭제
        public void Delete(LinkedList<BuyCoinNotConcluded> buyCoinNotConcludeds)
        {
            bool asd = false;
            int temp;

            var asdd = Console.ReadLine();

            while (asd == false)
            {
                //지우고자 하는 코인의 값을 입력 받고
                asd = int.TryParse(Console.ReadLine(), out temp);
                
                if (asd == true)
                {
                    // 그 입력 받은 좌표값으로 삭제
                    RemoveByName(buyCoinNotConcludeds, temp);
                }
            }
        }
        #endregion


        //키 입력 받음 1~4번 선택해야함.
        public void GetKeyInputOneToFour
        (ref bool changeUI0, ref bool changeUI1, ref bool changeUI2, ref bool changeUI3)
        {
            bool playerKeydown = false;
            int playerInput = 1;

            while (playerKeydown == false &&  1 <= playerInput && playerInput <= 4)
            {
                //▼ 1~4번 중 무슨 선택할거냐?(매수, 매도, 뉴스, 돈벌기)
                playerKeydown = int.TryParse(Console.ReadLine(), out playerInput);

                //0~4의 선택지만을 선택 했을 경우
                if ( 1 <= playerInput && playerInput <= 4)
                {
                    switch (playerInput)
                    {
                        //매수 선택 시
                        case 1:
                            changeUI0 = false;
                            changeUI1 = false;
                            changeUI2 = false;
                            changeUI3 = true;
                            break;

                        //매도 선택 시
                        case 2:
                            changeUI0 = false;
                            changeUI1 = false;
                            changeUI2 = true;
                            changeUI3 = false;
                            break;

                        //미체결 창 선택 시
                        case 3:
                            changeUI0 = false;
                            changeUI1 = true;
                            changeUI2 = false;
                            changeUI3 = false;
                            break;

                        //캔들 차트표 보기
                        case 4:
                            changeUI0 = true;
                            changeUI1 = true;
                            changeUI2 = true;
                            changeUI3 = true;
                            break;

                        default:
                            Console.WriteLine("1~4번안의 선택지만 선택하시오.");
                            break;
                    }
                    break;
                }
            }
        }

        //소수점 4자리 까지만 살림
        public float Trunf(float value)
        {
            return (float)(Math.Truncate(value * 10000) / 10000);
        }
    }
}
