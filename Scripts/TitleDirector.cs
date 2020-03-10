using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour
{
    //タップしたときのSE再生用
    //画面遷移するためAudioSource用のオブジェクトを作成しDontDestrotyOnLoadにする
    AudioSource asTap;
    public AudioClip[] acTap;
    // Start is called before the first frame update
    void Start()
    {
        //GameSceneから遷移したときにGameDirectorを削除
        GameObject gameDirector = GameObject.Find("GameDirector");
        if(gameDirector != null)
        {
            Destroy(gameDirector);
        }
        GameObject audioSourse_Tap = GameObject.Find("AudioSource_Tap");
        DontDestroyOnLoad(audioSourse_Tap);
        this.asTap = audioSourse_Tap.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //2本以上のゆびで押された時点でゲームを終了する
        if (Input.GetMouseButtonDown(1))
        {
            this.asTap.PlayOneShot(acTap[0]);
            UnityEngine.Application.Quit();
        }
        //1本の指で押された場合、multi-tapするか分からないため、multi-tapする前に指が離れた場合にScene遷移をする
        if (Input.GetMouseButtonUp(0))
        {
            this.asTap.PlayOneShot(acTap[1]);
            SceneManager.LoadScene("RuleExplainScene");
        }
    }
}
