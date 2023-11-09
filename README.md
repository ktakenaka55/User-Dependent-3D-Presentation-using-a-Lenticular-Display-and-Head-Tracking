# 裸眼立体視ディスプレイとヘッドトラッキングを用いた自由視点立体映像の個別提示による共同作業システム

<img src="./teaser.png" width="500％">

## 概要
複数人によるユーザ依存の視点での同時裸眼立体視<br>
・各ユーザの視点を認識することで、二人のユーザが３Dシーンを独立して視認可能<br>
・ユーザごとに異なる立体映像を単一ディスプレイに表示<br>
・ヘッドトラッキングを利用した３D視点移動のインターフェース<br>


## デバイス
・裸眼立体ディスプレイ：Looking Glass Portrait

・Webカメラ：elecom UCAM-C820ABBK

<img src="./setup.png" width="400％">


## ソフトウェア
・Unity（version:2021.3.12）

・Looking Glass Unity Plugin

・顔認識：OpenFace（https://github.com/TadasBaltrusaitis/OpenFace）



## 実行方法
1. OpenFace_2.2.0_win_x64を任意の場所にダウンロード（Unityプロジェクト外で良い）

2. Assets/Holoplay/Script/LookigGlass/HoloplayScripts/OpenFace/OpenFaceReader.cs でOpenFaceの出力データ(.csv)のパス設定

3. cmdで「.\FaceLandmarkVidMulti.exe -device 0 -of realtime」を実行

4. Unity実行

※詳細<br>
・オブジェクト'DataReader'のスクリプト'DataRead'のformat_tracking, format_splitにより<br>
　トラッキングによる多方向立体視、画面分割のオン・オフ選択可能<br>
・シーン内の表示オブジェクトを変更することで好きなモデルを多視点立体視できる<br>



## 出力
#### 表示シーン
<img src="./model.png" width="400％">
一つの３Dモデルを複数人で多方向から立体視する<br>
A~Dが書かれたCubeは視点方向を表す<br>


#### ディスプレイ表示
<img src="./output.png" width="400％">
user1は方向DAから、user2はBCから同時に立体視可能<br>
各ユーザは独立して自由立体視できる<br>
