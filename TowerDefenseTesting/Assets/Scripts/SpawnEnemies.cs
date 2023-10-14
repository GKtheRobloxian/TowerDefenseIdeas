using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] turnPoints;
    public float spawnDelay;
    float spawnDelayInit;
    // Start is called before the first frame update
    void Start()
    {
        spawnDelayInit = spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        int randomEnemies = Random.Range(0, enemies.Length);
        spawnDelay -= Time.deltaTime;
        if (spawnDelay <= 0)
        {
            GameObject instantiatedEnemy = Instantiate(enemies[randomEnemies], new Vector3(-0.25f, 0.225f, -6.25f), Quaternion.identity);
            instantiatedEnemy.GetComponent<EnemyScript>().turnPoints = turnPoints;
            spawnDelay = spawnDelayInit;
        }
    }
}
