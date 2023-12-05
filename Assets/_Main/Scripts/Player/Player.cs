using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private CircleCollider2D _collider2D;

    [SerializeField]
    private float timeToNextShoot;


    [SerializeField]
    private GameObject bullet;

    private void Start()
    {
        timeToNextShoot = PlayerController.Instance.TimeToShoot;
        UpdateRange();
    }

    public void UpdateRange()
    {
        _collider2D.radius = PlayerController.Instance.Range;
        GetComponent<RangeRenderer>().DrawCircle(100, PlayerController.Instance.Range);
    }

    private void Update()
    {
        if (timeToNextShoot <= 0)
        {
            if (EnemysController.Instance.EnemiesInRange.Count != 0)
            {
                BaseEnemy enemy = GetClosestEnemy();
                Attack(enemy);
                timeToNextShoot = PlayerController.Instance.TimeToShoot;
            }
        }
        else
        {
            timeToNextShoot -= Time.deltaTime;
        }
    }


    private void Attack(BaseEnemy enemy)
    {
        var bulletSpawned = Instantiate(bullet, this.transform.position, quaternion.identity);
        bulletSpawned.transform.DOMove(enemy.transform.position, PlayerController.Instance.BulletSpeed / 10f)
            .OnComplete(() => { }).Play();
        Debug.Log("MoveBullet");
    }

    private BaseEnemy GetClosestEnemy()
    {
        BaseEnemy closestEnemy = EnemysController.Instance.EnemiesInRange[0];
        var distance = Vector3.Distance(this.transform.position, closestEnemy.transform.position);
        foreach (BaseEnemy enemy in EnemysController.Instance.EnemiesInRange)
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