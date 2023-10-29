using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class enemySpawning : MonoBehaviour
{
    
    public GameObject basicEnemy;
    public GameObject rocketEnemy;
    public GameObject strongEnemy;
    public GameObject supportEnemy;
    public GameObject spawner;

    private float basicSpawnTimerMax;
    private float rocketSpawnTimerMax;
    private float supportEnemyTimerMax;
    private float strongEnemyTimerMax;

    private float basicSpawnTimer = 0f;
    private float rocketSpawnTimer = 10f;
    private float supportEnemyTimer = 8f;
    private float strongEnemyTimer = 5f;
    
    private float MaxEnemies =2f;
    private float MaxEnemiesrocketMan=1f;
    private float MaxStrongEnemies = 0f;
    private float MaxSupportEnemies = 0f;

    private float numBasicEnemies =0f;
    private float numRocketEnemies =0f;
    private float numStrongEnemy = 0f;
    private float numSupportEnemy = 0f;
    
    private float difficultyIncrease =30;
    private float difficultyMultiplier = 1;
    private float multIncreaseTimer = 0f;

    public Boolean xAxis;
    // Update is called once per frame
    void Update()
    {
        if (basicSpawnTimer <= 0 && numBasicEnemies <= MaxEnemies)
        {
            basicSpawnTimerMax = Random.Range(2, 5);
            basicSpawnTimer = basicSpawnTimerMax;
            //print("SPAWNED");
            //spawning on a random x or y axis
            
            Quaternion spawnRotation = spawner.transform.rotation;
            if (xAxis)
            {
                Vector3 spawnlocation = new Vector3(spawner.transform.position.x, Random.Range(0,55), 0);
                Instantiate(basicEnemy, spawnlocation, spawnRotation);
            }
            else
            {
                Vector3 spawnlocation = new Vector3(Random.Range(-50, 50), spawner.transform.position.y, 0);
                Instantiate(basicEnemy, spawnlocation, spawnRotation);
            }
            
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
            
            Quaternion spawnRotation = spawner.transform.rotation;
            if (xAxis)
            {
                Vector3 spawnlocation = new Vector3(spawner.transform.position.x, Random.Range(0, 55), 0);
                Instantiate(rocketEnemy, spawnlocation, spawnRotation);
            }
            else
            {
                Vector3 spawnlocation = new Vector3(Random.Range(-50, 50), spawner.transform.position.y, 0);
                Instantiate(rocketEnemy, spawnlocation, spawnRotation);
            }
            
            numRocketEnemies+=1;
            
        }
        else
        {
            rocketSpawnTimer -= Time.deltaTime;
            //print(rocketSpawnTimer);
        }
        if (supportEnemyTimer <= 0 &&numSupportEnemy < MaxSupportEnemies)
        {
            supportEnemyTimerMax = Random.Range(5, 15);
            supportEnemyTimer = supportEnemyTimerMax;
            
            Quaternion spawnRotation = spawner.transform.rotation;
            if (xAxis)
            {
                Vector3 spawnlocation = new Vector3(spawner.transform.position.x, Random.Range(0, 55), 0);
                Instantiate(supportEnemy, spawnlocation, spawnRotation);
            }
            else
            {
                Vector3 spawnlocation = new Vector3(Random.Range(-50, 50), spawner.transform.position.y, 0);
                Instantiate(supportEnemy, spawnlocation, spawnRotation);
            }
            
            numSupportEnemy++;
        }
        else
        {
            supportEnemyTimer -= Time.deltaTime;
        }
        if (strongEnemyTimer <= 0 && numStrongEnemy <MaxStrongEnemies)
        {
            strongEnemyTimerMax = Random.Range(5, 10);
            strongEnemyTimer = strongEnemyTimerMax;
            
            Quaternion spawnRotation = spawner.transform.rotation;
            if (xAxis)
            {
                Vector3 spawnlocation = new Vector3(spawner.transform.position.x, Random.Range(0, 55), 0);
                Instantiate(strongEnemy, spawnlocation, spawnRotation);
            }
            else
            {
                Vector3 spawnlocation = new Vector3(Random.Range(-50, 50), spawner.transform.position.y, 0);
                Instantiate(strongEnemy, spawnlocation, spawnRotation);
            }
            
            numStrongEnemy++;
        }
        else
        {
            strongEnemyTimer -= Time.deltaTime;
        }

        if (difficultyIncrease <= 0)
        {
            MaxEnemies += 2 * difficultyMultiplier;
            MaxEnemiesrocketMan += 2 * difficultyMultiplier;
            MaxSupportEnemies += 2 * difficultyMultiplier;
            MaxStrongEnemies += 1 *difficultyMultiplier;

            multIncreaseTimer++;
            if(multIncreaseTimer % 5 == 0)
            {
                difficultyMultiplier++;
            }

        }
        else
        {
            difficultyIncrease -= Time.deltaTime;
        }
    }

}
