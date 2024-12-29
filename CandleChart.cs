using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12_Project_GameDevleop
{
    class CandleChart
    {
        //코인 가격들 저장소
        private List<float> _beforeCoinPrice;
        //링크드리스트 카운트
        private int _likedlistCount;

        //코인 가격들 저장소
        public List<float> BeforeCoinPrice
        {
            get { return _beforeCoinPrice; }
            set { _beforeCoinPrice = value; }
        }
        //링크드리스트 카운트
        public int LikedlistCount
        {
            get { return _likedlistCount; }
            set { _likedlistCount = value; }
        }

        //캔들 차트 생성자
        public CandleChart(int temp)
        {
            BeforeCoinPrice = new List<float>();
            LikedlistCount = temp;
        }
    }
}
