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
            //커서 안보이게 하기
            Console.CursorVisible = false;
            //특수 이모티콘 출력 가능하게 하는거
            Console.OutputEncoding = Encoding.UTF8;
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
            //미체결 코인 클래스 선언
            LinkedList<BuyCoinNotConcluded> buyCoinNotConcludeds = new LinkedList<BuyCoinNotConcluded>();

            //캔들차트의 스틱 관리
            LinkedList<float[]> candlestick = new LinkedList<float[]>();

            //코인 게임 타이틀
            uIManager.Title();
            
            //코인 게임 시작 화면
            uIManager.GameStart();

            coinList.AddFirst(new Coin("비트코인", 100));
            coinList.AddLast(new Coin("이더리움", 100));
            coinList.AddLast(new Coin("리플코인", 100));
            coinList.AddLast(new Coin("경일코인", 100));
            coinList.AddLast(new Coin("도지코인", 100));
            coinList.AddLast(new Coin("계엄코인", 100));

            Coin[] coin = coinList.ToArray();

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
            bool changeUI0 = false;
            bool changeUI1 = false;
            bool changeUI2 = false;
            bool changeUI3 = false;


            //코인의 위치 파악을 위한 것
            int whereIsTheCoin = 0;
            #endregion


            //캔들 차트용 변수들
            //각 캔들의 코드이름
            int temp = 0;
            //캔들안에 들어갈 코인의 시세가들 갯수
            int _candleCount = 0;
            bool isCreate = false;

            //캔들차트 클래스 링크드 리스트 선언
            List<LinkedList<CandleChart>> candleCharts = new List<LinkedList<CandleChart>>();

            //캔들 차트의 껍데기 창조
            List<CandleChart> eachCandles = new List<CandleChart>();

            // 캔들 차트 저장소와 껍데기 초기화
            for (int i = 0; i < coin.Length; i++)
            {
                candleCharts.Add(new LinkedList<CandleChart>());
                eachCandles.Add(null);
            }

            //캔들 차트에 필요한 List들
            List<List<float>> mostHL = null;
            List<float> oneSpaces = null;
            List<List<float>> CVolatilityValues = null;
            List<List<float>> highValues = null;
            List<List<float>> changeColor = null;
            List<int[]> howSpaces = null;


            int showCoin = 0; 


            //게임 시작 반복문
            while (true)
            {
                //stopwatch.ElapsedMilliseconds 실제 시간 흐르는 것 1000 = 1초
                int second = (int)stopwatch.ElapsedMilliseconds / 1000;     //1초의 흐름 시간 선언
                int second1 = (int)stopwatch.ElapsedMilliseconds / 500;     //0.5초의 흐름 시간 선언
                //수정↕
                // 0.5초가 흐를 때 마다 (상호작용 + 차트 출력)
                if (second1 - lastExecutionTime2 >= 1)
                {
                    //실시간 차트, 예수금, 코인총액, 날짜 변경 출력창
                    uIManager.InGameViewAllTime
                        (ref changeUI0, ref changeUI1, ref changeUI2, ref changeUI3, temp,
                        theTime, dayby, market, coinList, player, coin, _candleCount, buyCoinNotConcludeds, stopwatch, gameManager
                        , ref showCoin, mostHL, oneSpaces, CVolatilityValues,
                            highValues, howSpaces, changeColor);

                    // 키입력을 받을 시 {1~4번 선택 할 시 !!!! (매수 매도 등등)}
                    if (Console.KeyAvailable)
                    {
                        //시간 잠시 멈춰
                        stopwatch.Stop();

                        // 1~4번 1번.매수, 2번.매도, 3번.미체결, 4번.캔들차트
                        if (changeUI0 == false && changeUI1 == false && changeUI2 == false && changeUI3 == false)
                        {
                            gameManager.GetKeyInputOneToFour(ref changeUI0, ref changeUI1, ref changeUI2, ref changeUI3);
                        }
                        //매수 캔들 창
                        else if (changeUI0 == false && changeUI1 == false && changeUI2 == false && changeUI3 == true)
                        {
                            gameManager.Buy
                               (ref coin, ref changeUI0, ref changeUI1, ref changeUI2, ref changeUI3
                               , buyCoinNotConcludeds, ref whereIsTheCoin);
                        }
                        //매도 캔들 창
                        else if (changeUI0 == false && changeUI1 == false && changeUI2 == true && changeUI3 == false)
                        {
                            gameManager.Sell
                                (ref coin, ref changeUI0, ref changeUI1, ref changeUI2, buyCoinNotConcludeds, ref whereIsTheCoin);
                        }
                        //캔들차트표
                        else if (changeUI0 == true && changeUI1 == true && changeUI2 == true && changeUI3 == true)
                        {
                            gameManager.SelectCoin(ref showCoin, coin, ref changeUI0, ref changeUI1, ref changeUI2, ref changeUI3);
                        }
                        else if (changeUI0 == true && changeUI1 == true && changeUI2 == true && changeUI3 == false)
                        {
                            gameManager.SelectCoin(ref showCoin, coin, ref changeUI0, ref changeUI1, ref changeUI2, ref changeUI3);
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

                    #region 캔들차트용
                    //캔들안에 3개의 코인 가격이 들어갈 것임.(0, 1, 2)
                    if (_candleCount < 3)
                    {
                        //캔들 저장소에 한개 추가
                        if (isCreate == true)
                        {
                            for (int i = 0; i < coin.Length; i++)
                            {
                                eachCandles[i].BeforeCoinPrice.Add(coin[i].CoinPrice);
                            }
                        }
                        //캔들 스틱 한개를 창조 + 저장소에 한개 추가
                        else if (isCreate == false)
                        {
                            for (int i = 0; i < coin.Length; i++)
                            {
                                // 캔들 차트 한 개 빈공간 창조
                                eachCandles[i] = new CandleChart(temp);

                                // 캔들 차트 안에 코인 가격 저장소에 한 개 추가
                                eachCandles[i].BeforeCoinPrice.Add(coin[i].CoinPrice);

                                // 링크드리스트 캔들 차트에 캔들 차트 한 개를 추가
                                candleCharts[i].AddLast(eachCandles[i]);
                            }
                            isCreate = true;
                        }
                        _candleCount++;
                    }

                    //캔들안에 3개 초과로 들어갈 경우
                    if (3 <= _candleCount)
                    {
                        // 모든 캔들 차트 안의 값을 담을 리스트
                        mostHL = new List<List<float>>();
                        for (int i = 0; i < coin.Length; i++)
                        {
                            mostHL.Add(new List<float>());
                        }
                        // 각 캔들 차트 안의 가장 높은 값, 낮은 값 찾기위해 모든 값 넣기
                        for (int i = 0; i < coin.Length; i++)
                        {
                            foreach (var candle in candleCharts[i])
                            {
                                for (int j = 0; j < candle.BeforeCoinPrice.Count; j++)
                                {
                                    mostHL[i].Add(candle.BeforeCoinPrice[j]);
                                }
                            }
                        }
                        // 모든 값들을 정렬
                        foreach (var hl in mostHL)
                        {
                            hl.Sort();
                        }

                        // 정렬된 값들 중 가장 높은 값과 가장 낮은 값의 차 계산
                        List<float> CVerticals = new List<float>();
                        for (int i = 0; i < coin.Length; i++)
                        {
                            if (mostHL[i].Count > 0)
                            {
                                float highest = mostHL[i][mostHL[i].Count - 1];
                                float lowest = mostHL[i][0];
                                CVerticals.Add(highest - lowest);
                            }
                            else
                            {
                                CVerticals.Add(0); // 데이터가 없으면 0으로 설정
                            }
                        }

                        // 1칸당 차지하는 값(20등분)
                        oneSpaces = new List<float>();
                        foreach (var vertical in CVerticals)
                        {
                            oneSpaces.Add(Math.Max((vertical / 20), 0.001f));
                        }

                        // 모든 캔들의 세로 값, 가장 낮은 값, 가장 높은 값, 색변환을 위한 값 저장소
                        CVolatilityValues = new List<List<float>>();
                        List<List<float>> lowValues = new List<List<float>>();
                        highValues = new List<List<float>>();
                        changeColor = new List<List<float>>();
                        for (int i = 0; i < coin.Length; i++)
                        {
                            CVolatilityValues.Add(new List<float>());
                            lowValues.Add(new List<float>());
                            highValues.Add(new List<float>());
                            changeColor.Add(new List<float>());
                        }

                        // 각 캔들 차트의 세부 데이터를 계산
                        for (int i = 0; i < coin.Length; i++)
                        {
                            foreach (var candle in candleCharts[i])
                            {
                                // 최저값, 최고값 계산 및 저장
                                float low = candle.BeforeCoinPrice.Min();
                                float high = candle.BeforeCoinPrice.Max();
                                float changColor = candle.BeforeCoinPrice[0] - candle.BeforeCoinPrice[2];
                                lowValues[i].Add(low);
                                highValues[i].Add(high);
                                changeColor[i].Add(changColor);

                                // 세로 값 계산
                                CVolatilityValues[i].Add((high - low) / oneSpaces[i]);
                            }
                        }

                        // 각 캔들 차트에서 몇 칸을 차지하는지 계산
                        List<LinkedList<int>> howMSpace = new List<LinkedList<int>>();
                        for (int i = 0; i < coin.Length; i++)
                        {
                            howMSpace.Add(new LinkedList<int>());
                        }
                        for (int i = 0; i < coin.Length; i++)
                        {
                            for (int j = 0; j < CVolatilityValues[i].Count; j++)
                            {
                                int space = (int)Math.Ceiling(CVolatilityValues[i][j] / oneSpaces[i]);
                                howMSpace[i].AddLast(space > 20 ? 20 : space);
                            }
                        }

                        //몇 칸 차지하는지 배열로 전환 후 활용
                        howSpaces = new List<int[]>();
                        for (int i = 0; i < coin.Length; i++)
                        {
                            howSpaces.Add(howMSpace[i].ToArray());
                        }

                        //각 캔들의 코드 넘버 올리기
                        temp++;

                        //캔들 초기화
                        _candleCount = 0;
                        isCreate = false;
                    }
                    #endregion

                    //플레이어가 보유한 모든 코인 총액
                    player.ChangePlayerCoinAllMoney(player, coin);

                    //▼ 마지막 실행 시간을 현재 시간으로 갱신
                    lastExecutionTime0 = second;
                }
            }
        }
    }
}
