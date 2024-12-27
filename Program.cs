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

        static void Main(string[] args)
        {
            //차트 상승 혹은 하락장의 확률 선언
            Random randomD = new Random();
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
            //GetInputNum 클래스 선언
            GetInputNum getInputNum = new GetInputNum();
            //미체결 코인 클래스 선언
            LinkedList<BuyCoinNotConcluded> buyCoinNotConcludeds = new LinkedList<BuyCoinNotConcluded>();

            //캔들차트 클래스 링크드 리스트 선언
            LinkedList<CandleChart> candleChart = new LinkedList<CandleChart>();

            //코인 게임 타이틀
            //uIManager.Title();
            //코인 게임 시작 화면
            //uIManager.GameStart();

            coinList.AddFirst(new Coin("비트코인",100));
            coinList.AddLast(new Coin("이더리움", 100));
            coinList.AddLast(new Coin("리플코인", 100));
            coinList.AddLast(new Coin("경일코인", 100));
            coinList.AddLast(new Coin("도지코인", 100));
            coinList.AddLast(new Coin("계엄코인", 100));

            Coin[] coin = coinList.ToArray();
            

            //게임 시작 시 차트 출력 처음 값
            //uIManager.GameStartChart(player, coinList);

            // 게임 시작 시 예수금 출력 값
            //uIManager.PlayerMoney(player.PlayerMoney, player.PlayerCoinAllMoney);

            #region 게임이 계속 진행 되도록 하는 while문!
            //시간 선언
            Stopwatch stopwatch = new Stopwatch();
            //시간 흐름 시작
            stopwatch.Start();

            // 마지막 실행 시간을 저장할 변수
            int lastExecutionTime0 = 0;                   
            int lastExecutionTime1 = 0;
            int lastExecutionTime2 = 0;

            int theTime = 0;
            int dayby = 0;

            //ui창에 관한 임시변수들
            bool changeUI0 = true;
            bool changeUI1 = true;
            bool changeUI2 = false;

            //코인의 위치 파악을 위한 것
            int whereIsTheCoin = 0;

            
            
            //캔들 차트용 변수들
            //각 캔들의 코드이름
            int temp = 0;
            //캔들안에 들어갈 코인의 시세가들 갯수
            int _candleCount = 0;
            bool isCreate =false;

            //캔들 차트의 껍데기 창조
            CandleChart cloneCandleChart = null;



            //게임 시작 반복문
            while (true)
            {
                //stopwatch.ElapsedMilliseconds 실제 시간 흐르는 것 1000 = 1초
                int second = (int)stopwatch.ElapsedMilliseconds / 1000;     //1초의 흐름 시간 선언
                int second1 = (int)stopwatch.ElapsedMilliseconds /1000;     //0.5초의 흐름 시간 선언

                // 0.5초가 흐를 때 마다 (상호작용 + 차트 출력)
                if (second1 - lastExecutionTime2 >= 2)
                {
                    #region 캔들차트용 : 4초마다 한번만 푸쉬를 함.
                    ////캔들안에 3개의 코인 가격이 들어갈 것임.(0, 1, 2, 3)
                    //if (_candleCount < 4)
                    //{
                    //    if (isCreate == true)
                    //    {
                    //        cloneCandleChart.BeforeCoinPrice.Add(coin[0].CoinPrice);
                    //    }
                    //    else if (isCreate == false)
                    //    {
                    //        //캔들 차트 한개 빈공간 창조
                    //        cloneCandleChart = new CandleChart(temp); 
                            
                    //        //캔들 차트 안에 코인 가격 저장소에 한개 추가
                    //        cloneCandleChart.BeforeCoinPrice.Add(coin[0].CoinPrice);

                    //        //링크드리스트 캔들 차트에 캔들 차트 한개를 추가한다.
                    //        candleChart.AddLast(cloneCandleChart);

                    //        isCreate = true;
                    //    }
                    //    _candleCount++;
                    //}

                    ////링크드 리스트의 갯수가 10개가 넘어가면
                    //if (10 <= temp)
                    //{
                    //    //가장 첫번째꺼를 삭제해라
                    //    //candleChart.Remove();
                    //}
                    #endregion

                    //실시간 차트, 예수금, 코인총액, 날짜 변경 출력창
                    uIManager.InGameViewAllTime
                        (ref changeUI0, ref changeUI1, ref changeUI2, temp,
                        theTime, dayby, market, coinList, player, coin, _candleCount, buyCoinNotConcludeds, stopwatch, gameManager, candleChart);

                    // 키입력을 받을 시 {1~4번 선택 할 시 !!!! (매수 매도 등등)}
                    if (Console.KeyAvailable)
                    {
                        //시간 잠시 멈춰
                        stopwatch.Stop();

                        // 1~4번 1번.매수, 2번.매도, 3번.뉴스, 4번.돈벌기
                        if (changeUI0 == false && changeUI1 == false && changeUI2 == false)
                        {
                            // 1~4번 1번.매수, 2번.매도, 3번.미체결창, 4번.체결창
                            gameManager.GetKeyInputOneToFour(ref changeUI0, ref changeUI1, ref changeUI2);
                        }
                        //매수 혹은 매도 걸어두기
                        else if (changeUI0 == false)
                        {
                            //매수
                            if (changeUI1 == false && changeUI2 == true)
                            {
                                gameManager.Buy
                                    (ref coin, ref changeUI0, ref changeUI1, ref changeUI2, buyCoinNotConcludeds, ref whereIsTheCoin);
                            }
                            //매도
                            else if (changeUI1 == true && changeUI2 == true)
                            {
                                gameManager.Sell
                                    (ref coin, ref changeUI0, ref changeUI1, ref changeUI2, buyCoinNotConcludeds, ref whereIsTheCoin);
                            }
                        }
                        //시간 다시 작동
                        stopwatch.Start();
                    }

                    //플레이어가 보유한 모든 코인 총액
                    player.ChangePlayerCoinAllMoney(player, coin);

                    //걸어뒀던 코인 체결
                    gameManager.BuyORSellACoin(ref coin, ref player, buyCoinNotConcludeds);

                    //마지막 실행 시간을 현재 시간으로 갱신
                    lastExecutionTime2 = second1;
                }

                // 1초가 흐를 때 마다 (여기서는 날짜만 관리)
                if (second - lastExecutionTime1 >= 1)
                {
                    //10초 경과 시 1일 지남.
                    theTime = +second;
                    
                    dayby++;
                    if (10 < dayby)
                    {
                        dayby = 0;
                    }
                    //마지막 실행 시간을 현재 시간으로 갱신
                    lastExecutionTime1 = second;

                }

                // 3초가 흐를 때 마다 (차트의 시세 변경 값)
                if (second - lastExecutionTime0 >= 2)
                {
                    // 모든 코인의 시세 변경
                    for (int i = 0; i < coinList.Count; i++)
                    {
                        coin[i].ChangePrice = 100;
                        market.ChangeCoinPrice(ref coin);

                        // 소수점 둘째 자리까지만 남기는 작업
                        coin[i].TrunChangPrice = (coin[i].ChangePrice * 10) / 10;

                        // 상승 혹은 하락 장 확률 함수
                        bool isCorrect = market.MinusOrPlus(randomD);

                        //코인 상승 혹은 하락 시
                        gameManager.CoinUPORDown(isCorrect, coin, i);

                        //상승 혹은 하락을 모든 코인마다 지정
                        coin[i]._isCorrect = isCorrect;
                    }


                    #region 캔들차트용 : 4초마다 한번만 푸쉬를 함.
                    //캔들안에 3개의 코인 가격이 들어갈 것임.(0, 1, 2)
                    if (_candleCount < 3)
                    {
                        //캔들 저장소에 한개 추가
                        if (isCreate == true)
                        {
                            //(수정)
                            cloneCandleChart.BeforeCoinPrice.Add(coin[0].CoinPrice);
                        }
                        //캔들 스틱 한개를 창조 + 저장소에 한개 추가
                        else if (isCreate == false)
                        {
                            //캔들 차트 한개 빈공간 창조
                            cloneCandleChart = new CandleChart(temp);

                            //캔들 차트 안에 코인 가격 저장소에 한개 추가 (수정)
                            cloneCandleChart.BeforeCoinPrice.Add(coin[0].CoinPrice);

                            //링크드리스트 캔들 차트에 캔들 차트 한개를 추가한다.
                            candleChart.AddLast(cloneCandleChart);

                            isCreate = true;
                        }

                        _candleCount++;
                    }

                    //캔들안에 3개 초과로 들어갈 경우
                    if (3 <= _candleCount)
                    {
                        //캔들차트안의 가장 높은 값, 낮은 값 찾기

                        //모든 캔틀차트 안의 값을 가지고 있는 리스트
                        List<float> mostHL = new List<float>();
                        foreach (var candle in candleChart)
                        {
                            //캔들 하나안의 값 3개 다 확인용도
                            for (int i = 0; i < candle.BeforeCoinPrice.Count; i++)
                            {
                                mostHL.Add(candle.BeforeCoinPrice[i]);
                            }
                        }

                        //모든 값들이 리스트에 잘 들어갔는지 확인용
                        /*foreach (var a in mostHL)
                        {
                            Console.WriteLine(a);
                        }*/

                        //모든 값들을 정렬
                        mostHL.Sort();
                        //정렬 된 값들 중 가장 높은값 가장 낮은 값의 차
                        float allresult =mostHL[candleChart.Count * cloneCandleChart.BeforeCoinPrice.Count - 1] - mostHL[0];
                        //1칸당 차지 하는 값
                        float oneSpace = allresult / 20;

                        //Console.WriteLine($"가장 낮은 값{mostHL[0]}");
                        //Console.WriteLine($"가장 높은 값{mostHL[candleChart.Count * cloneCandleChart.BeforeCoinPrice.Count - 1]}");

                        float[] input = new float[3];
                        //캔들 하나안의 값 3개 다 확인용도
                        for (int i = 0; i < cloneCandleChart.BeforeCoinPrice.Count; i++)
                        {
                            input[i] = cloneCandleChart.BeforeCoinPrice[i];
                        }
                        Array.Sort(input);
                        float result = input[0] - input[2];
                        //한 캔들스틱 안에 변동 성 값
                        result = Math.Abs(result);

                        //List<CandleChart> some = new List<CandleChart>();
                        //foreach (var candle in candleChart)
                        //{
                        //    some.Add(candle);
                        //}

                        //Console.WriteLine(oneSpace);
                        //Console.WriteLine(result);


                        //한칸당 차지하는 캔들 스틱 출력 값
                        for (int i = 0; i < 20; i++)
                        {
                            if (oneSpace * i <= result && result <= oneSpace * (i + 1))
                            {
                                for (int j = 0; j <= i; j++)
                                {
                                    Console.WriteLine($"{i+1}");
                                }
                            }
                        }

                        //1일째는 한개만
                        //2일째는 2줄
                        //3일째는 3줄....

                        //string[,]coordinate = new string[80,20];
                        //coordinate[0, 9] = "ㅁ";




                        #region 색깔 바꾸는 거임
                        //가장 첫번째랑 마지막을 빼서 양수면 양봉
                        if (0 < cloneCandleChart.BeforeCoinPrice[0] - cloneCandleChart.BeforeCoinPrice[cloneCandleChart.BeforeCoinPrice.Count-1])
                        {
                            //Console.WriteLine("빨강");
                            //캔들 색을 빨강으로
                        }
                        //음수면 음봉
                        else if (cloneCandleChart.BeforeCoinPrice[0] - cloneCandleChart.BeforeCoinPrice[cloneCandleChart.BeforeCoinPrice.Count-1] < 0)
                        {
                            //Console.WriteLine("파랑");
                            //캔들 색을 파랑색으로
                        }
                        else 
                        {
                            //두개의 음이 0이면 말이 안되는데...
                        }
                        #endregion



                        //각 캔들의 코드 넘버 올리기
                        temp++;

                        //캔들 초기화
                        _candleCount = 0;

                        isCreate = false;
                    }

                    //링크드 리스트의 갯수가 10개가 넘어가면
                    if (10 <= temp)
                    {
                        //가장 첫번째꺼를 삭제해라
                        //candleChart.Remove();
                    }
                    #endregion


                    //플레이어가 보유한 모든 코인 총액
                    player.ChangePlayerCoinAllMoney(player, coin);

                    //▼ 마지막 실행 시간을 현재 시간으로 갱신
                    lastExecutionTime0 = second;
                }
            }
            #endregion
        }


    }
}
