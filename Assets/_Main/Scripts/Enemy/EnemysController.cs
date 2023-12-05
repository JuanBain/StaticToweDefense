using System.Collections;
using System.Collections.Generic;
using _Main.Scripts;
using UnityEngine;

public class EnemysController : Singleton<EnemysController>
{
    [SerializeField]
    private List<BaseEnemy> enemies;

    [SerializeField]
    private List<BaseEnemy> enemiesInRange;

    public List<BaseEnemy> Enemies
    {
        get => enemies;
        set => enemies = value;
    }

    public List<BaseEnemy> EnemiesInRange
    {
        get => enemiesInRange;
        set => enemiesInRange = value;
    }

    protected override void Awake()
    {
        base.Awake();
        enemies = new List<BaseEnemy>();
        enemiesInRange = new List<BaseEnemy>();
    }
}