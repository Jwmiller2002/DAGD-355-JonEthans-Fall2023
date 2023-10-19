using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawning : MonoBehaviour
{
    
    public GameObject basicEnemy;
    public GameObject rocketEnemy;
    public GameObject strongEnemy;
    public GameObject supportEnemy;
    public GameObject spawner;
    [SerializeField] private float basicSpawnTimerMax;
    [SerializeField] private float rocketSpawnTimerMax;
    [SerializeField] private float supportEnemyTimerMax;
    [SerializeField] private float strongEnemyTimerMax;
    private float basicSpawnTimer = 0f;
    private float rocketSpawnTimer = 10f;
    private float supportEnemyTimer = 10f;
    private float strongEnemyTimer = 5f;
    
    [SerializeField] private float MaxEnemies =1f;
    [SerializeField] private float MaxEnemiesrocketMan=2f;
    private float numBasicEnemies =2f;
    private float numRocketEnemies =0f;
    private float difficultyIncrease =30;
    // Update is called once per frame
    void Update()
    {
        if (basicSpawnTimer <= 0 && numBasicEnemies <= MaxEnemies)
        {
            basicSpawnTimerMax = Random.Range(1, 5);
            basicSpawnTimer = basicSpawnTimerMax;
            //print("SPAWNED");
            Vector3 spawnlocation = spawner.transform.position;
            Quaternion spawnRotation = spawner.transform.rotation;
            Instantiate(basicEnemy, spawnlocation, spawnRotation);
            numBasicEnemies+=1f;
        }
        else
        {
            basicSpawnTimer -= Time.deltaTime;
            //print(basicSpawnTimer);
        }
        if (rocketSpawnTimer < 0 && numRocketEnemies < MaxEnemiesrocketMan)
        {
            //print("what");
            rocketSpawnTimerMax = Random.Range(10, 15);
            rocketSpawnTimer = rocketSpawnTimerMax;
            //print("SPAWNED");
            Vector3 spawnlocation = spawner.transform.position;
            Quaternion spawnRotation = spawner.transform.rotation;
            Instantiate(rocketEnemy, spawnlocation, spawnRotation);
            numRocketEnemies+=1;
            
        }
        else
        {
            rocketSpawnTimer -= Time.deltaTime;
            //print(rocketSpawnTimer);
        }
        if (supportEnemyTimer <= 0)
        {
            supportEnemyTimerMax = Random.Range(10, 15);
            supportEnemyTimer = supportEnemyTimerMax;
            Vector3 spawnlocation = spawner.transform.position;
            Quaternion spawnRotation = spawner.transform.rotation;
            Instantiate(supportEnemy, spawnlocation, spawnRotation);

        }
        else
        {
            supportEnemyTimer -= Time.deltaTime;
        }
        if (strongEnemyTimer <= 0)
        {
            strongEnemyTimerMax = Random.Range(5, 10);
            strongEnemyTimer = strongEnemyTimerMax;
            Vector3 spawnlocation = spawner.transform.position;
            Quaternion spawnRotation = spawner.transform.rotation;
            Instantiate(strongEnemy, spawnlocation, spawnRotation);

        }
        else
        {
            strongEnemyTimer -= Time.deltaTime;
        }

        if (difficultyIncrease <= 0)
        {
            MaxEnemies += 5;
            MaxEnemiesrocketMan += 2;
        }
        else
        {
            difficultyIncrease -= Time.deltaTime;
        }
    }

}
