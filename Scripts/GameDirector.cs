using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    //ゲーム開始と敵生成のタイミングのための時間計測
    float time;
    float spawnSpan = 5;


    public bool isPause;

    //ゲームが始まったか
    //カウントダウンに使う
    bool isStart;

    Text cntDownText;

    //倒した敵の数。ResultSceneから呼び出せるようpublic
    public int score;


    EnemyGenerator enemyGenerator;
    GameObject player;

    public AudioClip[] audioClips;
    public AudioClip[] acTap;
    AudioSource asTap;
    AudioSource audioSource;
    
    int nextAC_i;
    // Start is called before the first frame update
    void Start()
    {
        this.time = -3;

        this.isPause = false;

        this.enemyGenerator = GameObject.Find("EnemyGenerator").GetComponent<EnemyGenerator>();
        this.player = GameObject.FindGameObjectWithTag("Player");
       
        this.isStart = false;

        this.cntDownText = GameObject.Find("CntDownText").GetComponent<Text>();
        this.cntDownText.text =(-this.time+0.5f).ToString("F0");

        //ジャイロを使えるようにする
        Input.gyro.enabled = true;

        
        this.audioSource = GetComponent<AudioSource>();
        this.asTap = GameObject.Find("AudioSource_Tap").GetComponent<AudioSource>();
        this.nextAC_i = 3;
        

        DontDestroyOnLoad(this);
       
    }



    // Update is called once per frame
    void Update()
    {
        

        
        this.time += Time.deltaTime;

        if (isStart)
        {
            if (this.time > 0)
            {
                this.time -= spawnSpan;
                this.enemyGenerator.GenerateEnemy();

                //少しずつenemyの移動速度を上げる
                enemyGenerator.enemySpeed *= 1.05f;
                //少しずつspawnSpanを短くする
                this.spawnSpan *= 0.95f;

            }
        }
        else
        {
            //audioClipsの中身が順にスタート,1,2,3 ポーズである。
            //これらを鳴らすタイミングはそれぞれtimeが0,-1,-2,-3のときである。
            if (!this.audioSource.isPlaying && time >= -this.nextAC_i)
            {
                this.audioSource.PlayOneShot(this.audioClips[this.nextAC_i]);
                this.nextAC_i--;
                this.cntDownText.text = (-this.time +0.5f).ToString("F0");
            }

            //nextAC_iが-1のとき、ゲームスタート
            if(nextAC_i <= -1)
            {
                this.isStart = true;
                this.cntDownText.text = "";
            }
        }


        //画面が上や下を向いた場合の処理
        //timeScaleを0にしてポーズさせる
        Quaternion gyro = Quaternion.AngleAxis(90, Vector3.right) * Input.gyro.attitude;
        Vector3 forward = new Quaternion(gyro.x, gyro.y, -gyro.z, -gyro.w) * Vector3.forward;

        if(forward.y >0.8 || forward.y < -0.8)
        {
            isPause = true;
            Time.timeScale = 0;
            if (!this.audioSource.isPlaying)
            {
                this.audioSource.PlayOneShot(this.audioClips[4]);
            }

            if (Input.GetMouseButtonUp(2))
            {
                this.asTap.PlayOneShot(this.acTap[0]);
                SceneManager.LoadScene("TitleScene");

            }
        }
        //ポーズ解除
        else
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                this.audioSource.Stop();
                isPause = false;
                this.audioSource.PlayOneShot(this.acTap[1]);
                
            }
            
        }

    }


    //Scene遷移をGameDirectorからのみ可能にするために作成
    //Player等から直接呼出した方が分かりやすい？
    public void ChangeScene(string sceneName)
    {
        
        SceneManager.LoadScene(sceneName);
    }
}
