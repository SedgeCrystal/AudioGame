using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RuleExplainDirector : MonoBehaviour
{
    public AudioClip[] acTap;
    AudioSource asTap;
    // Start is called before the first frame update
    void Start()
    {
        this.asTap = GameObject.Find("AudioSource_Tap").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            this.asTap.PlayOneShot(acTap[1]);
            SceneManager.LoadScene("GameScene");
        }
        
    }
}
