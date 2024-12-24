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
            int lastExecutionTime1 = 0;

            int theTime = 0;
            int dayby = 1;

            //게임 시작 반복문
            while (true)
            {
                //stopwatch.ElapsedMilliseconds 실제 시간 흐르는 것 1000 = 1초
                int second = (int)stopwatch.ElapsedMilliseconds / 1000;     //1초의 흐름 시간 선언

                if (second - lastExecutionTime1 >= 1)
                {
                    //실시간 차트, 예수금, 코인총액, 날짜 변경 출력창
                    uIManager.InGameViewAllTime(theTime, second, dayby, market, coinList, player);

                    //3초 경과 시 1일 지남.
                    dayby++;
                    if (dayby > 3)
                    {
                        dayby = 1;
                    }
                    
                    // 키입력을 받을 시 {1~4번 선택 할 시 !!!! (매수 매도 등등)}
                    if (Console.KeyAvailable)
                    {
                        //시간 잠시 멈춰
                        stopwatch.Stop();

                        // 1~4번 1번.매수, 2번.매도, 3번.뉴스, 4번.돈벌기
                        gameManager.GetKeyInput(coinList, coinArray, player ,gameManager);

                        //시간 다시 작동
                        stopwatch.Start();   
                    }

                    //플레이어가 보유한 모든 코인 총액
                    player.ChangePlayerCoinAllMoney(player, coinArray);

                    //마지막 실행 시간을 현재 시간으로 갱신
                    lastExecutionTime1 = second;
                }

                // 3초가 흐를 때 마다 차트 변경
                if (second - lastExecutionTime0 >= 3)
                {
                    for (int i = 0; i < coinList.Count; i++)
                    {
                        coinArray[i].ChangePrice = 100;
                        market.ChangeCoinPrice(ref coinArray);
                        
                        // 소수점 둘째 자리까지만 남기는 작업
                        coinArray[i].TrunChangPrice = (coinArray[i].ChangePrice * 10) / 10;

                        // 상승 혹은 하락 장 확률 함수
                        bool isCorrect = market.MinusOrPlus(randomD);

                        //코인 상승 혹은 하락 시
                        gameManager.CoinUPORDown(isCorrect, coinArray, i);

                        //상승 혹은 하락을 모든 코인마다 지정
                        coinArray[i]._isCorrect = isCorrect;
                    }

                    //플레이어가 보유한 모든 코인 총액
                    player.ChangePlayerCoinAllMoney(player, coinArray);

                    //▼ 마지막 실행 시간을 현재 시간으로 갱신
                    lastExecutionTime0 = second;
                }
            }
            #endregion
        }


    }
}
