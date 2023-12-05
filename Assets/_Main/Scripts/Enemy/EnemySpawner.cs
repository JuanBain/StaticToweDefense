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
    private float distanceOfRange;

    void Start()
    {
        SpawnEnemy();
        SpawnEnemy();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        int angle = Random.Range(0, 360);
        float distanceToSpawn = (PlayerController.Instance.Range + distanceOfRange);
        float x = distanceToSpawn * Mathf.Cos(angle);
        float y = distanceToSpawn * Mathf.Sin(angle);
        var newEnemy = Instantiate(enemy, new Vector3(x, y, 0), quaternion.identity);
        EnemysController.Instance.Enemies.Add(newEnemy.GetComponent<BaseEnemy>());
    }
}