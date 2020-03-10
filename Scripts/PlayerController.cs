using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    
    public GameObject ShotPrefab;
    float shotSpeed = 50;

    GameDirector gameDirector;

    AudioSource shotSound;

    // Start is called before the first frame update
    void Awake()
    {
        Input.gyro.enabled = true;

        
        this.shotSound = GetComponent<AudioSource>();

        this.gameDirector = GameObject.FindGameObjectWithTag("GameDirector").GetComponent<GameDirector>();
        

      
        
    }



    private void OnTriggerEnter(Collider other)
    {
        //Enemyと衝突した場合、GameOver
        if(other.tag == "Enemy")
        {
            this.gameDirector.ChangeScene("ResultScene");
        }
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.gyro.enabled)
        {
            Quaternion gyro = Quaternion.AngleAxis(90,Vector3.right)* Input.gyro.attitude;

            
            
            Vector3 forward = new Quaternion(gyro.x, gyro.y, -gyro.z, -gyro.w) * Vector3.forward;
            
            //theta = Mathf.Acos( Vector3.Dot(new Vector3(forward.x, 0, forward.z).normalized, Vector3.forward) )/Mathf.PI * 180;
            //fowardのx-z平面への射影したベクトルとz軸方向のなす角を計算
            //forwardはデバイスの前方方向
            float theta = Mathf.Acos(forward.z) / Mathf.PI * 180;
            if(forward.x < 0)
            {
                theta = -theta;
            }



            Quaternion rot = Quaternion.AngleAxis(-theta, Vector3.up);
            
            transform.localRotation = rot;


        }

        if (Input.GetMouseButtonDown(0) && !gameDirector.isPause)
        {
            GameObject shot = Instantiate(ShotPrefab) as GameObject;
            shot.GetComponent<ShotController>().vel = transform.forward.normalized * this.shotSpeed;
            this.shotSound.PlayOneShot(this.shotSound.clip);
        }
        
        
    }

}
