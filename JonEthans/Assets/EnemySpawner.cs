using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject basicEnemy;
    public GameObject otherEnemy;
    public GameObject spawner;
    [SerializeField]private float basicSpawnTimerMax;
    [SerializeField]private float otherSpawnTimerMax;
    private float basicSpawnTimer=0;
    private float otherSpawnTimer=0;
    [SerializeField] private int waveNum =1;
    [SerializeField] private float MaxEnemies;
    [SerializeField] private float MaxEnemiesOther;

    // Update is called once per frame
    void Update()
    {
        if(basicSpawnTimer <= 0)
        {
            basicSpawnTimer = basicSpawnTimerMax;
            //print("SPAWNED");
            Vector3 spawnlocation = spawner.transform.position;
            Quaternion spawnRotation = spawner.transform.rotation;
            Instantiate(basicEnemy,spawnlocation,spawnRotation);
        }
        else
        {
            basicSpawnTimer -= Time.deltaTime;
            //print(basicSpawnTimer);
        }
    }
}
