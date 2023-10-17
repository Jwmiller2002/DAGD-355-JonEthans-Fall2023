using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawning : MonoBehaviour
{
    
    public GameObject basicEnemy;
    public GameObject otherEnemy;
    public GameObject spawner;
    [SerializeField] private float basicSpawnTimerMax;
    //[SerializeField] private float otherSpawnTimerMax;
    private float basicSpawnTimer = 0f;
    //private float otherSpawnTimer = 0;
    [SerializeField] private int waveNum = 1;
    [SerializeField] private float MaxEnemies;
    [SerializeField] private float MaxEnemiesOther;
    private float numBasicEnemies;

    // Update is called once per frame
    void Update()
    {
        if (basicSpawnTimer <= 0 && numBasicEnemies <MaxEnemies)
        {
            basicSpawnTimer = basicSpawnTimerMax;
            //print("SPAWNED");
            Vector3 spawnlocation = spawner.transform.position;
            Quaternion spawnRotation = spawner.transform.rotation;
            Instantiate(basicEnemy, spawnlocation, spawnRotation);
            numBasicEnemies++;
        }
        else
        {
            basicSpawnTimer -= Time.deltaTime;
            //print(basicSpawnTimer);
        }
    }

}
