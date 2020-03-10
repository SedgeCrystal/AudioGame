using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float enemySpeed;
    float spawnRadius = 10;

    public AudioClip[] enemySoundClips;
    

    // Start is called before the first frame update
    void Start()
    {
        this.enemySpeed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //GameDirectorから呼び出す
    public void GenerateEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab) as GameObject;

        //ランダムで初期位置の角度決定
        float theta = Random.Range(0, 360);
        enemy.transform.position = new Vector3(Mathf.Cos(theta), 0, Mathf.Sin(theta)) * spawnRadius;


        EnemyController enemyController = enemy.GetComponent<EnemyController>();
        enemyController.speed = this.enemySpeed;
        enemyController.enemySound = this.enemySoundClips[Random.Range(0, 6)];
        
    }
}
