<!-- ===== HEADER ===== -->
<h1 align="center">🎮 ConsoleCoinGame 🎮</h1>
<p align="center">
  C# 콘솔 기반 <b>코인 투자 시뮬레이션 게임</b><br/>
  핵심: <b>랜덤 시세 변동</b> + <b>매수/매도</b> + <b>캔들 차트(콘솔 출력)</b>
</p>

<br>

<!-- 링크 버튼 영역 -->
<p align="center">
  <a href="https://youtu.be/a1n5UPEqbnk?si=7QspFyTrZEy6T7L_">
    <img src="https://img.shields.io/badge/플레이%20영상-YouTube-red?logo=youtube&logoColor=white" />
  </a>
  <a href="https://docs.google.com/presentation/d/19hPFhwoPjEY5GN1IjEhPG5Ru-oz1BndH/edit?usp=sharing&ouid=116550297560584203631&rtpof=true&sd=true">
    <img src="https://img.shields.io/badge/발표용%20PPT-Google%20Slides-orange?logo=googleslides&logoColor=white" />
  </a>
  <a href="https://www.canva.com/design/DAGusJR6Rj8/oqtCCGhOprGTfJjlf6Ingw/edit?ui=eyJEIjp7IlQiOnsiQSI6IlBCY0o0UkRDbE5reGcxNUQifX19">
    <img src="https://img.shields.io/badge/핵심%20기술%20Canva-Portfolio-blue" />
  </a>
</p>

<br>

<!-- ===== SCREENSHOTS (3 images) ===== -->
<table align="center">
  <tr>
    <td width="33%">
      <img src="https://github.com/user-attachments/assets/6aa0bad0-d601-4c79-b5a6-cf59d390d3e7" alt="ConsoleCoinGame 1" width="100%"/>
    </td>
    <td width="33%">
      <img src="https://github.com/user-attachments/assets/047dde9d-4966-4862-a8e0-57511194492c" alt="ConsoleCoinGame 2" width="100%"/>
    </td>
    <td width="33%">
      <img src="https://github.com/user-attachments/assets/84c9c631-0ad4-45e7-8616-3d5a1dc3f95f" alt="ConsoleCoinGame 3" width="100%"/>
    </td>
  </tr>
</table>

<br>

## 📌 프로젝트 정보
- 개발 인원: **1명**
- 제작 기간:
  - **1차:** 2024.12.03 ~ 2024.12.05
  - **2차:** 2024.12.23 ~ 2024.12.28
- 장르: **콘솔 시뮬레이션 / 코인 투자 게임**
- 개발 환경: **Visual Studio + C#**
- 실행 환경: **Windows 콘솔(터미널)**
- 본 README는 포트폴리오 용도로 **핵심 기능 + 구현 시스템(클래스 구조)** 중심으로 정리했습니다.

<br>

---

<br>

## 📚 목차
- [🎯 게임 소개](#game-intro)
- [🧠 핵심 기술](#key-tech)
  - [1) 랜덤 시세 변동 시스템](#price-system)
  - [2) 매수/매도 입력 처리](#trade-system)
  - [3) 예수금 벌기(리커버리 루트)](#deposit-system)
  - [4) 캔들 차트(콘솔 출력)](#candle-system)
- [✅ 구현 시스템 (클래스 구조)](#what-i-built)
- [🔁 게임 흐름](#game-flow)
- [🛠️ 기술 스택](#tech-stack)
- [👨‍💻 개발자 소개](#developer)

<br>

---

<br>

<a name="game-intro"></a>
## 🎯 게임 소개
ConsoleCoinGame은 C# 콘솔 환경에서 동작하는 **가상 코인 투자 시뮬레이션 게임**입니다.  
시간 경과에 따라 코인 가격이 변동하고, 플레이어는 입력을 통해 **매수/매도**를 수행하며 **자산을 증가**시키는 것을 목표로 합니다.

- 콘솔 UI 기반으로 상태(보유 금액/코인 수량/코인 총액)를 지속적으로 갱신
- 가격 변동과 거래 결과가 즉시 반영되어 “현재가 기반 판단”이 핵심 루프가 되도록 구성

<br>

---

<br>

<a name="key-tech"></a>
## 🧠 핵심 기술

<a name="price-system"></a>
### 1) 랜덤 시세 변동 시스템
- 일정 시간 간격으로 각 코인의 가격을 랜덤하게 상승/하락시키는 구조
- 변동 결과를 UI에 반영하여 시세 흐름을 즉시 확인 가능

<br>

<a name="trade-system"></a>
### 2) 매수/매도 입력 처리
- 숫자 입력(메뉴 선택) 기반으로 매수/매도 기능 진입
- 코인 선택 → 수량/금액 입력 → 결과 반영(보유 수량/예수금/총액 갱신) 흐름을 콘솔 UI로 분리

<br>

<a name="deposit-system"></a>
### 3) 예수금 벌기(리커버리 루트)
- 손실이 커졌을 때 “예수금 확보” 기능으로 플레이 지속이 가능하도록 구성
- 콘솔 게임 특성상 밸런스 요소로서 회복 루트 제공

<br>

<a name="candle-system"></a>
### 4) 캔들 차트(콘솔 출력)
- 코인 선택 시 가격 흐름을 **캔들 차트 형태(ASCII 기반)**로 출력
- 숫자만 나열되지 않게 “시각적 흐름”을 제공해 판단 포인트를 강화

<br>

---

<br>

<a name="what-i-built"></a>
## ✅ 구현 시스템 (클래스 구조)
- `Program.cs`
  - 게임 시작/초기화, 메인 루프, 메뉴 입력 진입점
- `GameManager.cs`
  - 게임 진행 관리(입력 흐름 분기, 매수/매도 처리, 상태 갱신 트리거)
- `UIManager.cs`
  - 시작 화면/메뉴/상태 출력, 캔들 차트 출력 UI 처리
- `Market.cs`
  - 코인 가격 변동(랜덤 변동), 가격 갱신 규칙 처리
- `Coin.cs`
  - 코인 데이터(이름/가격/수량 등) 보관 및 연산 보조
- `Player.cs`
  - 플레이어 자산(예수금/보유 코인/총액) 관리 및 갱신
- `CandleChart.cs`
  - 가격 히스토리 기반 캔들 차트 출력용 데이터/로직
- `BuyCoinNotConcluded.cs`
  - 거래/주문 상태를 위한 데이터 모델(README에서는 “미체결/거래 상태”로만 언급)

<br>

---

<br>

<a name="game-flow"></a>
## 🔁 게임 흐름
1. **게임 시작 화면 출력**
2. **사용자 입력 처리**
   - 숫자 입력으로 기능 선택(매수/매도/예수금 벌기 등)
3. **코인 가격 변동**
   - 일정 시간마다 랜덤 변동 및 UI 반영
4. **매수/매도 실행**
   - 거래 결과 반영 후 상태 출력 갱신
5. **상태 출력**
   - 보유 금액/코인 수량/코인 총액 등 갱신

<br>

---

<br>

<a name="tech-stack"></a>
## 🛠️ 기술 스택
- 개발 언어: **C#**
- 개발 툴: **Visual Studio**
- 프로젝트 형태: **.NET 콘솔 애플리케이션(콘솔 앱)**
- 실행 환경: **Windows 콘솔(터미널)**
- 사용 요소(일반): **콘솔 입출력(Console), 컬렉션(List 등), 랜덤(Random), 시간 흐름(루프 기반 갱신)**

<br>

---

<br>

<a name="developer"></a>
## 👨‍💻 개발자 소개
- GitHub: [https://github.com/RedRaccoon177]
- Tistory: [https://wearelast99.tistory.com/]
- YouTube: [유튜브 채널](https://www.youtube.com/@%EC%9D%B4%EC%9C%A0-z9c)
- Canva 포트폴리오: [포트폴리오](https://www.canva.com/design/DAGusJR6Rj8/BOtICI6F1raShPyHHewjxg/view?utm_content=DAGusJR6Rj8&utm_campaign=designshare&utm_medium=link2&utm_source=uniquelinks&utlId=h691958bd9a)
- Canva 이력서: [이력서](https://www.canva.com/design/DAGj7YKBoc8/YPk_CLe8B1taKTE-nneUJA/view?utm_content=DAGj7YKBoc8&utm_campaign=designshare&utm_medium=link2&utm_source=uniquelinks&utlId=ha914d97458)
