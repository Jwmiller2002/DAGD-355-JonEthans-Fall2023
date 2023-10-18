using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawning : MonoBehaviour
{
    
    public GameObject basicEnemy;
    public GameObject rocketEnemy;
    public GameObject spawner;
    [SerializeField] private float basicSpawnTimerMax;
    [SerializeField] private float rocketSpawnTimerMax;
    private float basicSpawnTimer = 2f;
    private float rocketSpawnTimer = 0f;
    
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
            basicSpawnTimerMax = Random.Range(3, 8);
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
            print("what");
            rocketSpawnTimerMax = Random.Range(3, 8);
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
            print(rocketSpawnTimer);
        }
        if(difficultyIncrease <= 0)
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
