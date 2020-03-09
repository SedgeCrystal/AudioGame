# TextRPG
Androidで動作する自作ゲーム4作目です。


# 遊ぶ場合
apkファイルをダウンロードし、Androidに入れてください

# ソースコードなどを見たい場合
unitypackageをダウンロードし、unityからインポートしてください。ただし、このunitypackageには効果音ラボからダウンロードしたmp3ファイルが含まれていません。そのため、効果音ラボから  
1.ショット（戦闘［２］）をダウンロードし、Player(GameSceneのGameObject)のAudioSourceのAudioClipに  
2.爆発2（戦闘［２］）をダウンロードし、ShotPrefab(Assetsフォルダ内のGameObject)のAudioSourceのAudioClipに  
3.竜の羽ばたき（戦闘［１］）をダウンロードし、EnemyGenerator(GameSceneのGameObject)のEnemyGenerator（Script）のEnemySoundClipsの要素の一つに  
4.スライムの攻撃（戦闘［１］）をダウンロードし、EnemyGenerator(GameSceneのGameObject)のEnemyGenerator（Script）のEnemySoundClipsの要素の一つに  
5.ジャンプの着地（戦闘［１］）をダウンロードし、EnemyGenerator(GameSceneのGameObject)のEnemyGenerator（Script）のEnemySoundClipsの要素の一つに  
6.高速移動（戦闘［１］）をダウンロードし、EnemyGenerator(GameSceneのGameObject)のEnemyGenerator（Script）のEnemySoundClipsの要素の一つに  
7.下駄で着地（生活［１］）をダウンロードし、EnemyGenerator(GameSceneのGameObject)のEnemyGenerator（Script）のEnemySoundClipsの要素の一つに  
8.決定、ボタン降下6（ボタン・システム音［１］）をダウンロードし、TitleDirector(TitleSceneのGameObject)のTitleDirector（Script）のAcTapのElement0に  
9.決定、ボタン降下28（ボタン・システム音［１］）をダウンロードし、TitleDirector(TitleSceneのGameObject)のTitleDirector（Script）のAcTapのElement1に  
設定していただくとunity上でゲームを動作させることができます。
もちろんお好きな音声素材を使っていただいても構いません。  
ただし、unity上ではジャイロを動かすことができないため、ゲームを正常に遊ぶことができません。そのためapkファイルへビルドしたのち、Androidで本ゲームを遊ぶことをお勧めいたします。


# 開発期間などが知りたい場合
summary.pdfをご覧ください。


