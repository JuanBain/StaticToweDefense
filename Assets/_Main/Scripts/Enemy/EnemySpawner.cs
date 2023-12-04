using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private float spawnDistance = 5f;

    void Start()
    {
        SpawnEnemy();
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        int angle = Random.Range(0, 360);
        float x = spawnDistance * Mathf.Cos(angle);
        float y = spawnDistance * Mathf.Sin(angle);
        var newEnemy = Instantiate(enemy, new Vector3(x, y, 0), quaternion.identity);
        EnemysController.Instance.Enemies.Add(newEnemy.GetComponent<BaseEnemy>());
    }
}