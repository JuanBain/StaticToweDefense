using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float range, damage, health, timeToShoot, timeToNextShoot, bulletSpeed;


    [SerializeField]
    private GameObject bullet;

    private void Start()
    {
        timeToNextShoot = timeToShoot;
        CreateRangeMesh();
    }

    private void Update()
    {
        if (timeToNextShoot <= 0)
        {
            BaseEnemy enemy = GetClosestEnemy();
            if (CheckEnemyInRange(enemy))
            {
                Attack(enemy);
                timeToNextShoot = timeToShoot;
            }
        }
        else
        {
            timeToNextShoot -= Time.deltaTime;
        }
    }

    private void CreateRangeMesh()
    {
        
    }
    private bool CheckEnemyInRange(BaseEnemy enemy)
    {
        if (Vector3.Distance(enemy.transform.position, transform.position) <= range)
        {
            return true;
        }

        return false;
    }


    private void Attack(BaseEnemy enemy)
    {
        var bulletSpawned = Instantiate(bullet, this.transform.position, quaternion.identity);
        bulletSpawned.transform.DOMove(enemy.transform.position, bulletSpeed / 10f).OnComplete(() => { }).Play();
        Debug.Log("MoveBullet");
    }

    private BaseEnemy GetClosestEnemy()
    {
        BaseEnemy closestEnemy = EnemysController.Instance.Enemies[0];
        var distance = Vector3.Distance(this.transform.position, closestEnemy.transform.position);
        foreach (BaseEnemy enemy in EnemysController.Instance.Enemies)
        {
            var newDistance = Vector3.Distance(this.transform.position, enemy.transform.position);
            if (newDistance < distance)
            {
                closestEnemy = enemy;
                distance = newDistance;
            }
        }

        return closestEnemy;
    }
}