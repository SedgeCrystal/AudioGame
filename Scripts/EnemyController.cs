using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float SoundDis = 0.5f;
    float dis = 0;
    public float speed;
    AudioSource audioSource;
    public AudioClip enemySound;
    Rigidbody enemyRb;


    // Start is called before the first frame update
    void Start()
    {
        this.audioSource = GetComponent<AudioSource>();
        
        this.enemyRb = GetComponent<Rigidbody>();
        this.enemyRb.velocity = -this.speed *transform.position.normalized;


        this.dis = 0;
    }

    // Update is called once per frame
    void Update()
    {

        dis += enemyRb.velocity.magnitude * Time.deltaTime;
        

        if (dis > SoundDis)
        {

            audioSource.PlayOneShot(this.enemySound);
            dis = 0;
        }
        

        
    }
}
