using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultDirector : MonoBehaviour
{
    

    Text resultText;
    int score;
    AudioSource audioSource;
    public AudioClip[] audioClips;
    public AudioClip[] acTap;
    AudioSource asTap;

    //スコア読み上げの際の使う音声の順番
    Stack<int> audioStack;
    
    

    // Start is called before the first frame update
    void Awake()
    {
        GameObject gameDirector = GameObject.Find("GameDirector");
        this.score = gameDirector.GetComponent<GameDirector>().score;

        if (this.score > 10000)
        {
            this.score = 9999;
        }
        Destroy(gameDirector);

        this.resultText = GameObject.Find("ResultText").GetComponent<Text>();
        this.resultText.text = string.Format("YourScore:{0}", score);
        this.audioSource = GetComponent<AudioSource>();
        this.asTap = GameObject.Find("AudioSource_Tap").GetComponent<AudioSource>();

        this.audioStack = new Stack<int>();
    }

    void SetAudioStack()
    {
        this.audioStack.Push(14);


        if (this.score == 0)
        {
            this.audioStack.Push(0);
            
        }
        else
        {
            //scoreをいじって表示スコアが変化してほしくないためtmpをいじって読み上げる音声を決定
            int tmp = this.score;

            for (int i = 0; i < 4; i++)
            {
                int num = tmp % 10;
                if (num != 0)
                {
                    this.audioStack.Push(num);
                }
                tmp /= 10;
                if (tmp == 0)
                {
                    break;
                }

                this.audioStack.Push(10 + i);


            }
        }
        this.audioStack.Push(13);
        
    }

    void ReadScore()
    {

        //前の読み上げが終わったときのみ再生
        if (!this.audioSource.isPlaying)
        {
            this.audioSource.PlayOneShot(audioClips[this.audioStack.Peek()]);
            this.audioStack.Pop();
        }



    }

    // Update is called once per frame
    void Update()
    {
        //読み上げのスタックが空ならスタックに再追加
        //空でないなら順に読み上げ
        Debug.Log(this.audioStack);
        if (this.audioStack.Count == 0)
        {
            this.SetAudioStack();
        }
        else
        {
            this.ReadScore();
        }


        if (Input.GetMouseButtonUp(1))
        {
            this.asTap.PlayOneShot(acTap[0]);
            SceneManager.LoadScene("TitleScene");
            
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            this.asTap.PlayOneShot(acTap[1]);
            SceneManager.LoadScene("GameScene");
        }
    }
}
