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
        // SpawnEnemy();
        // SpawnEnemy();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // SpawnEnemy();
        }
    }

    public void SpawnEnemy(float newHealth, float newDamage)
    {
        int angle = Random.Range(0, 360);

        float distanceToSpawn = (PlayerController.Instance.Range + distanceOfRange);
        float x = distanceToSpawn * Mathf.Cos(angle);
        float y = distanceToSpawn * Mathf.Sin(angle) + PlayerController.Instance.Player.transform.position.y;

        GameObject newEnemy = Instantiate(enemy, new Vector3(x, y, 0), quaternion.identity);
        BaseEnemy newBaseEnemy = newEnemy.GetComponent<BaseEnemy>();
        newBaseEnemy.Initialize(newHealth, newDamage);

        WavesController.Instance.AddEnemy(newBaseEnemy);
        EnemysController.Instance.Enemies.Add(newBaseEnemy);
    }
}