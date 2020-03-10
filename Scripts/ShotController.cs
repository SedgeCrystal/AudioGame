using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    public Vector3 vel;
    float maxDis = 30;
    Rigidbody shotRb;
    AudioSource hitSound;
    GameDirector gameDirector;
    // Start is called before the first frame update
    void Start()
    {
        
        
        this.shotRb = GetComponent<Rigidbody>();
        this.shotRb.velocity = vel;
        this.hitSound = GetComponent<AudioSource>();

        this.gameDirector = GameObject.FindGameObjectWithTag("GameDirector").GetComponent<GameDirector>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            AudioSource.PlayClipAtPoint(this.hitSound.clip, transform.position);
            gameDirector.score++;

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if(transform.position.magnitude >= maxDis)
        {
            Destroy(gameObject);
        }
    }
}
