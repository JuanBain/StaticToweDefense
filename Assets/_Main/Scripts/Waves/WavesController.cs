using System;
using System.Collections;
using System.Collections.Generic;
using _Main.Scripts;
using UnityEngine;

public class WavesController : Singleton<WavesController>
{
    [SerializeField]
    private EnemySpawner _enemySpawner;

    [SerializeField]
    private float health, increaseHealth, damage, increaseDamage, timeBetweenEnemies;

    [SerializeField]
    private int countOfEnemiesPerWave, countOfWaves;

    [SerializeField]
    private List<BaseEnemy> enemiesInWave;


    private void Start()
    {
        enemiesInWave = new List<BaseEnemy>();
        GenerateNewWave();
    }

    private void GenerateNewWave()
    {
        //TODO: Reestructure incremental stats of enemies
        var newHealth = health + (countOfWaves * increaseHealth);
        var newDamage = damage + (increaseDamage * countOfWaves);
        StartCoroutine(Spawn(newHealth, newDamage));
    }

    private IEnumerator Spawn(float newHealth, float newDamage)
    {
        for (int i = 0; i <= countOfEnemiesPerWave; i++)
        {
            _enemySpawner.SpawnEnemy(newHealth, newDamage);
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }


    public void AddEnemy(BaseEnemy baseEnemy)
    {
        enemiesInWave.Add(baseEnemy);
    }

    public void RemoveEnemy(BaseEnemy baseEnemy)
    {
        enemiesInWave.Remove(baseEnemy);
        if (enemiesInWave.Count == 0)
        {
            GenerateNewWave();
            countOfWaves++;
        }
    }
}